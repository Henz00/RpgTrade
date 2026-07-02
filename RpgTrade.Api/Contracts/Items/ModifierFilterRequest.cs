namespace RpgTrade.Api.Contracts.Items
{
    public sealed class ModifierFilterRequest
    {
        public int ModifierDefinitionId { get; set; }

        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }
    }
}
