namespace RpgTrade.Domain
{
    public class ItemModifier
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid ItemId { get; set; }
        public int ModifierDefinitionId { get; set; }
        public ModifierDefinition Definition { get; set; } = null!;
        public double Value { get; set; }
    }
}
