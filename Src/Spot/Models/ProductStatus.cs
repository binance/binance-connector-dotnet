namespace Binance.Spot.Models
{
    public struct ProductStatus
    {
        private ProductStatus(string value)
        {
            this.Value = value;
        }

        public static ProductStatus ALL { get => new ProductStatus("ALL"); }
        public static ProductStatus SUBSCRIBABLE { get => new ProductStatus("SUBSCRIBABLE"); }
        public static ProductStatus UNSUBSCRIBABLE { get => new ProductStatus("UNSUBSCRIBABLE"); }

        public string Value { get; private set; }

        public static implicit operator string(ProductStatus enm) => enm.Value;

        public override string ToString() => this.Value.ToString();
    }
}