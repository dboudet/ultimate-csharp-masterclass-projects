using System.Globalization;
using UglyToad.PdfPig.Content;

namespace TicketsDataAggregator.Data;
public static class DataParser
{
    public static CultureInfo GetCultureInfoFromWebsite(Page page)
    {
        var website = page.GetHyperlinks()[0] ??
            throw new ArgumentNullException("Cannot determine region based on website");

        if (website.Text.Contains(".jp"))
        {
            return new CultureInfo("ja-JP");
        }
        else if (website.Text.Contains(".fr"))
        {
            return new CultureInfo("fr-FR");
        }
        else
        {
            return new CultureInfo("en-US");
        }
    }

}

