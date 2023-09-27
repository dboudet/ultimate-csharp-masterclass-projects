using CustomCacheAssignment.CustomCache;
using CustomCacheAssignment.DataDownloader;





ICache<string, string> customCache =
    new Cache<string, string>();


IDataDownloader<string, string> dataDownloader =
    new SlowDataDownloader<string, string>(customCache);


Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));



Console.ReadKey();




