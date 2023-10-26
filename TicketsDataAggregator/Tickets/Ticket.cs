using System.Globalization;
using System.Text;

namespace TicketsDataAggregator.Tickets;

internal class Ticket
{
    public Ticket(CultureInfo culture,
        string title,
        string dateAsString,
        string timeAsString)
    {
        Culture = culture;
        Title = title;
        DateAsString = dateAsString;
        TimeAsString = timeAsString;
    }

    CultureInfo Culture { get; }
    internal string Title { get; }
    internal string DateAsString { get; }
    internal string TimeAsString { get; }
    internal string InvariantDate()
    {
        var userDate = DateOnly.Parse(DateAsString, Culture);
        return userDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
    }
    internal string InvariantTime()
    {
        var userTime = TimeOnly.Parse(TimeAsString, Culture);
        return userTime.ToString("HH:mm", CultureInfo.InvariantCulture);
    }


    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append(string.Format(
            "{0,-20} | {1,-10} | {2,-5}",
            Title, InvariantDate(), InvariantTime()));
        //Console.WriteLine(sb.ToString());
        return sb.ToString();
    }
}
