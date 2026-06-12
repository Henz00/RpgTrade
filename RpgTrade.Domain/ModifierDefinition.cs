using System;
using System.Collections.Generic;
using System.Text;

namespace RpgTrade.Domain
{
    public class ModifierDefinition
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
        public List<ItemClass> AllowedItemClasses { get; set; } = [];
    }
}
