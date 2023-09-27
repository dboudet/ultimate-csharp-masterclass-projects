using System.Diagnostics;
using CustomCacheAssignment.CustomCache;
using CustomCacheAssignment.DataDownloader;

IDataDownloader<string, string> dataDownloader =
    new SlowDataDownloader<string, string>();

bool isPrintingEnabled = true;
bool isCacheEnabled = true;

if (isPrintingEnabled)
{
    dataDownloader =
        new PrintingDataDownloader<string, string>(
                       dataDownloader);
}

if (isCacheEnabled)
{

    ICache<string, string> customCache =
        new Cache<string, string>();

    dataDownloader =
        new CachingDataDownloader<string, string>(
            dataDownloader,
            customCache);
}


var stopwatch = Stopwatch.StartNew();
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
stopwatch.Stop();
Console.WriteLine(stopwatch.ElapsedMilliseconds);


Console.ReadKey();




