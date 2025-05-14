using System.Net.Http.Json;
using CatGifApi.Models;

namespace CatGifApi.Services;

public class CatFactService
{
    private readonly HttpClient _httpClient;

    public CatFactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<CatFact?> GetRandomFactAsync()
    {
        return await _httpClient.GetFromJsonAsync<CatFact>("https://catfact.ninja/fact ");
    }
}