namespace ClientApi.GraphQL;

public class ClientGraphQLSchema
{
    public static string GetSchema() =>
        @"
            type Query {
                books: [Book!]!
                book(title: String!): Book
                authors: [Author!]!
            }

            type Book {
                title: String!
                author: Author!
            }

            type Author {
                name: String!
                biography: String
            }
        ";
}
