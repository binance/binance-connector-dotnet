namespace Binance.Shared.Models
{
    public static class EMACalculator
    {


        /// <summary>
        /// Calculates indicator.
        /// </summary>
        /// <param name="price">Price series.</param>
        /// <param name="period">Indicator period.</param>
        /// <returns>Calculated indicator series.</returns>
        public static double[] Calculate(double[] price, int period)
        {
            var ema = new double[price.Length];
            double sum = SMACalculator.Calculate(price,period)[0];
            ema[0] = sum;
            double alpha = 2.0 / (1.0 + period);

            for (int i = 1; i < price.Length; i++)
            {
                sum += alpha * (price[i] - sum);
                ema[i] = sum;
            }

            return ema;
        }
        public static double[] Calculate(Candlestick[] candlesticks, int period)
        {
            var ema = new double[candlesticks.Length];
            double[] src = new double[candlesticks.Length];
            for (int i = 0; i < candlesticks.Length; i++)
                src[i] = candlesticks[i].ClosePrice;
            return Calculate(src, period);
        }
    }

    public static class RMACalculator
    {
        /// <summary>
        /// Calculates indicator.
        /// </summary>
        /// <param name="price">Price series.</param>
        /// <param name="period">Indicator period.</param>
        /// <returns>Calculated indicator series.</returns>
        public static double[] Calculate(double[] price, int period)
        {
            var ema = new double[price.Length];
            double sum = price[0];
            double alpha = 1.0 / period;

            for (int i = 0; i < price.Length; i++)
            {
                sum += alpha * (price[i] - sum);
                ema[i] = sum;
            }

            return ema;
        }
        public static double[] Calculate(Candlestick[] candlesticks, int period)
        {
            var ema = new double[candlesticks.Length];
            double[] src = new double[candlesticks.Length];
            for (int i = 0; i < candlesticks.Length; i++)
                src[i] = candlesticks[i].ClosePrice;
            return Calculate(src, period);
        }
    }
}
