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
app.AddIdentityApis();
app.Run();