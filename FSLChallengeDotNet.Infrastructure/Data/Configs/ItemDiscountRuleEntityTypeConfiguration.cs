using FSLChallengeDotNet.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FSLChallengeDotNet.Infrastructure.Data.Configs
{
    public class ItemDiscountRuleEntityTypeConfiguration : IEntityTypeConfiguration<ItemDiscountRule>
    {
        public void Configure(EntityTypeBuilder<ItemDiscountRule> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity);
            builder.Property(x => x.Price);

            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.CreatedBy);
            builder.Property(x => x.UpdatedAt);
            builder.Property(x => x.UpdatedBy);
        }
    }
}
