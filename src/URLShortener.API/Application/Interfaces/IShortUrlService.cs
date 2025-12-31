using URLShortener.API.DataTransferObjects;

namespace URLShortener.API.Application.Interfaces;

public interface IShortUrlService
{
    Task<IResult> GetShortUrlsAsync();
    Task<IResult> GetShortUrlAsync(int id);
    Task<IResult> GetShortUrlByShortIdAsync(string shortId);
    Task<IResult> CreateShortUrlAsync(ShortUrlRequest shortUrlRequest);
    Task<IResult> UpdateShortUrlAsync(int id, ShortUrlRequest shortUrlRequest);
    Task<IResult> DeleteShortUrlAsync(int id);
}