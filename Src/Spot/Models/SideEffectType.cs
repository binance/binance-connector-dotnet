namespace Binance.Spot.Models
{
    public struct SideEffectType
    {
        private SideEffectType(string value)
        {
            this.Value = value;
        }

        public static SideEffectType NO_SIDE_EFFECT { get => new SideEffectType("NO_SIDE_EFFECT"); }
        public static SideEffectType MARGIN_BUY { get => new SideEffectType("MARGIN_BUY"); }
        public static SideEffectType AUTO_REPAY { get => new SideEffectType("AUTO_REPAY"); }

        public string Value { get; private set; }

        public static implicit operator string(SideEffectType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}