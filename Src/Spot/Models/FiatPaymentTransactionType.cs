namespace Binance.Spot.Models
{
    public struct FiatPaymentTransactionType
    {
        private FiatPaymentTransactionType(short value)
        {
            this.Value = value;
        }

        public static FiatPaymentTransactionType BUY { get => new FiatPaymentTransactionType(0); }
        public static FiatPaymentTransactionType SELL { get => new FiatPaymentTransactionType(1); }

        public short Value { get; private set; }

        public static implicit operator short(FiatPaymentTransactionType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}