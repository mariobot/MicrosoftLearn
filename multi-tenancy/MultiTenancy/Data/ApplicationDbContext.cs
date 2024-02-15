using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultiTenancy.Entities;
using MultiTenancy.Services;
using System.Linq.Expressions;
using System.Reflection;

namespace MultiTenancy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private string tenantId;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IServiceTenant serviceTenant)
            : base(options)
        {
            tenantId = serviceTenant.GetTenant();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var entity in builder.Model.GetEntityTypes())
            {
                var typeData = entity.ClrType;

                if (typeof(IEntityTenant).IsAssignableFrom(typeData))
                {
                    // build the filter
                    var method = typeof(ApplicationDbContext)
                        .GetMethod(nameof(BuildGlobalFilterTenant), BindingFlags.NonPublic | BindingFlags.Static)
                        ?.MakeGenericMethod(typeData);

                    var filter = method?.Invoke(null, new object[] { this })!;

                    entity.SetQueryFilter((LambdaExpression)filter);
                    entity.AddIndex(entity.FindProperty(nameof(IEntityTenant.TenantId))!);
                }
                else if(typeData.JumpTenantValidation())
                {
                    continue;
                }
                else
                {
                    throw new Exception($"The entity has not been created with IEntityTenant or ICommonEntity");
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries().Where(e => e.State == EntityState.Added && e.Entity is IEntityTenant))
            {
                if (string.IsNullOrEmpty(tenantId))
                {
                    throw new Exception("TenantId not found when record was created");
                }

                var entity = item.Entity as IEntityTenant;
                entity!.TenantId = tenantId;
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        private static LambdaExpression BuildGlobalFilterTenant<TEntity>(
            ApplicationDbContext context) where TEntity: class, IEntityTenant
        {
            Expression<Func<TEntity, bool>> filter = x => x.TenantId == context.tenantId;

            return filter;
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Country> Countries => Set<Country>();
    }
}