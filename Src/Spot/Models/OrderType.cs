namespace Binance.Spot.Models
{
    public struct OrderType
    {
        private OrderType(string value)
        {
            this.Value = value;
        }

        public static OrderType LIMIT { get => new OrderType("LIMIT"); }
        public static OrderType MARKET { get => new OrderType("MARKET"); }
        public static OrderType STOP_LOSS { get => new OrderType("STOP_LOSS"); }
        public static OrderType STOP_LOSS_LIMIT { get => new OrderType("STOP_LOSS_LIMIT"); }
        public static OrderType TAKE_PROFIT { get => new OrderType("TAKE_PROFIT"); }
        public static OrderType TAKE_PROFIT_LIMIT { get => new OrderType("TAKE_PROFIT_LIMIT"); }
        public static OrderType LIMIT_MAKER { get => new OrderType("LIMIT_MAKER"); }

        public string Value { get; private set; }

        public static implicit operator string(OrderType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}