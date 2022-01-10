namespace Binance.Spot.Models
{
    public struct SwapStatus
    {
        private SwapStatus(short value)
        {
            this.Value = value;
        }

        public static SwapStatus PENDING_FOR_SWAP { get => new SwapStatus(0); }
        public static SwapStatus SUCCESS { get => new SwapStatus(1); }
        public static SwapStatus FAILED { get => new SwapStatus(2); }

        public short Value { get; private set; }

        public static implicit operator short(SwapStatus enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}