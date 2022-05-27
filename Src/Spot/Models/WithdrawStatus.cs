namespace Binance.Spot.Models
{
    public struct WithdrawStatus
    {
        private WithdrawStatus(string value)
        {
            this.Value = value;
        }

        public static WithdrawStatus EMAIL_SENT { get => new WithdrawStatus("EMAIL_SENT"); }
        public static WithdrawStatus CANCELLED { get => new WithdrawStatus("CANCELLED"); }
        public static WithdrawStatus AWAITING_APPROVAL { get => new WithdrawStatus("AWAITING_APPROVAL"); }
        public static WithdrawStatus REJECTED { get => new WithdrawStatus("REJECTED"); }
        public static WithdrawStatus PROCESSING { get => new WithdrawStatus("PROCESSING"); }
        public static WithdrawStatus FAILURE { get => new WithdrawStatus("FAILURE"); }
        public static WithdrawStatus COMPLETED { get => new WithdrawStatus("COMPLETED"); }

        public string Value { get; private set; }

        public static implicit operator string(WithdrawStatus enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}