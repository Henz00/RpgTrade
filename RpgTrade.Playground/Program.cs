using RpgTrade.Application.ItemGeneration;
using RpgTrade.Domain;

var item = ItemGenerator.Generate(seed: 959512313, rarity: ItemRarity.Rare);

Random random = new Random();
List<Item> rareItems = new();

for (int i = 0; i < 10_000; i++)
{
    rareItems.Add(ItemGenerator.Generate(
        seed: random.Next(0, int.MaxValue),
        rarity: ItemRarity.Rare
    ));
}

//for(int i = 0;i < 10; i++)
//{
//    PrintItem.Print(rareItems[i]);
//}



bool allRareItemsHaveValidModifierCount = rareItems
    .All(item => item.Modifiers.Count >= 3 && item.Modifiers.Count <= 6);

bool allModifiersAreAllowedForItemClass = rareItems
    .All(item => item.Modifiers.All(modifier =>
        modifier.Definition.AllowedItemClasses.Any(allowedClass =>
            allowedClass.Id == item.BaseType.ItemClass.Id)));

bool allModifierValuesAreWithinRange = rareItems
    .All(item => item.Modifiers.All(modifier =>
        modifier.Value >= modifier.Definition.MinValue &&
        modifier.Value <= modifier.Definition.MaxValue));

Console.WriteLine($"Rare modifier count valid: {allRareItemsHaveValidModifierCount}");
Console.WriteLine($"Modifiers allowed for item class: {allModifiersAreAllowedForItemClass}");
Console.WriteLine($"Modifier values within range: {allModifierValuesAreWithinRange}");

//Dictionary<string, int> modifierCount = new Dictionary<string, int>();

//foreach (var target in rareItems)
//{
//    foreach (var modifier in target.Modifiers)
//    {
//        string Modifier = modifier.Definition.Name;

//        if (!modifierCount.ContainsKey(Modifier))
//        {
//            modifierCount[Modifier] = 0;
//        }

//        modifierCount[Modifier]++;
//    }
//}


//foreach (var pair in modifierCount.OrderBy(pair => pair.Key))
//{
//    Console.WriteLine($"{pair.Key}: {pair.Value}");
//}