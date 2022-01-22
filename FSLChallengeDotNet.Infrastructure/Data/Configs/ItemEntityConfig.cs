using FSLChallengeDotNet.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSLChallengeDotNet.Infrastructure.Data.Configs
{
    public class ItemEntityTypeConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SKU).IsRequired().HasMaxLength(150);
            builder.Property(x => x.UnitPrice);

            builder.HasOne(x => x.DiscountRule)
                   .WithOne(x => x.Item)
                   .HasForeignKey<ItemDiscountRule>(x => x.ItemId);

            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.UpdatedBy);

            builder.Navigation(x => x.DiscountRule).AutoInclude();
        }
    }
}