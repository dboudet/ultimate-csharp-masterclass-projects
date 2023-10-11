namespace StarWarsApiReader.ApiReader;

public class ApiReader : IApiReader
{
    public string BaseUrl { get; }
    public string RequestPath { get; }

    public ApiReader(string baseUrl, string requestPath)
    {
        BaseUrl = baseUrl;
        RequestPath = requestPath;
    }

    public async Task<string> Read()
    {
        try
        {
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(BaseUrl + RequestPath);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("API request failed. Switching to mock data. +" +
                $"Exception Message: {ex.Message}");
            IApiReader _apiReader = new MockStarWarsApiDataReader(BaseUrl, RequestPath);
            return await _apiReader.Read();
        }
        catch (Exception ex)
        {
            throw new Exception("Problem retrieving data from API.", ex);
        }
    }
}
