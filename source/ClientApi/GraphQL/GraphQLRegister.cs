using ClientApi.GraphQL.GraphQLResolvers;

namespace ClientApi.GraphQL;

public static partial class GraphQLRegister
{
    public static void RegisterGraphQLServerSchemaAndResolvers(this IServiceCollection services)
    {
        var graphqlServer = services.AddGraphQLServer()
                                    .AddDocumentFromString(ClientGraphQLSchema.GetSchema());

        services.AddSingleton<BookRepository>();

        graphqlServer.RegisterBookResolver();
    }
}
