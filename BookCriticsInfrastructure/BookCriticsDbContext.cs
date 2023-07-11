using BookCriticsDomain.Enums;
using BookCriticsDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCriticsInfrastructure;

public class BookCriticsDbContext : DbContext
{
    public BookCriticsDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }

    public DbSet<Rating> Ratings { get; set; }

    public DbSet<Review> Reviews { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public DbSet<BookInGenre> BookInGenres { get; set; }

    public DbSet<UserInRole> UserInRoles { get; set; }

    public DbSet<UserLikedBook> UserLikedBooks { get; set; }

    public DbSet<UserLikedReview> UserLikedReviews { get; set; }

    public DbSet<Role> Roles { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Genre>().HasData(Enum.GetValues(typeof(GenresEnum)).Cast<GenresEnum>().Select(e => new Genre
        {
            GenreId = (short)e + 1,
            GenreName = e.ToString()
        }));

        builder.Entity<Role>().HasData(Enum.GetValues(typeof(Roles)).Cast<Roles>().Select(e => new Role
        {
            Id = (short)e + 1,
            RoleName = e.ToString()
        }));

        builder.Entity<BookInGenre>().HasKey(e => new { e.GenreId, e.BookId });
        builder.Entity<Rating>().HasKey(e => new { e.UserId, e.BookId });
        builder.Entity<UserInRole>().HasKey(e => new { e.UserId, e.RoleId });
        builder.Entity<UserLikedBook>().HasKey(e => new { e.UserId, e.BookId });
        builder.Entity<UserLikedReview>().HasKey(e => new { e.UserId, e.ReviewId });
    }
}
