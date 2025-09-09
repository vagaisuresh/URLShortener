using URLShortener.Blazor.DataTransferObjects;

namespace URLShortener.Blazor.Services.Interfaces;

public interface IShortUrlApiService
{
    Task<IEnumerable<ShortUrlDto>> GetAllAsync();
    Task<ShortUrlDto> GetByIdAsync(string id);
    Task<ShortUrlDto> CreateAsync(ShortUrlDto dto);
    Task UpdateAsync(int id, ShortUrlDto dto);
    Task DeleteAsync(int id);
}