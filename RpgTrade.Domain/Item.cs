using System;
using System.Collections.Generic;
using System.Text;

namespace RpgTrade.Domain
{
    public class Item
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public ItemRarity Rarity { get; set; }
        public int ItemLevel { get; set; }
        public int BaseTypeId { get; set; }
        public BaseType BaseType { get; set; } = null!;
        public List<ItemModifier> Modifiers { get; set; } = [];
    }
}
