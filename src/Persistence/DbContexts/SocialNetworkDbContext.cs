using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.DbContexts;

public class SocialNetworkDbContext : DbContext
{
    public SocialNetworkDbContext(DbContextOptions<SocialNetworkDbContext> options) : base(options)
    {

    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Connection> Connections { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Account>(e =>
        {
            e.HasKey(a => a.Id);

            e.HasOne(a => a.Profile)
            .WithOne(p => p.Account)
            .HasForeignKey<Profile>(p => p.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Profile>(e =>
        {
            e.HasKey(p => p.Id);

            // Value Object mapping
            e.OwnsOne(p => p.Location, l =>
            {
                l.Property(l => l.City).HasColumnName("City");
                l.Property(l => l.Country).HasColumnName("Country");
            });

            e.HasMany(p => p.Posts)
            .WithOne(p => p.Profile)
            .HasForeignKey(p => p.ProfileId)
            .OnDelete(DeleteBehavior.Restrict);

            e.HasMany(p => p.Followers)
            .WithOne(p => p.ProfileFollower)
            .HasForeignKey(p => p.ProfileIdFollower)
            .OnDelete(DeleteBehavior.Restrict);

            e.HasMany(p => p.Following)
            .WithOne(p => p.ProfileFollowing)
            .HasForeignKey(p => p.ProfileIdFollowing)
            .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Post>(e =>
        {
            e.HasKey(p => p.Id);

            // Value Object mapping
            e.OwnsOne(p => p.Location, l =>
            {
                l.Property(l => l.City).HasColumnName("City");
                l.Property(l => l.Country).HasColumnName("Country");
            });
        });

        builder.Entity<Connection>(e =>
        {
            e.HasKey(p => new { p.ProfileIdFollowing, p.ProfileIdFollower });

        });

        base.OnModelCreating(builder);
    }
}
