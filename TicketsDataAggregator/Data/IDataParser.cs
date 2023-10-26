using System.Globalization;
using UglyToad.PdfPig.Content;

namespace TicketsDataAggregator.Data
{
    public interface IDataParser
    {
        string[] Files { get; }

        CultureInfo GetCultureInfoFromWebsite(Page page);
    }
}