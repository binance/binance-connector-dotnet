namespace Binance.Spot.Models
{
    public struct FuturesTransferType
    {
        private FuturesTransferType(short value)
        {
            this.Value = value;
        }

        public static FuturesTransferType SPOT_TO_USDT_MARGINED_FUTURES { get => new FuturesTransferType(1); }
        public static FuturesTransferType USDT_MARGINED_FUTURES_TO_SPOT { get => new FuturesTransferType(2); }
        public static FuturesTransferType SPOT_TO_COIN_MARGINED_FUTURES { get => new FuturesTransferType(3); }
        public static FuturesTransferType COIN_MARGINED_FUTURES_TO_SPOT { get => new FuturesTransferType(4); }

        public short Value { get; private set; }

        public static implicit operator short(FuturesTransferType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}