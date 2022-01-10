namespace Binance.Spot.Models
{
    public struct DepositStatus
    {
        private DepositStatus(short value)
        {
            this.Value = value;
        }

        public static DepositStatus PENDING { get => new DepositStatus(0); }
        public static DepositStatus CREDITED_BUT_CANNOT_WITHDRAW { get => new DepositStatus(6); }
        public static DepositStatus SUCCESS { get => new DepositStatus(1); }

        public short Value { get; private set; }

        public static implicit operator short(DepositStatus enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}