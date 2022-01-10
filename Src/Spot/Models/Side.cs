namespace Binance.Spot.Models
{
    public struct Side
    {
        private Side(string value)
        {
            this.Value = value;
        }

        public static Side BUY { get => new Side("BUY"); }
        public static Side SELL { get => new Side("SELL"); }

        public string Value { get; private set; }

        public static implicit operator string(Side enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}