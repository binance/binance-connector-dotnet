namespace Binance.Shared.Models
{
    public class SMACalculator
    { 
        public static double[] Calculate(double[] price, int period)
        {
            var sma = new double[price.Length];

            double sum = 0;

            for (var i = 0; i < period; i++)
            {
                sum += price[i];
                sma[i] = sum / (i + 1);
            }

            for (var i = period; i < price.Length; i++)
            {
                sum = 0;
                for (var j = i; j > i - period; j--)
                {
                    sum += price[j];
                }

                sma[i] = sum / period;
            }

            return sma;
        }
        public static double[] Calculate(Candlestick[] candlesticks, int period)
        {
            var sma = new double[candlesticks.Length];
            double[] src = new double[candlesticks.Length];
            for (int i = 0; i < candlesticks.Length; i++)
                src[i] = candlesticks[i].ClosePrice;
            return Calculate(src, period);
        }
    }
}
