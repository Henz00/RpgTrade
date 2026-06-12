using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpgTrade.Domain;

namespace RpgTrade.Infrastructure.Persistence.Configurations
{
    public class ItemModifierConfiguration : IEntityTypeConfiguration<ItemModifier>
    {
        public void Configure(EntityTypeBuilder<ItemModifier> builder)
        {
            builder.ToTable("ItemModifiers");

            builder.HasKey(modifier => modifier.Id);

            builder.Property(modifier => modifier.Value)
                .IsRequired();

            builder.HasOne(modifier => modifier.Definition)
                .WithMany()
                .HasForeignKey(modifier => modifier.ModifierDefinitionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
