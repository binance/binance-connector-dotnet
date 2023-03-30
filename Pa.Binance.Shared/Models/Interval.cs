using System;

namespace Binance.Shared.Models
{
    public struct Interval
    {
        public Interval(string value)
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
        public TimeSpan IntervalTime()
        {
            switch (Value)
            {
                case "1m": return new TimeSpan(0, 1, 0);
                case "3m": return new TimeSpan(0, 3, 0);
                case "5m": return new TimeSpan(0, 5, 0);
                case "15m": return new TimeSpan(0, 15, 0);
                case "30m": return new TimeSpan(0, 30, 0);
                case "1h": return new TimeSpan(1, 0, 0);
                case "2h": return new TimeSpan(2, 0, 0);
                case "4h": return new TimeSpan(4, 0, 0);
                case "6h": return new TimeSpan(6, 0, 0);
                case "8h": return new TimeSpan(8, 0, 0);
                case "12h": return new TimeSpan(12, 0, 0);
                default:
                case "1d": return new TimeSpan(1, 0, 0, 0);
                case "3d": return new TimeSpan(3, 0, 0, 0);
                case "1w": return new TimeSpan(7, 0, 0, 0);
                case "1M": return new TimeSpan(30, 0, 0, 0);
            }
        }
    }
}