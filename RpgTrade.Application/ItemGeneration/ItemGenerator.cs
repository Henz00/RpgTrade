using RpgTrade.Domain;

namespace RpgTrade.Application.ItemGeneration
{
    public static class ItemGenerator
    {
        public static Item Generate(int seed, ItemRarity rarity)
        {
            var random = new Random(seed);

            var baseType = PickRandomFromList(random, StaticGameData.BaseTypes);

            var item = new Item
            {
                Id = Guid.NewGuid(),
                Name = GenerateName(random),
                Rarity = rarity,
                ItemLevel = random.Next(1, 101),
                BaseTypeId = baseType.Id,
                BaseType = baseType
            };

            int modifierCount = GetModifierCount(random, rarity);

            var validModifiers = StaticGameData.ModifierDefinitions
                .Where(modifier => modifier.AllowedItemClasses.Any(itemClass =>
                    itemClass.Id == baseType.ItemClass.Id))
                .ToList();

            var selectedModifiers = validModifiers
                .OrderBy(_ => random.Next())
                .Take(modifierCount)
                .ToList();

            foreach (var modifierDefinition in selectedModifiers)
            {
                item.Modifiers.Add(new ItemModifier
                {
                    Id = Guid.NewGuid(),
                    ItemId = item.Id,
                    ModifierDefinitionId = modifierDefinition.Id,
                    Definition = modifierDefinition,
                    Value = RollModifierValue(random, modifierDefinition)
                });
            }

            return item;
        }

        private static string GenerateName(Random random)
        {
            var prefix = PickRandomFromList(random, StaticGameData.NamePrefixes);
            var suffix = PickRandomFromList(random, StaticGameData.NameSuffixes);

            return $"{prefix} {suffix}";
        }

        private static int GetModifierCount(Random random, ItemRarity rarity)
        {
            return rarity switch
            {
                ItemRarity.Normal => 0,
                ItemRarity.Magic => random.Next(1, 3), // 1-2
                ItemRarity.Rare => random.Next(3, 7),  // 3-6
                _ => throw new ArgumentOutOfRangeException(nameof(rarity), rarity, "Unsupported item rarity")
            };
        }

        private static double RollModifierValue(Random random, ModifierDefinition modifierDefinition)
        {
            var value = random.NextDouble() * (modifierDefinition.MaxValue - modifierDefinition.MinValue)
                        + modifierDefinition.MinValue;

            return Math.Round(value, 0);
        }

        private static T PickRandomFromList<T>(Random random, List<T> list)
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Cannot pick from an empty list.");
            }

            return list[random.Next(list.Count)];
        }
    }
}
