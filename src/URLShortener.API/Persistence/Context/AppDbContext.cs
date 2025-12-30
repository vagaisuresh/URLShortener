using Microsoft.EntityFrameworkCore;
using URLShortener.API.Domain.Entities;

namespace URLShortener.API.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) 
        : base(options)
    {
    }

    public DbSet<ShortUrl> ShortUrls { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ShortUrl>(entity =>
        {
            entity.Property(p => p.ShortId)
                .IsRequired()
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CS_AS"); // case-sensitive collation
        });
    }
}