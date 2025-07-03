namespace URLShortener.API.DTOs;

public record ShortUrlRequest(string? LongUrl, string? Description, bool HasPassword);