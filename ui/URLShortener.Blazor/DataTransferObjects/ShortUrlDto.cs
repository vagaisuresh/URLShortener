namespace URLShortener.Blazor.DataTransferObjects;

public class ShortUrlDto
{
    public int Id { get; set; }
    public string LongUrl { get; set; } = string.Empty;
    public string ShortId { get; set; } = string.Empty;
    public string Domain { get; set; } = string.Empty;
    public string ShortUrlValue { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime? ExpireAtDateTime { get; set; }
    public int? ExpireAtViews { get; set; }
    public bool PublicStats { get; set; } = false;
    public bool HasPassword { get; set; } = false;
    public DateTime CreatedAtDateTime { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAtDateTime { get; set; } = DateTime.UtcNow;
}