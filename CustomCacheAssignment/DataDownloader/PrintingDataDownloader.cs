namespace CustomCacheAssignment.DataDownloader
{
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
