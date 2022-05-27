namespace Binance.Spot.Models
{
    public struct FiatOrderTransactionType
    {
        private FiatOrderTransactionType(string value)
        {
            this.Value = value;
        }

        public static FiatOrderTransactionType DEPOSIT { get => new FiatOrderTransactionType("0"); }
        public static FiatOrderTransactionType WITHDRAW { get => new FiatOrderTransactionType("1"); }

        public string Value { get; private set; }

        public static implicit operator string(FiatOrderTransactionType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}