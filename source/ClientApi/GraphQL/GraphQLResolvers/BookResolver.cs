using HotChocolate.Execution.Configuration;

namespace ClientApi.GraphQL.GraphQLResolvers;

public static partial class BookResolver
{
    public static IRequestExecutorBuilder RegisterBookResolver(this IRequestExecutorBuilder builder) =>
        builder.AddResolver("test"  , "123" , x => { return Task.CompletedTask; })
               .AddResolver("Query" , "abc" , x  => { return Task.CompletedTask; });
}
