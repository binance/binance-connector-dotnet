namespace Binance.Spot.Models
{
    public struct UniversalTransferAccountType
    {
        private UniversalTransferAccountType(string value)
        {
            this.Value = value;
        }

        public static UniversalTransferAccountType SPOT { get => new UniversalTransferAccountType("SPOT"); }
        public static UniversalTransferAccountType USDT_FUTURE { get => new UniversalTransferAccountType("USDT_FUTURE"); }
        public static UniversalTransferAccountType COIN_FUTURE { get => new UniversalTransferAccountType("COIN_FUTURE"); }

        public string Value { get; private set; }

        public static implicit operator string(UniversalTransferAccountType enm) => enm.Value;
    }
}