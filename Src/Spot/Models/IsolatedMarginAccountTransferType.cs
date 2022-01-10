namespace Binance.Spot.Models
{
    public struct IsolatedMarginAccountTransferType
    {
        private IsolatedMarginAccountTransferType(string value)
        {
            this.Value = value;
        }

        public static IsolatedMarginAccountTransferType SPOT { get => new IsolatedMarginAccountTransferType("SPOT"); }
        public static IsolatedMarginAccountTransferType ISOLATED_MARGIN { get => new IsolatedMarginAccountTransferType("ISOLATED_MARGIN"); }

        public string Value { get; private set; }

        public static implicit operator string(IsolatedMarginAccountTransferType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}