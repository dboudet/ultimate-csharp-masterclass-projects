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
}
