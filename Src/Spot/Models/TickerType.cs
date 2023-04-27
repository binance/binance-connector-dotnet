namespace Binance.Spot.Models
{
    public struct TickerType
    {
        private TickerType(string value)
        {
            this.Value = value;
        }

        public static TickerType FULL { get => new TickerType("FULL"); }
        public static TickerType MINI { get => new TickerType("MINI"); }

        public string Value { get; private set; }

        public static implicit operator string(TickerType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}