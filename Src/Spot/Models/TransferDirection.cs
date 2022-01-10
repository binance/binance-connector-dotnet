namespace Binance.Spot.Models
{
    public struct TransferDirection
    {
        private TransferDirection(short value)
        {
            this.Value = value;
        }

        public static TransferDirection TRANSFER_IN { get => new TransferDirection(1); }
        public static TransferDirection TRANSFER_OUT { get => new TransferDirection(2); }

        public short Value { get; private set; }

        public static implicit operator short(TransferDirection enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}