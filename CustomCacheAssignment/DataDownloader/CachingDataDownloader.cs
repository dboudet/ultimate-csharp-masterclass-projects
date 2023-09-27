using CustomCacheAssignment.CustomCache;

namespace CustomCacheAssignment.DataDownloader
{
    public class CachingDataDownloader<TKey, TData> : IDataDownloader<TKey, TData>
    {
        private readonly IDataDownloader<TKey, TData> _dataDownloader;
        private readonly ICache<TKey, TData> _cache;

        public CachingDataDownloader(
            IDataDownloader<TKey, TData> dataDownloader,
            ICache<TKey, TData> cache)
        {
            _dataDownloader = dataDownloader;
            _cache = cache;
        }

        public TData DownloadData(TKey resourceId)
        {
            return _cache.GetData(
                resourceId,
                _dataDownloader.DownloadData);

        }
    }

}
