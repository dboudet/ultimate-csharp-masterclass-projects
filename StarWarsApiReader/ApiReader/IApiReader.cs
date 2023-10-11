namespace StarWarsApiReader.ApiReader
{
    public interface IApiReader
    {
        public string BaseUrl { get; }
        public string RequestPath { get; }
        Task<string> Read();
    }
}