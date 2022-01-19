namespace Binance.Spot.Models
{
    public struct UniversalTransferType
    {
        private UniversalTransferType(string value)
        {
            this.Value = value;
        }

        public static UniversalTransferType MAIN_UMFUTURE { get => new UniversalTransferType("MAIN_UMFUTURE"); }
        public static UniversalTransferType MAIN_CMFUTURE { get => new UniversalTransferType("MAIN_CMFUTURE"); }
        public static UniversalTransferType MAIN_MARGIN { get => new UniversalTransferType("MAIN_MARGIN"); }
        public static UniversalTransferType UMFUTURE_MAIN { get => new UniversalTransferType("UMFUTURE_MAIN"); }
        public static UniversalTransferType UMFUTURE_MARGIN { get => new UniversalTransferType("UMFUTURE_MARGIN"); }
        public static UniversalTransferType CMFUTURE_MAIN { get => new UniversalTransferType("CMFUTURE_MAIN"); }
        public static UniversalTransferType CMFUTURE_MARGIN { get => new UniversalTransferType("CMFUTURE_MARGIN"); }
        public static UniversalTransferType MARGIN_MAIN { get => new UniversalTransferType("MARGIN_MAIN"); }
        public static UniversalTransferType MARGIN_UMFUTURE { get => new UniversalTransferType("MARGIN_UMFUTURE"); }
        public static UniversalTransferType MARGIN_CMFUTURE { get => new UniversalTransferType("MARGIN_CMFUTURE"); }
        public static UniversalTransferType ISOLATEDMARGIN_MARGIN { get => new UniversalTransferType("ISOLATEDMARGIN_MARGIN"); }
        public static UniversalTransferType MARGIN_ISOLATEDMARGIN { get => new UniversalTransferType("MARGIN_ISOLATEDMARGIN"); }
        public static UniversalTransferType ISOLATEDMARGIN_ISOLATEDMARGIN { get => new UniversalTransferType("ISOLATEDMARGIN_ISOLATEDMARGIN"); }
        public static UniversalTransferType MAIN_FUNDING { get => new UniversalTransferType("MAIN_FUNDING"); }
        public static UniversalTransferType FUNDING_MAIN { get => new UniversalTransferType("FUNDING_MAIN"); }
        public static UniversalTransferType FUNDING_UMFUTURE { get => new UniversalTransferType("FUNDING_UMFUTURE"); }
        public static UniversalTransferType UMFUTURE_FUNDING { get => new UniversalTransferType("UMFUTURE_FUNDING"); }
        public static UniversalTransferType MARGIN_FUNDING { get => new UniversalTransferType("MARGIN_FUNDING"); }
        public static UniversalTransferType FUNDING_MARGIN { get => new UniversalTransferType("FUNDING_MARGIN"); }
        public static UniversalTransferType FUNDING_CMFUTURE { get => new UniversalTransferType("FUNDING_CMFUTURE"); }
        public static UniversalTransferType CMFUTURE_FUNDING { get => new UniversalTransferType("CMFUTURE_FUNDING"); }

        public string Value { get; private set; }

        public static implicit operator string(UniversalTransferType enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}