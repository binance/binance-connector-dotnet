namespace Binance.Spot.Models
{
    public struct FiatOrderTransactionType
    {
        private FiatOrderTransactionType(short value)
        {
            this.Value = value;
        }

        public static FiatOrderTransactionType DEPOSIT { get => new FiatOrderTransactionType(0); }
        public static FiatOrderTransactionType WITHDRAW { get => new FiatOrderTransactionType(1); }

        public short Value { get; private set; }

        public static implicit operator short(FiatOrderTransactionType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}