namespace StarWarsApiReader.ApiReader
{
    public static class ApiReader
    {
        public static async Task<string> Read(string baseUrl, string requestPath)
        {
            using var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(baseUrl + requestPath);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
