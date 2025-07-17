using HotChocolate.Execution.Configuration;

namespace ClientApi.GraphQL.GraphQLResolvers;

public static partial class BookResolver
{
    public static IRequestExecutorBuilder RegisterBookResolver(this IRequestExecutorBuilder builder) =>
        builder
.AddResolver("Query", "books", (BookQueryResolvers q) => q.GetBooks(default!).ToList())
        
                .AddResolver("Query", "book", (BookQueryResolvers q, string title) => q.GetBook(title, default!))
                .AddResolver("Query", "authors", (BookQueryResolvers q) => q.GetAuthors(default!))
                // Book fields
                .AddResolver("Book", "title", (Book b) => b.Title)
                .AddResolver("Book", "author", (Book b) => b.Author)

                // Author fields
                .AddResolver("Author", "name", (Author a) => a.Name)
                .AddResolver("Author", "biography", (Author a) => a.Biography);
}

public class BookQueryResolvers
{
    public IQueryable<Book> GetBooks([Service] BookRepository repository)
        => repository.GetBooks();

    public Book? GetBook(string title, [Service] BookRepository repository)
        => repository.GetBook(title);

    public List<Author> GetAuthors([Service] BookRepository repository)
        => repository.GetAuthors();
}