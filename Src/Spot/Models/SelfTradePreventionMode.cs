namespace Binance.Spot.Models
{
    public struct SelfTradePreventionMode
    {
        private SelfTradePreventionMode(string value)
        {
            this.Value = value;
        }

        public static SelfTradePreventionMode EXPIRE_TAKER { get => new SelfTradePreventionMode("EXPIRE_TAKER"); }
        public static SelfTradePreventionMode EXPIRE_MAKER { get => new SelfTradePreventionMode("EXPIRE_MAKER"); }
        public static SelfTradePreventionMode EXPIRE_BOTH { get => new SelfTradePreventionMode("EXPIRE_BOTH"); }
        public static SelfTradePreventionMode NONE { get => new SelfTradePreventionMode("NONE"); }
        public string Value { get; private set; }

        public static implicit operator string(SelfTradePreventionMode enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}