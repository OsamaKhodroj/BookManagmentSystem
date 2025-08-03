using LibrarySystem.Models.Entities;
using LibrarySystem.Models.Enums;
using LibrarySystem.Models.Interfaces;

namespace LibrarySystem.Services;

public class BookService : IBook, IDisposable
{
    private List<Book>? _books;

    public BookService()
    {
        if (_books == null)
            _books = new List<Book>();
    }

    /// <summary>
    /// This Method is used to add a new book to the collection.
    /// </summary>
    /// <param name="book">set book object param</param>
    /// <returns>retrun OpStatusEnum enum</returns> 
    public OpStatusEnum Add(Book book)
    {
        try
        {
            IsBookValid(book);
            _books?.Add(book);
            return OpStatusEnum.Success;
        }
        catch (Exception)
        {
            return OpStatusEnum.InternalServerError;
        }
    }

    /// <summary>
    /// this method is used to delete a book from the collection by its ID.
    /// </summary>
    /// <param name="id">set book id - int value</param>
    /// <returns>retrun OpStatusEnum enum</returns>  
    public OpStatusEnum Delete(int id)
    {
        try
        {
            if (id <= 0)
                return OpStatusEnum.InvalidInput;

            var book = _books?.FirstOrDefault(b => b.Id == id);
            if (book == null)
                return OpStatusEnum.NotFound;

            _books?.Remove(book);
            return OpStatusEnum.Success;

        }
        catch (Exception)
        {
            return OpStatusEnum.InternalServerError;
        }

    }

    /// <summary>
    /// this method is used to get all books from the collection.
    /// </summary>
    /// <returns>rerun all book list</returns>
    /// <exception cref="NotImplementedException"></exception>
    public List<Book> GetAll()
    {
        try
        {
            return _books.ToList();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    /// <summary>
    /// this method is used to get a book by its ID.
    /// </summary>
    /// <param name="id">set book id - int value</param>
    /// <returns>retrun book object</returns> 
    public Book GetById(int id)
    {
        try
        {
            if (id <= 0)
                return new Book();

            var book = _books?.FirstOrDefault(b => b.Id == id);
            return book ?? new Book();

        }
        catch (Exception)
        {

            throw;
        }
    }

    /// <summary>
    /// this method is used to update an existing book in the collection.
    /// </summary>
    /// <param name="book">set book object param</param>
    /// <returns>retrun OpStatusEnum enum</returns>  
    public OpStatusEnum Update(Book book)
    {
        try
        {
            var existBook = _books.FirstOrDefault(q => q.Id == book.Id);
            if (existBook == null)
                return OpStatusEnum.NotFound;

            existBook.UpdatedAt = DateTime.UtcNow;
            existBook.CreatedAt = book.CreatedAt; 
            existBook.CreatedBy = book.CreatedBy; 
            existBook.UpdatedBy = book.UpdatedBy; 
            existBook.Name = book.Name;
            existBook.Author = book.Author;
            existBook.ISBN = book.ISBN;
            existBook.Category = book.Category;
            existBook.BookStatus = book.BookStatus;

            return OpStatusEnum.Success;
        }
        catch (Exception)
        {
            throw;
        }
    }


    public void Dispose()
    {
        _books?.Clear();
        _books = null;
    }

    private bool IsBookValid(Book book)
    {
        if (book == null)
            throw new ArgumentNullException(nameof(book), "Book cannot be null");
        if (string.IsNullOrWhiteSpace(book.Name))
            throw new ArgumentException("Book title is required", nameof(book));
        if (string.IsNullOrWhiteSpace(book.Author))
            throw new ArgumentException("Book author is required", nameof(book));

        var isBookExists = _books?.Any(b => b.Name == book.Name && b.Author == book.Author);
        if (isBookExists == true)
            throw new InvalidOperationException("This book already exists in the collection");

        return true;
    }
}
