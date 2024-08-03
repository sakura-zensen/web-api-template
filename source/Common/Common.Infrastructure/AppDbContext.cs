using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure
{
    public abstract class BaseDbContext<TContext>(DbContextOptions<TContext> options) : IdentityDbContext(options) where TContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var entityTypes = builder.Model.GetEntityTypes().
                                SelectMany(t => t.GetProperties()).
                                Where(p => (Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            foreach (var property in entityTypes)
            {
                property.SetPrecision(19);
                property.SetScale(4);
            }
        }
    }
    public class AppDbContext(DbContextOptions<AppDbContext> options) : BaseDbContext<AppDbContext>(options)
    {

    }
}
