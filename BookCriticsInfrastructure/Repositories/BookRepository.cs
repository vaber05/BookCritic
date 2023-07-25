using BookCriticsApplication.Abstractions;
using BookCriticsDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCriticsInfrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookCriticsDbContext context;

    public BookRepository(BookCriticsDbContext context)
    {
        this.context = context;
    }

    public async Task<Book> CreateBook(Book newBook)
    {
        newBook.DateAdded = DateTime.Now;

        await context.Books.AddAsync(newBook);
        await context.SaveChangesAsync();

        return newBook;
    }

    public async Task DeleteBook(int bookId)
    {
        var bookToDelete = await context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

        if (bookToDelete is null)
            return;

        foreach (var review in context.Reviews.Where(r => r.BookId == bookId).ToList())
        {
            await context.UserLikedReviews.Where(ulr => ulr.ReviewId == review.Id).ExecuteDeleteAsync();
        }
        await context.Ratings.Where(r => r.BookId == bookId).ExecuteDeleteAsync();
        await context.UserLikedBooks.Where(ulb => ulb.BookId == bookId).ExecuteDeleteAsync();
        await context.Ratings.Where(r => r.BookId == bookId).ExecuteDeleteAsync();

        context.Books.Remove(bookToDelete);

        await context.SaveChangesAsync();
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await context.Books.Include(b => b.Genres)
                                  .Include(b => b.Reviews)
                                  .Include(b => b.Ratings)
                                  .Include(b => b.LikedByUsers).ToListAsync();
    }

    public async Task<Book> GetBookById(int bookId)
    {
        var book = await context.Books.Include(b => b.Genres)
                                      .Include(b => b.Reviews)
                                      .Include(b => b.Ratings)
                                      .Include(b => b.LikedByUsers).FirstOrDefaultAsync(b => b.Id == bookId);

        return book ?? throw new NullReferenceException(message: "This book does not exist");
    }

    public async Task<Book> UpdateBook(Book newBook)
    {
        context.ChangeTracker.Clear();

        context.Books.Update(newBook);
        await context.SaveChangesAsync();

        return newBook;
    }

    public async Task AddBookToGenre(int bookId, int genreId)
    {
        await context.BookInGenres.AddAsync(new BookInGenre
        {
            BookId = bookId,
            GenreId = genreId
        });

        await context.SaveChangesAsync();
    }

    public async Task RemoveBookFromGenre(int bookId, int genreId)
    {
        context.BookInGenres.Remove(new BookInGenre
        {
            BookId = bookId,
            GenreId = genreId
        });

        await context.SaveChangesAsync();
    }

    public async Task UpdateBookGenres(int bookId, int oldGenreId, int newGenreId)
    {
        context.ChangeTracker.Clear();

        await context.BookInGenres.AddAsync(new BookInGenre
        {
            BookId = bookId,
            GenreId = newGenreId
        });

        context.BookInGenres.Remove(new BookInGenre
        {
            BookId = bookId,
            GenreId = oldGenreId
        });

        await context.SaveChangesAsync();
    }
}
