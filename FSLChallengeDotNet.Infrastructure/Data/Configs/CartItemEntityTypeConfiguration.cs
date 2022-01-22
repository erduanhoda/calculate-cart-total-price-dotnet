using FSLChallengeDotNet.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSLChallengeDotNet.Infrastructure.Data.Configs
{
    public class CartItemEntityTypeConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity);

            builder.HasOne(x => x.Item)
                   .WithMany(x => x.CartItems)
                   .HasForeignKey(x => x.ItemId);

            builder.HasOne(x => x.Cart)
                   .WithMany(x => x.CartItems)
                   .HasForeignKey(x => x.CartId);

            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.UpdatedBy);

            builder.Navigation(x => x.Item).AutoInclude();
        }
    }
}
