using RpgTrade.Domain;

namespace RpgTrade.Application.ItemGeneration
{
    public static class StaticGameData
    {
        public static List<ItemClass> ItemClasses = [
            new ItemClass { Id = 1, Name = "Sword" },
            new ItemClass { Id = 2, Name = "Axe" },
            new ItemClass { Id = 3, Name = "Helmet" },
            new ItemClass { Id = 4, Name = "Ring" }
        ];

        public static List<BaseType> BaseTypes = [
            new BaseType {
                Id = 1,
                Name = "Iron Sword",
                ItemClassId = 1,
                ItemClass = ItemClasses[0]
            },
            new BaseType {
                Id = 2,
                Name = "Steel Sword",
                ItemClassId = 1,
                ItemClass = ItemClasses[0]
            },
            new BaseType {
                Id = 3,
                Name = "War Axe",
                ItemClassId = 2,
                ItemClass = ItemClasses[1]
            },
            new BaseType {
                Id = 4,
                Name = "Iron Helmet",
                ItemClassId = 3,
                ItemClass = ItemClasses[2]
            },
            new BaseType {
                Id = 5,
                Name = "Gold Ring",
                ItemClassId = 4,
                ItemClass = ItemClasses[3]
            },
            new BaseType {
                Id = 6,
                Name = "Iron Ring",
                ItemClassId = 4,
                ItemClass = ItemClasses[3]
            }
        ];

        public static List<ModifierDefinition> ModifierDefinitions = [
            new ModifierDefinition {
                Id = 1,
                Name = "Maximum Life",
                MinValue = 1,
                MaxValue = 100,
                AllowedItemClasses = [ItemClasses[0], ItemClasses[1], ItemClasses[2], ItemClasses[3]]
            },
            new ModifierDefinition {
                Id = 2,
                Name = "Fire Resistance",
                MinValue = 1,
                MaxValue = 50,
                AllowedItemClasses = [ItemClasses[0], ItemClasses[1], ItemClasses[2], ItemClasses[3]]
            },
            new ModifierDefinition {
                Id = 3,
                Name = "Attack Speed",
                MinValue = 1,
                MaxValue = 20,
                AllowedItemClasses = [ItemClasses[0], ItemClasses[1]]
            },
            new ModifierDefinition {
                Id = 4,
                Name = "Physical Damage",
                MinValue = 1,
                MaxValue = 100,
                AllowedItemClasses = [ItemClasses[0], ItemClasses[1]]
            },
            new ModifierDefinition {
                Id = 5,
                Name = "Fire Damage",
                MinValue = 1,
                MaxValue = 120,
                AllowedItemClasses = [ItemClasses[0], ItemClasses[1]]
            },
            new ModifierDefinition {
                Id = 6,
                Name = "Cold Damage",
                MinValue = 1,
                MaxValue = 120,
                AllowedItemClasses = [ItemClasses[0], ItemClasses[1]]
            },
            new ModifierDefinition {
                Id = 7,
                Name = "Lightning Damage",
                MinValue = 1,
                MaxValue = 120,
                AllowedItemClasses = [ItemClasses[0], ItemClasses[1]]
            },
            new ModifierDefinition {
                Id = 8,
                Name = "Maximum Mana",
                MinValue = 1,
                MaxValue = 100,
                AllowedItemClasses = [ItemClasses[2], ItemClasses[3]]
            },
            new ModifierDefinition {
                Id = 9,
                Name = "Cold Resistance",
                MinValue = 1,
                MaxValue = 50,
                AllowedItemClasses = [ItemClasses[0], ItemClasses[1], ItemClasses[2], ItemClasses[3]]
            },
            new ModifierDefinition {
                Id = 10,
                Name = "Lightning Resistance",
                MinValue = 1,
                MaxValue = 50,
                AllowedItemClasses = [ItemClasses[0], ItemClasses[1], ItemClasses[2], ItemClasses[3]]
            },
        ];

        public static readonly List<string> NamePrefixes = [
            "Dragon",
            "Storm",
            "Blood",
            "Soul",
            "Ancient",
            "Doom"
        ];

        public static readonly List<string> NameSuffixes = [
            "Fang",
            "Edge",
            "Bite",
            "Call",
            "Grasp",
            "Song"
        ];
    }
}
