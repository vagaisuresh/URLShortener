using System.Net.Http.Json;
using URLShortener.Blazor.DataTransferObjects;
using URLShortener.Blazor.Services.Interfaces;

namespace URLShortener.Blazor.Services;

public class ShortUrlApiService : IShortUrlApiService
{
    private readonly HttpClient _http;

    public ShortUrlApiService(HttpClient http) => _http = http;

    public Task<List<ShortUrlDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ShortUrlDto> GetByIdAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<ShortUrlDto> CreateAsync(ShortUrlDto dto)
    {
        var response = await _http.PostAsJsonAsync("api/short-urls", dto);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<ShortUrlDto>();
        return result!;
    }

    public Task UpdateAsync(int id, ShortUrlDto dto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}