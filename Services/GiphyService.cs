using System.Net.Http.Json;
using System.Text.Json;
using System.Web;

namespace CatGifApi.Services;

public class GiphyResponse
{
    public List<GifData> Data { get; set; } = new();
}

public class GifData
{
    public Images Images { get; set; } = new();
}

public class Images
{
    public ImageData Original { get; set; } = new();
}

public class ImageData
{
    public string Url { get; set; } = string.Empty;
}

public class GiphyService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "voaNIOg1u7ONPbckzWK71C48YqCOkhVP";

    public GiphyService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string?> SearchGifAsync(string query)
    {
        var encodedQuery = HttpUtility.UrlEncode(query);
        var url = $"https://api.giphy.com/v1/gifs/search?api_key= {ApiKey}&q={encodedQuery}&limit=1";

        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode) return null;

        using var doc = await JsonDocument.ParseAsync(await response.Content.ReadAsStreamAsync());
        var root = doc.RootElement;

        if (root.TryGetProperty("data", out var dataArray) && dataArray.GetArrayLength() > 0)
        {
            return dataArray[0].GetProperty("images").GetProperty("original").GetProperty("url").GetString();
        }

        return null;
    }
}