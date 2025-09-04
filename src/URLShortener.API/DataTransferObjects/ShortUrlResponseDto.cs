namespace URLShortener.API.DataTransferObjects;

public class ShortUrlResponseDto
{
    public int Id { get; set; }
    public string LongUrl { get; set; } = default!;
    public string ShortUrlValue { get; set; } = default!;
    public string? Description { get; set; } = string.Empty;
    public DateTime CreatedAtDateTime { get; set; } = DateTime.UtcNow;
}