namespace Binance.Spot.Models
{
    public struct CrossMarginTransferType
    {
        private CrossMarginTransferType(string value)
        {
            this.Value = value;
        }

        public static CrossMarginTransferType ROLL_IN { get => new CrossMarginTransferType("ROLL_IN"); }
        public static CrossMarginTransferType ROLL_OUT { get => new CrossMarginTransferType("ROLL_OUT"); }

        public string Value { get; private set; }

        public static implicit operator string(CrossMarginTransferType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}