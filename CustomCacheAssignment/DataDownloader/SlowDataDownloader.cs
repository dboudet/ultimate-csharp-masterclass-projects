namespace CustomCacheAssignment.DataDownloader
{
    public class SlowDataDownloader<TKey, TData> : IDataDownloader<TKey, TData>
    {
        public TData DownloadData(TKey resourceId)
        {
            //let's imagine this method downloads real data,
            //and it does it slowly
            Thread.Sleep(1000);
            return (TData)Convert.ChangeType(
                $"Some data for {resourceId}",
                typeof(TData));
        }
    }

    public class PrintingDataDownloader<TKey, TData> : IDataDownloader<TKey, TData>
    {
        private readonly IDataDownloader<TKey, TData> _dataDownloader;

        public PrintingDataDownloader(IDataDownloader<TKey, TData> dataDownloader)
        {
            _dataDownloader = dataDownloader;
        }

        public TData DownloadData(TKey resourceId)
        {
            var data = _dataDownloader.DownloadData(resourceId);
            Console.WriteLine("Data is ready!");
            return data;
        }
    }
}
