namespace Binance.Spot.Models
{
    public struct NewOrderResponseType
    {
        private NewOrderResponseType(string value)
        {
            this.Value = value;
        }

        public static NewOrderResponseType ACK { get => new NewOrderResponseType("ACK"); }
        public static NewOrderResponseType RESULT { get => new NewOrderResponseType("RESULT"); }
        public static NewOrderResponseType FULL { get => new NewOrderResponseType("FULL"); }

        public string Value { get; private set; }

        public static implicit operator string(NewOrderResponseType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}