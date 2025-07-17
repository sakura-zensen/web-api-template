namespace ClientApi.GraphQL;

public class Book
{
    public string Title { get; set; }
    public Author Author { get; set; }
}

public class Author
{
    public string Name { get; set; }
    public string Biography { get; set; }
}

public class QueryResolver
{
    public Book[] GetBook() =>
        [
        new()
        {
            Title = "C# in depth.",
            Author = new Author
            {
                Name = "Jon Skeet",
                Biography = "Native"
            }
        }];
}


