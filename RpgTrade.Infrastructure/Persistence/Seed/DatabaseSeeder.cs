using Microsoft.EntityFrameworkCore;
using RpgTrade.Application.ItemGeneration;
using RpgTrade.Domain;

namespace RpgTrade.Infrastructure.Persistence.Seed
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(AppDbContext dbContext)
        {
            await SeedReferenceDataAsync(dbContext);
        }

        private static async Task SeedReferenceDataAsync(AppDbContext dbContext)
        {
            await SeedItemClassesAsync(dbContext);
            await SeedBaseTypesAsync(dbContext);
            await SeedModifierDefinitionsAsync(dbContext);
            await SeedAllowedItemClassRelationsAsync(dbContext);
        }

        private static async Task SeedItemClassesAsync(AppDbContext dbContext)
        {
            foreach (var staticItemClass in StaticGameData.ItemClasses)
            {
                bool exists = await dbContext.ItemClasses
                    .AnyAsync(itemClass => itemClass.Id == staticItemClass.Id);

                if (exists)
                {
                    continue;
                }

                dbContext.ItemClasses.Add(new ItemClass
                {
                    Id = staticItemClass.Id,
                    Name = staticItemClass.Name
                });
            }

            await dbContext.SaveChangesAsync();
        }

        private static async Task SeedBaseTypesAsync(AppDbContext dbContext)
        {
            foreach (var staticBaseType in StaticGameData.BaseTypes)
            {
                bool exists = await dbContext.BaseTypes
                    .AnyAsync(baseType => baseType.Id == staticBaseType.Id);

                if (exists)
                {
                    continue;
                }

                dbContext.BaseTypes.Add(new BaseType
                {
                    Id = staticBaseType.Id,
                    Name = staticBaseType.Name,
                    ItemClassId = staticBaseType.ItemClassId
                });
            }

            await dbContext.SaveChangesAsync();
        }

        private static async Task SeedModifierDefinitionsAsync(AppDbContext dbContext)
        {
            foreach (var staticModifierDefinition in StaticGameData.ModifierDefinitions)
            {
                bool exists = await dbContext.ModifierDefinitions
                    .AnyAsync(modifierDefinition => modifierDefinition.Id == staticModifierDefinition.Id);

                if (exists)
                {
                    continue;
                }

                dbContext.ModifierDefinitions.Add(new ModifierDefinition
                {
                    Id = staticModifierDefinition.Id,
                    Name = staticModifierDefinition.Name,
                    MinValue = staticModifierDefinition.MinValue,
                    MaxValue = staticModifierDefinition.MaxValue
                });
            }

            await dbContext.SaveChangesAsync();
        }

        private static async Task SeedAllowedItemClassRelationsAsync(AppDbContext dbContext)
        {
            foreach (var staticModifierDefinition in StaticGameData.ModifierDefinitions)
            {
                var databaseModifierDefinition = await dbContext.ModifierDefinitions
                    .Include(modifierDefinition => modifierDefinition.AllowedItemClasses)
                    .FirstAsync(modifierDefinition => modifierDefinition.Id == staticModifierDefinition.Id);

                foreach (var allowedItemClass in staticModifierDefinition.AllowedItemClasses)
                {
                    bool relationExists = databaseModifierDefinition.AllowedItemClasses
                        .Any(itemClass => itemClass.Id == allowedItemClass.Id);

                    if (relationExists)
                    {
                        continue;
                    }

                    var databaseItemClass = await dbContext.ItemClasses
                        .FirstAsync(itemClass => itemClass.Id == allowedItemClass.Id);

                    databaseModifierDefinition.AllowedItemClasses.Add(databaseItemClass);
                }
            }

            await dbContext.SaveChangesAsync();
        }
    }
}