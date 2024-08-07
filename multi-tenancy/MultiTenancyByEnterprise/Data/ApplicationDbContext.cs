﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultiTenancyByEnterprise.Entities;
using MultiTenancyByEnterprise.Services;
using System.Linq.Expressions;
using System.Reflection;

namespace MultiTenancyByEnterprise.Data
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
            //System.Diagnostics.Debugger.Launch();

            base.OnModelCreating(builder);

            builder.Entity<EnterpriseUserPermission>()
                .HasKey(x => new { x.EnterpriseId, x.UserId, x.Permission});



            builder.Entity<Country>().HasData(new Country[] {
                new Country{ Id = 1, Name = "Canada" },
                new Country{ Id = 2, Name = "USA" },
                new Country{ Id = 3, Name = "Mexico" },
            });

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
                    throw new Exception($"The {entity.Name} entity has not been created with IEntityTenant or ICommonEntity");
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
        public DbSet<Enterprise> Enterprise => Set<Enterprise>();
        public DbSet<EnterpriseUserPermission> EnterpriseUserPermissions => Set<EnterpriseUserPermission>();
        public DbSet<Link> Links => Set<Link>();

    }
}