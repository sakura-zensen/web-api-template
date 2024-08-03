using Common.Infrastructure;
using Common.Infrastructure.Entities;
using Common.Services;
using Common.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServiceDependencies(builder.Configuration);
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAllOriginCors();

// Serves from Identity Core.
builder.Services.AddIdentityApiEndpoints<AppUser>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddAppDbContext(builder.Configuration);

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