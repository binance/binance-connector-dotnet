namespace Binance.Spot.Models
{
    public struct LiquidityRemovalType
    {
        private LiquidityRemovalType(string value)
        {
            this.Value = value;
        }

        public static LiquidityRemovalType SINGLE { get => new LiquidityRemovalType("SINGLE"); }
        public static LiquidityRemovalType COMBINATION { get => new LiquidityRemovalType("COMBINATION"); }

        public string Value { get; private set; }

        public static implicit operator string(LiquidityRemovalType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}