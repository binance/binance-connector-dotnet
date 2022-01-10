namespace Binance.Spot.Models
{
    public struct UniversalTransferType
    {
        private UniversalTransferType(string value)
        {
            this.Value = value;
        }

        public static UniversalTransferType MAIN_C2C { get => new UniversalTransferType("MAIN_C2C"); }
        public static UniversalTransferType MAIN_UMFUTURE { get => new UniversalTransferType("MAIN_UMFUTURE"); }
        public static UniversalTransferType MAIN_CMFUTURE { get => new UniversalTransferType("MAIN_CMFUTURE"); }
        public static UniversalTransferType MAIN_MARGIN { get => new UniversalTransferType("MAIN_MARGIN"); }
        public static UniversalTransferType MAIN_MINING { get => new UniversalTransferType("MAIN_MINING"); }
        public static UniversalTransferType C2C_MAIN { get => new UniversalTransferType("C2C_MAIN"); }
        public static UniversalTransferType C2C_UMFUTURE { get => new UniversalTransferType("C2C_UMFUTURE"); }
        public static UniversalTransferType C2C_MINING { get => new UniversalTransferType("C2C_MINING"); }
        public static UniversalTransferType C2C_MARGIN { get => new UniversalTransferType("C2C_MARGIN"); }
        public static UniversalTransferType UMFUTURE_MAIN { get => new UniversalTransferType("UMFUTURE_MAIN"); }
        public static UniversalTransferType UMFUTURE_C2C { get => new UniversalTransferType("UMFUTURE_C2C"); }
        public static UniversalTransferType UMFUTURE_MARGIN { get => new UniversalTransferType("UMFUTURE_MARGIN"); }
        public static UniversalTransferType CMFUTURE_MAIN { get => new UniversalTransferType("CMFUTURE_MAIN"); }
        public static UniversalTransferType CMFUTURE_MARGIN { get => new UniversalTransferType("CMFUTURE_MARGIN"); }
        public static UniversalTransferType MARGIN_MAIN { get => new UniversalTransferType("MARGIN_MAIN"); }
        public static UniversalTransferType MARGIN_UMFUTURE { get => new UniversalTransferType("MARGIN_UMFUTURE"); }
        public static UniversalTransferType MARGIN_CMFUTURE { get => new UniversalTransferType("MARGIN_CMFUTURE"); }
        public static UniversalTransferType MARGIN_MINING { get => new UniversalTransferType("MARGIN_MINING"); }
        public static UniversalTransferType MARGIN_C2C { get => new UniversalTransferType("MARGIN_C2C"); }
        public static UniversalTransferType MINING_MAIN { get => new UniversalTransferType("MINING_MAIN"); }
        public static UniversalTransferType MINING_UMFUTURE { get => new UniversalTransferType("MINING_UMFUTURE"); }
        public static UniversalTransferType MINING_C2C { get => new UniversalTransferType("MINING_C2C"); }
        public static UniversalTransferType MINING_MARGIN { get => new UniversalTransferType("MINING_MARGIN"); }
        public static UniversalTransferType MAIN_PAY { get => new UniversalTransferType("MAIN_PAY"); }
        public static UniversalTransferType PAY_MAIN { get => new UniversalTransferType("PAY_MAIN"); }
        public static UniversalTransferType ISOLATEDMARGIN_MARGIN { get => new UniversalTransferType("ISOLATEDMARGIN_MARGIN"); }
        public static UniversalTransferType MARGIN_ISOLATEDMARGIN { get => new UniversalTransferType("MARGIN_ISOLATEDMARGIN"); }
        public static UniversalTransferType ISOLATEDMARGIN_ISOLATEDMARGIN { get => new UniversalTransferType("ISOLATEDMARGIN_ISOLATEDMARGIN"); }

        public string Value { get; private set; }

        public static implicit operator string(UniversalTransferType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}