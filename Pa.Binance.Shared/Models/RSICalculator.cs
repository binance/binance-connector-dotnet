namespace Binance.Shared.Models
{
    public class RSICalculator
    {
        public double CalcSMMAUp(Candlestick[] candlesticks, double n, int i, double avgUt1)
        {

            if (avgUt1 == 0)
            {
                double sumUpChanges = 0;

                for (int j = 0; j < n; j++)
                {
                    double change = candlesticks[i - j].ClosePrice - candlesticks[i - j].OpenPrice;

                    if (change > 0)
                    {
                        sumUpChanges += change;
                    }
                }
                return sumUpChanges / n;
            }
            else
            {
                double change = candlesticks[i].ClosePrice - candlesticks[i].OpenPrice;
                if (change < 0)
                {
                    change = 0;
                }
                return ((avgUt1 * (n - 1)) + change) / n;
            }

        }

        public double CalcSMMADown(Candlestick[] candlesticks, double n, int i, double avgDt1)
        {
            if (avgDt1 == 0)
            {
                double sumDownChanges = 0;

                for (int j = 0; j < n; j++)
                {
                    double change = candlesticks[i - j].ClosePrice - candlesticks[i - j].OpenPrice;

                    if (change < 0)
                    {
                        sumDownChanges -= change;
                    }
                }
                return sumDownChanges / n;
            }
            else
            {
                double change = candlesticks[i].ClosePrice - candlesticks[i].OpenPrice;
                if (change > 0)
                {
                    change = 0;
                }
                return ((avgDt1 * (n - 1)) - change) / n;
            }

        }
        public double[] CalculateRSIValues(Candlestick[] candlesticks, int n)
        {

            double[] results = new double[candlesticks.Length];

            double ut1 = 0;
            double dt1 = 0;
            for (int i = 0; i < candlesticks.Length; i++)
            {
                if (i < n)
                {
                    continue;
                }

                ut1 = CalcSMMAUp(candlesticks, n, i, ut1);
                dt1 = CalcSMMADown(candlesticks, n, i, dt1);

                results[i] = 100.0 - 100.0 / (1.0 +
                        CalculateRS(ut1,
                                    dt1));

            }

            return results;
        }

        public double[] CalculateRSIValuesV2(Candlestick[] candlesticks, int n)
        {

            double[] results = new double[candlesticks.Length];
            double[] src = new double[candlesticks.Length];
            for(int i = 0; i < candlesticks.Length; i++)
            {
                src[i] = candlesticks[i].ClosePrice;
            }
            double[] u = new double[src.Length];
            double[] d = new double[src.Length];
            double def = 0;
            u[0] = 0;
            d[0] = 0;
            for (int i = 1; i < u.Length; i++)
            {
                def = src[i] - src[i - 1];
                u[i] = def > 0 ? def : 0;
                def = src[i - 1] - src[i];
                d[i] = def > 0 ? def : 0;
            }

            double[] urma = RMACalculator.Calculate(u, n);
            double[] drma = RMACalculator.Calculate(d, n);

            for(int i = 0; i < src.Length; i++)
            {
                results[i] = 100 - 100 / (1 + CalculateRS(urma[i] , drma[i]));
            }
            return results;
        }


        private double CalculateRS(double avgUp, double avgDown)
        {
            return avgUp / avgDown;
        }
    }
}
