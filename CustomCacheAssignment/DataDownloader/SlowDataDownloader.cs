using CustomCacheAssignment.CustomCache;

namespace CustomCacheAssignment.DataDownloader
{
    public class SlowDataDownloader<TKey, TData> : IDataDownloader<TKey, TData>
    {
        private readonly ICache<TKey, TData> _cache;
        public SlowDataDownloader(
            ICache<TKey, TData> cache)
        {
            _cache = cache;
        }

        private TData GetFreshData(TKey resourceId)
        {
            //let's imagine this method downloads real data,
            //and it does it slowly
            Thread.Sleep(1000);
            return (TData)Convert.ChangeType(
                $"Some data for {resourceId}",
                typeof(TData));
        }
        public TData DownloadData(TKey resourceId)
        {
            return _cache.GetData(
                resourceId,
                GetFreshData);

        }
    }
}
