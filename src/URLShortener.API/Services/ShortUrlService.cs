using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using URLShortener.API.Application.Interfaces;
using URLShortener.API.DataTransferObjects;
using URLShortener.API.Domain.Entities;
using URLShortener.API.Persistence.Context;

namespace URLShortener.API.Services;

public class ShortUrlService : IShortUrlService
{
    private readonly AppDbContext _context;
    private readonly IShortIdGenerator _shortIdGenerator;
    private readonly ShortUrlSettings _settings;

    public ShortUrlService(AppDbContext context, IShortIdGenerator shortIdGenerator, IOptions<ShortUrlSettings> options)
    {
        _context = context;
        _shortIdGenerator = shortIdGenerator;
        _settings = options.Value;
    }

    public async Task<IResult> GetShortUrlsAsync()
    {
        var shortUrls = await _context.ShortUrls.ToListAsync();
        return Results.Ok(shortUrls);
    }

    public async Task<IResult> GetShortUrlAsync(int id)
    {
        var shortUrl = await _context.ShortUrls.FindAsync(id);
        return Results.Ok(shortUrl);
    }

    public async Task<IResult> GetShortUrlByShortIdAsync(string shortId)
    {
        var shortUrl = await _context.ShortUrls
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.ShortId == shortId);

        if (shortUrl == null)
            return Results.NotFound("Requested short URL not found.");

        var shortUrlResponseDto = new ShortUrlResponseDto
        {
            Id = shortUrl.Id,
            LongUrl = shortUrl.LongUrl,
            ShortUrlValue = shortUrl.ShortUrlValue,
            Description = shortUrl.Description,
            CreatedAtDateTime = shortUrl.CreatedAtDateTime
        };

        return Results.Ok(shortUrlResponseDto);
    }

    public async Task<IResult> CreateShortUrlAsync(ShortUrlRequest shortUrlRequest)
    {
        var domain = _settings.Domain;                  // Domain, fetch from appsettings
        var shortId = _shortIdGenerator.Generate(5);    // Generate a random short ID with 5 characters (custom generator)

        var shortUrl = new ShortUrl
        {
            Id = 0,
            LongUrl = shortUrlRequest?.LongUrl ?? throw new ArgumentNullException(nameof(shortUrlRequest), "Long URL cannot be null."),
            ShortId = shortId,
            Domain = domain,
            ShortUrlValue = $"{domain}/{shortId}",
            Description = shortUrlRequest.Description ?? string.Empty,
            ExpireAtDateTime = DateTime.UtcNow,
            ExpireAtViews = 0,
            PublicStats = true,
            HasPassword = shortUrlRequest.HasPassword,
            CreatedAtDateTime = DateTime.UtcNow,
            UpdatedAtDateTime = new DateTime(1900, 1, 1)
        };

        await _context.ShortUrls.AddAsync(shortUrl);
        await _context.SaveChangesAsync();

        return Results.Created($"/short-urls/{shortUrl.Id}", shortUrl);
    }

    public async Task<IResult> UpdateShortUrlAsync(int id, ShortUrlRequest shortUrlRequest)
    {
        if (shortUrlRequest is null)
            return Results.BadRequest("Short URL request cannot be null.");

        if (string.IsNullOrWhiteSpace(shortUrlRequest.LongUrl))
            throw new ArgumentNullException(nameof(shortUrlRequest), "Long URL cannot be null.");

        var existingShortUrl = await _context.ShortUrls.FindAsync(id);

        if (existingShortUrl is null)
            return Results.NotFound("Requested short URL not found.");

        existingShortUrl.LongUrl = shortUrlRequest.LongUrl;
        existingShortUrl.Description = shortUrlRequest.Description;
        // Other fields to update

        _context.ShortUrls.Update(existingShortUrl);
        await _context.SaveChangesAsync();

        return Results.NoContent();
    }

    public async Task<IResult> DeleteShortUrlAsync(int id)
    {
        var existingShortUrl = await _context.ShortUrls.FindAsync(id);

        if (existingShortUrl is null)
            return Results.NotFound("Requested short URL not found.");
        
        _context.ShortUrls.Remove(existingShortUrl);
        await _context.SaveChangesAsync();

        return Results.NoContent();
    }
}