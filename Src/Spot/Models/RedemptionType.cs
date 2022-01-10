namespace Binance.Spot.Models
{
    public struct RedemptionType
    {
        private RedemptionType(string value)
        {
            this.Value = value;
        }

        public static RedemptionType FAST { get => new RedemptionType("FAST"); }
        public static RedemptionType NORMAL { get => new RedemptionType("NORMAL"); }

        public string Value { get; private set; }

        public static implicit operator string(RedemptionType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}