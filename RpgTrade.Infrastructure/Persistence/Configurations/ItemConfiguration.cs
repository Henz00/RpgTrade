using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpgTrade.Domain;

namespace RpgTrade.Infrastructure.Persistence.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.ToTable("Items");

        builder.HasKey(item => item.Id);

        builder.Property(item => item.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(item => item.Rarity)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(item => item.ItemLevel)
            .IsRequired();

        builder.HasOne(item => item.BaseType)
            .WithMany()
            .HasForeignKey(item => item.BaseTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(item => item.Modifiers)
            .WithOne()
            .HasForeignKey(modifier => modifier.ItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}