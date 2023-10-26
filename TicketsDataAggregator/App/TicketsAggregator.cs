using System.Globalization;
using TicketsDataAggregator.Data;
using TicketsDataAggregator.Tickets;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace TicketsDataAggregator.App;

public class TicketsAggregator
{
    private string _ticketsFolder;

    public TicketsAggregator(string ticketsFolder)
    {
        _ticketsFolder = ticketsFolder;
    }

    public void Run()
    {
        var defaultCulture = CultureInfo.CurrentCulture;

        var files = Directory.GetFiles(_ticketsFolder, "*.pdf");

        var allTickets = new List<Ticket>();

        foreach (string file in files)
        {
            using (PdfDocument document = PdfDocument.Open($"{file}"))
            {
                Page page = document.GetPage(1);
                string text = page.Text;

                CultureInfo culture;
                culture = DataParser.GetCultureInfoFromWebsite(page);

                var titles = new List<string>();
                var datesAsStrings = new List<string>();
                var timesAsStrings = new List<string>();

                var split = text.Split(
                    new[] { "Title:", "Date:", "Time:", "Visit us:" },
                    StringSplitOptions.None);



                for (int i = 1; i < (split.Length - 3); i += 3)
                {
                    allTickets.Add(new Ticket(
                        culture, split[i], split[i + 1], split[i + 2]));
                }
            }
        }
        File.WriteAllLines("aggregatedTickets.txt",
            allTickets.Select(v => v.ToString()));

        CultureInfo.CurrentCulture = defaultCulture;
    }
}

