using BiEsPro.Data.Common.Models;
using BiEsPro.Data.Models;
using BiEsPro.Data.Models.ClientElements;
using BiEsPro.Data.Models.FluentAPIModelConfigurations;
using BiEsPro.Data.Models.ItemElements;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace BiEsPro.Data
{
    public class BiEsProDbContext : IdentityDbContext<BiEsProUser>
    {
        public BiEsProDbContext()
        {
        }
        public BiEsProDbContext(DbContextOptions<BiEsProDbContext> options) : base(options)
        {
        }

        public DbSet<BiEsProUser> MyProperty { get; set; }

        // DbSets for Items
        public DbSet<Color> Colors { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }

        // DbSets for ClientCompanies
        public DbSet<City> Cities { get; set; }
        public DbSet<VatSufix> VatSufixes { get; set; }
        public DbSet<ClientCompany> ClientCompanies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ItemConfig());
            builder.ApplyConfiguration(new ClientCompanyConfig());

            base.OnModelCreating(builder);
        }
        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
