namespace Binance.Spot.Models
{
    public struct Interval
    {
        private Interval(string value)
        {
            this.Value = value;
        }

        public static Interval ONE_MINUTE { get => new Interval("1m"); }
        public static Interval THREE_MINUTE { get => new Interval("3m"); }
        public static Interval FIVE_MINUTE { get => new Interval("5m"); }
        public static Interval FIFTEEN_MINUTE { get => new Interval("15m"); }
        public static Interval THIRTY_MINUTE { get => new Interval("30m"); }
        public static Interval ONE_HOUR { get => new Interval("1h"); }
        public static Interval TWO_HOUR { get => new Interval("2h"); }
        public static Interval FOUR_HOUR { get => new Interval("4h"); }
        public static Interval SIX_HOUR { get => new Interval("6h"); }
        public static Interval EIGTH_HOUR { get => new Interval("8h"); }
        public static Interval TWELVE_HOUR { get => new Interval("12h"); }
        public static Interval ONE_DAY { get => new Interval("1d"); }
        public static Interval THREE_DAY { get => new Interval("3d"); }
        public static Interval ONE_WEEK { get => new Interval("1w"); }
        public static Interval ONE_MONTH { get => new Interval("1M"); }

        public string Value { get; private set; }

        public static implicit operator string(Interval enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}