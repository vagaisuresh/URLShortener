namespace URLShortener.API.Domain.Entities;

public class ShortUrl
{
    public int Id { get; set; }

    public required string LongUrl { get; set; }

    public required string ShortId { get; set; }

    public required string Domain { get; set; }

    public required string ShortUrlValue { get; set; }

    public string? Description { get; set; }

    public DateTime? ExpireAtDateTime { get; set; }

    public int? ExpireAtViews { get; set; }

    public bool PublicStats { get; set; } = false;

    public bool HasPassword { get; set; } = false;

    public DateTime CreatedAtDateTime { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAtDateTime { get; set; } = DateTime.UtcNow;
}