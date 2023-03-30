using System;

namespace Binance.Shared.Models
{
    public class ATRCalculator
    {
        public static double[] Calculate(int period, Candlestick[] timeSeries)
        {
            var temp = new double[timeSeries.Length];
            temp[0] = timeSeries[0].HighPrice - timeSeries[0].LowPrice;

            for (var i = 1; i < timeSeries.Length; i++)
            {
                var diff1 = Math.Abs(timeSeries[i].HighPrice - timeSeries[i - 1].ClosePrice);
                var diff2 = Math.Abs(timeSeries[i].LowPrice - timeSeries[i - 1].ClosePrice);
                var diff3 = timeSeries[i].HighPrice - timeSeries[i].LowPrice;

                var max = Math.Max(diff1, diff3);
                // var max = diff1 > diff2 ? diff1 : diff2;
                temp[i] = Math.Max(max, diff2); ;
            }

           // var atr = RMACalculator.Calculate(temp, period);

            return temp;
        }
    }
}
