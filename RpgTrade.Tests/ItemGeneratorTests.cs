using RpgTrade.Application.ItemGeneration;
using RpgTrade.Domain;

namespace RpgTrade.Tests
{
    public class ItemGeneratorTests
    {
        [Fact]
        public void Generate_RareItems_AlwaysHaveValidModifierCount()
        {
            // Arrange
            for (int seed = 0; seed < 10_000; seed++)
            {
                // Act
                Item item = ItemGenerator.Generate(seed, ItemRarity.Rare);

                // Assert
                Assert.InRange(item.Modifiers.Count, 3, 6);
            }
        }

        [Fact]
        public void Generate_MagicItem_AlwaysHaveValidModifierCount()
        {
            // Arrange
            for (int seed = 0; seed < 10_000; seed++)
            {
                // Act
                Item item = ItemGenerator.Generate(12345, ItemRarity.Magic);

                // Assert
                Assert.InRange(item.Modifiers.Count, 1, 2);
            }
            
        }

        [Fact]
        public void Generate_NormalItem_HasNoModifiers()
        {
            // Arrange
            for (int seed = 0; seed < 10_000; seed++)
            {
                // Act
                Item item = ItemGenerator.Generate(12345, ItemRarity.Normal);

                // Assert
                Assert.Empty(item.Modifiers);
            }
        }

        [Fact]
        public void Generate_Items_OnlyUsesModifiersAllowedForBaseItemClass()
        {
            // Arrange
            for (int seed = 0; seed < 10_000; seed++)
            {
                // Act
                Item item = ItemGenerator.Generate(seed, ItemRarity.Rare);

                foreach (var modifier in item.Modifiers)
                {
                    bool isAllowed = modifier.Definition.AllowedItemClasses
                        .Any(itemClass => itemClass.Id == item.BaseType.ItemClass.Id);

                    // Assert
                    Assert.True(isAllowed);
                }
            }
        }
    }
}
