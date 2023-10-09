namespace StarWarsApiReader.ApiReader;

public static class ApiReader
{
    public static async Task<string> Read(string baseUrl, string requestPath)
    {
        try
        {
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(baseUrl + requestPath);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            throw ex;
        }
        catch (Exception ex)
        {
            throw new FileNotFoundException("Problem retrieving data from Star Wars API.", ex.Message);
        }
    }
}
