namespace CustomCacheAssignment.CustomCache
{
    public interface ICache<TCacheKey, TDataType>
    {
        TDataType GetData(
            TCacheKey keyId,
            Func<TCacheKey, TDataType> retrieveFreshData);
        bool isDataInCache(TCacheKey keyId);
    }
}