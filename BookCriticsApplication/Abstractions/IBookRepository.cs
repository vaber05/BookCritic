using BookCriticsDomain.Models;

namespace BookCriticsApplication.Abstractions;

public interface IBookRepository
{
    Task<Book> CreateBook(Book newBook);

    Task<Book> UpdateBook(Book newBook);

    Task DeleteBook(int bookId);

    Task<Book> GetBookById(int bookId);

    Task<List<Book>> GetAllBooks();

    Task AddBookToGenre(int bookId, int genreId);

    Task RemoveBookFromGenre(int bookId, int genreId);

    Task UpdateBookGenres(int bookId, int oldGenreId, int newGenreId);
}
