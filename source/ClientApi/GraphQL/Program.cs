using ClientApi.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<BookRepository>();

builder.Services.RegisterGraphQLServerSchemaAndResolvers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHttpsRedirection();

app.UseRouting().UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL("/api/v2/graphql"); // schema endpoint for GraphQL
    endpoints.MapNitroApp(toolPath: "/graphql/ui"); // Nitro app for GraphQL playground
});

app.Run();