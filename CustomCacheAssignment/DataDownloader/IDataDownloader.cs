namespace CustomCacheAssignment.DataDownloader
{
    public interface IDataDownloader<TKey, TData>
    {
        public TData DownloadData(TKey resourceId);
    }
}
