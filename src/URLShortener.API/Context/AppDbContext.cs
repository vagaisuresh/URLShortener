using Microsoft.EntityFrameworkCore;
using URLShortener.API.Models;

namespace URLShortener.API.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<ShortUrl> ShortUrls { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ShortUrl>(entity =>
        {
            entity.Property(p => p.ShortId)
                  .IsRequired()
                  .HasMaxLength(10)
                  .UseCollation("SQL_Latin1_General_CP1_CS_AS"); // case-sensitive collation
        });
    }
}