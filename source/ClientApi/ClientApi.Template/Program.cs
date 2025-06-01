using Common.Infrastructure;
using Common.Infrastructure.Entities;
using Common.Services;
using Common.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen()
                .RegisterServiceDependencies(builder.Configuration)
                .AddJwtAuthentication(builder.Configuration)
                .AddAllOriginCors()
                .AddAppDbContext(builder.Configuration)
                .AddIdentityApiEndpoints<AppUser>().AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigin");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
/*
     Add custom identity user roles by default
     This is a one-time setup, you can remove this line after the roles are created or really necessary, 
     or you can keep it to ensure roles are always available in the database.
     or you may use role endpoints to manage roles dynamically.
*/
// await app.AddCustomIdentityUserRoles();
app.AddIdentityApis();
app.Run();