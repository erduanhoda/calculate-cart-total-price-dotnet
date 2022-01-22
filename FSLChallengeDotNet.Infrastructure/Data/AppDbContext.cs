using System;
using System.Threading;
using System.Threading.Tasks;
using FSLChallengeDotNet.Core;
using FSLChallengeDotNet.Core.Entities;
using FSLChallengeDotNet.Infrastructure.Data.Configs;
using Microsoft.EntityFrameworkCore;

namespace FSLChallengeDotNet.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemDiscountRule> ItemDiscountRule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CartEntityTypeConfiguration().Configure(modelBuilder.Entity<Cart>());
            new CartItemEntityTypeConfiguration().Configure(modelBuilder.Entity<CartItem>());
            new ItemEntityTypeConfiguration().Configure(modelBuilder.Entity<Item>());
            new ItemDiscountRuleEntityTypeConfiguration().Configure(modelBuilder.Entity<ItemDiscountRule>());
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected virtual void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
                switch (entry.State)
                {
                    case EntityState.Added when entry.Entity is BaseEntity:
                        entry.Property(nameof(BaseEntity.CreatedAt)).CurrentValue = DateTimeOffset.Now;
                        entry.Property(nameof(BaseEntity.CreatedBy)).CurrentValue = new Guid("f6890d95-5ad4-4efb-84dc-4b19ebdc15ed"); // hard coded ID just for demonstration purposes
                        break;

                    case EntityState.Modified when entry.Entity is BaseEntity:
                        entry.Property(nameof(BaseEntity.UpdatedAt)).CurrentValue = DateTimeOffset.Now;
                        entry.Property(nameof(BaseEntity.UpdatedBy)).CurrentValue = new Guid("f6890d95-5ad4-4efb-84dc-4b19ebdc15ed"); // hard coded ID just for demonstration purposes
                        break;
                }
        }
    }
}