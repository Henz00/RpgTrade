using System;
using System.Collections.Generic;
using System.Text;

namespace RpgTrade.Domain
{
    public class BaseType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ItemClassId { get; set; }
        public ItemClass ItemClass { get; set; } = null!;
    }
}
