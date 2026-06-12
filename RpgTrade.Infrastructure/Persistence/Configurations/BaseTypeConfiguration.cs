using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpgTrade.Domain;

namespace RpgTrade.Infrastructure.Persistence.Configurations
{
    public class BaseTypeConfiguration : IEntityTypeConfiguration<BaseType>
    {
        public void Configure(EntityTypeBuilder<BaseType> builder)
        {
            builder.ToTable("BaseTypes");

            builder.HasKey(baseType => baseType.Id);

            builder.Property(baseType => baseType.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(baseType => baseType.ItemClass)
                .WithMany()
                .HasForeignKey(baseType => baseType.ItemClassId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
