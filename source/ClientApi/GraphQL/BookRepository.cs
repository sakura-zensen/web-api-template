namespace ClientApi.GraphQL;

public class BookRepository
{
    private readonly List<Book> _books = [];
    private readonly List<Author> _authors = [];

    public BookRepository()
    {
        // Initialize with sample data
        var author1 = new Author { Name = "J.K. Rowling", Biography = "British author" };
        var author2 = new Author { Name = "George R.R. Martin", Biography = "American novelist" };
        var author3 = new Author { Name = "J.R.R. Tolkien", Biography = "English writer" };
        var author4 = new Author { Name = "Isaac Asimov", Biography = "American author and professor" };
        var author5 = new Author { Name = "Agatha Christie", Biography = "British detective novelist" };

        var book1 = new Book { Title = "Harry Potter", Author = author1 };
        var book2 = new Book { Title = "A Game of Thrones", Author = author2 };
        var book3 = new Book { Title = "The Hobbit", Author = author3 };
        var book4 = new Book { Title = "Foundation", Author = author4 };
        var book5 = new Book { Title = "I, Robot", Author = author5 };

        _authors.AddRange([author1, author2, author3, author4, author5]);
        _books.AddRange([book1, book2, book3, book4, book5]);
    }

    public IQueryable<Book> GetBooks() => _books.AsQueryable();

    public Book? GetBook(string title) =>
        _books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

    public List<Author> GetAuthors() => _authors;

    public Book AddBook(string title, string authorName)
    {
        var author = _authors.FirstOrDefault(a => a.Name == authorName)
                   ?? new Author { Name = authorName };

        var newBook = new Book { Title = title, Author = author };
        _books.Add(newBook);

        if (!_authors.Contains(author))
            _authors.Add(author);

        return newBook;
    }
}