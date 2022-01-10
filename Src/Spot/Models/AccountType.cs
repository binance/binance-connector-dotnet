namespace Binance.Spot.Models
{
    public struct AccountType
    {
        private AccountType(string value)
        {
            this.Value = value;
        }

        public static AccountType SPOT { get => new AccountType("SPOT"); }
        public static AccountType MARGIN { get => new AccountType("MARGIN"); }
        public static AccountType FUTURES { get => new AccountType("FUTURES"); }

        public string Value { get; private set; }

        public static implicit operator string(AccountType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}