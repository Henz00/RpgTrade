using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpgTrade.Domain;

namespace RpgTrade.Infrastructure.Persistence.Configurations
{
    public class ItemClassConfiguration : IEntityTypeConfiguration<ItemClass>
    {
        public void Configure(EntityTypeBuilder<ItemClass> builder)
        {
            builder.ToTable("ItemClasses");

            builder.HasKey(itemClass => itemClass.Id);

            builder.Property(itemClass => itemClass.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
