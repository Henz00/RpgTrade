using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RpgTrade.Domain;

namespace RpgTrade.Infrastructure.Persistence.Configurations
{
    public class ModifierDefinitionConfiguration : IEntityTypeConfiguration<ModifierDefinition>
    {
        public void Configure(EntityTypeBuilder<ModifierDefinition> builder)
        {
            builder.ToTable("ModifierDefinitions");

            builder.HasKey(modifierDefinition => modifierDefinition.Id);

            builder.Property(modiferDefinition => modiferDefinition.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(modiferDefinition => modiferDefinition.MinValue)
                .IsRequired();

            builder.Property(modiferDefinition => modiferDefinition.MaxValue)
                .IsRequired();

            builder.HasMany(modifierDefinition => modifierDefinition.AllowedItemClasses)
                .WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "ModifierDefinitionItemClasses",
                    right => right
                        .HasOne<ItemClass>()
                        .WithMany()
                        .HasForeignKey("ItemClassId")
                        .OnDelete(DeleteBehavior.Restrict),
                    left => left
                        .HasOne<ModifierDefinition>()
                        .WithMany()
                        .HasForeignKey("ModifierDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade),
                    join =>
                    {
                        join.HasKey("ModifierDefinitionId", "ItemClassId");
                        join.ToTable("ModifierDefinitionItemClasses");
                    }
                );
        }
    }
}
