using Microsoft.EntityFrameworkCore;
using GamesList.Models;

namespace GamesList.Data;

public class GameContext : DbContext
{
    public DbSet<Game> Games{ get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<GameTags> GameTags { get; set; }

    public GameContext(DbContextOptions<GameContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<GameTags>().HasKey(gt => new
        {
            gt.GameId,
            gt.TagId
        });

        builder.Entity<GameTags>()
            .HasOne(g => g.Game)
            .WithMany(gt => gt.GameTags)
            .HasForeignKey(g => g.GameId);
        builder.Entity<GameTags>()
            .HasOne(t => t.Tag)
            .WithMany(gt => gt.GameTags)
            .HasForeignKey(t => t.TagId);

        builder.Entity<Game>().HasData(
            new Game {Id = 1, Title="Genshin Impact", 
            Description = "Step into vast magical world of Adventure", 
            ImageUri = "https://variety.com/wp-content/uploads/2022/09/Genshin-Impact-Anime-Series-Concept.png", 
            Rating = 6, 
            ReleaseTime = new DateOnly(2020, 9, 28),
            PlayingSinceTime = new DateOnly(2021, 3, 31)});
        builder.Entity<Tag>().HasData(
            new Tag {Id = 1, Name = "RPG"},
            new Tag {Id = 2, Name = "cozy"}
        );
        builder.Entity<GameTags>().HasData(
            new GameTags{GameId = 1, TagId = 1},
            new GameTags{GameId = 1, TagId = 2}
        );

        base.OnModelCreating(builder);
    }
}