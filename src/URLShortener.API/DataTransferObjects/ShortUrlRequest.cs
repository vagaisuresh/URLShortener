namespace URLShortener.API.DataTransferObjects;

public record ShortUrlRequest(string? LongUrl, string? Description, bool HasPassword);