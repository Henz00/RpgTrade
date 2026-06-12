using RpgTrade.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RpgTrade.Application
{
    public static class PrintItem
    {
        public static void Print(Item item)
        {
            Console.WriteLine("Name: " + item.Name);
            Console.WriteLine("BaseType: " + item.BaseType.Name);
            Console.WriteLine("ILvl: " + item.ItemLevel);
            Console.WriteLine("Rarity: " + item.Rarity);
            foreach (var modifier in item.Modifiers)
            {
                Console.WriteLine($"{modifier.Definition.Name}: {modifier.Value}");
            }
            Console.WriteLine("-------------------");
        }
    }
}
