namespace Binance.Spot.Models
{
    public struct FuturesType
    {
        private FuturesType(short value)
        {
            this.Value = value;
        }

        public static FuturesType USDT_MARGINED_FUTURES { get => new FuturesType(1); }
        public static FuturesType COIN_MARGINED_FUTURES { get => new FuturesType(2); }

        public short Value { get; private set; }

        public static implicit operator short(FuturesType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}