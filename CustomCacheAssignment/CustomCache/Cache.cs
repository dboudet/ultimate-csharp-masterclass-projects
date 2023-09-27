namespace CustomCacheAssignment.CustomCache
{
    public class Cache<TCacheKey, TDataType> : ICache<TCacheKey, TDataType>
    {
        private Dictionary<TCacheKey, TDataType> _cachedData = new();

        public bool isDataInCache(TCacheKey keyId)
        {
            return _cachedData.ContainsKey(keyId);
        }

        public TDataType GetData(
            TCacheKey keyId,
            Func<TCacheKey, TDataType> retrieveFreshData)
        {
            if (!isDataInCache(keyId))
            {
                _cachedData[keyId] = retrieveFreshData(keyId);
            }
            return _cachedData[keyId] ?? throw new KeyNotFoundException(
            $"Unable to retrieve data for key: {keyId}.");
        }
    }
}
