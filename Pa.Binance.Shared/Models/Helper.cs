using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Binance.Shared.Models
{
    public static class Helper
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddMilliseconds(unixTimeStamp).ToUniversalTime();
            return dateTime;
        }
        public static long DateTimeToUnixTimeStamp(DateTime date)
        {
            return (long)date.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        public static DateTime GetJsonTime(string st)
        {
            long val = ConvertStringToLong(st);
            return UnixTimeStampToDateTime(val);
        }

        public static long ConvertStringToLong(string a)
        {
            string b = string.Empty;
            long val = 0;

            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                    b += a[i];
            }

            if (b.Length > 0)
                val = long.Parse(b);
            return val;
        }

        public static double ConvertStringToDecimal(string val)
        {
            string str = string.Concat(val.Where(x => x == '.' || char.IsDigit(x)));
            double res = Convert.ToDouble(str, new CultureInfo("en-US"));
            return res;
        }
        public static int[] DefineFlowString(List<Candlestick> candles)
        {
            int[] res = new int[5];
            int j = 4;
            for (int i = 2; i < candles.Count - 2; i++)
            {
                Candlestick c = candles[i];
                if (c.OpenPrice < c.ClosePrice)
                    res[j] = 1;
                else
                    res[j] = -1;
                j--;
            }
            return res;
        }

        public static double Round(double val)
        {
            string intVal, desVal, str;
            str = val.ToString();
            string[] vals = str.Split(new char[] { '.','/' });
            if (vals.Length < 2)
                return val;
            intVal = vals[0];desVal = vals[1];
            int i = 0;
            while (desVal[i] == '0')
                i++;
            i += 2;
            return Math.Round(val, i);
        }
        public static TimeSpan GetSleepTime(Interval interval, DateTime now)
        {
            DateTime d1 = now;
            DateTime d2 = DateTime.Now;
            switch (interval.ToString())
            {
                case "1m":
                case "3m":
                default:
                    return new TimeSpan(0, 1, 0);
                case "5m":
                    d2 = d1.Add(new TimeSpan(0, 6 - ((d1.Minute + 5) % 5), 0));
                    return d2 - d1;
                case "15m":
                    d2 = d1.Add(new TimeSpan(0, 16 - ((d1.Minute + 15) % 15), 0));
                    return d2 - d1;
                case "30m":
                    d2 = d1.Add(new TimeSpan(0, 31 - ((d1.Minute + 30) % 30), 0));
                    return d2 - d1;
                case "1h":
                    d2 = d1.Add(new TimeSpan(1, -(d1.Minute - 1), 0));
                    return d2 - d1;
                case "2h":
                    d2 = d1.Add(new TimeSpan(2, -(d1.Minute - 1), 0));
                    return d2 - d1;
                case "4h":
                    d2 = d1.Add(new TimeSpan(4, -(d1.Minute - 1), 0));
                    return d2 - d1;
                case "6h":
                    d2 = d1.Add(new TimeSpan(6, -(d1.Minute - 1), 0));
                    return d2 - d1;
                case "8h":
                    d2 = d1.Add(new TimeSpan(8, -(d1.Minute - 1), 0));
                    return d2 - d1;
                case "12h":
                    d2 = d1.Add(new TimeSpan(12, -(d1.Minute - 1), 0));
                    return d2 - d1;
                case "1d":
                    d2 = d1.Add(new TimeSpan(1, -d1.Hour, -(d1.Minute - 1), 0));
                    return d2 - d1;
                case "1w":
                    d2 = d1.Add(new TimeSpan(7, -d1.Hour, -(d1.Minute - 1), 0));
                    return d2 - d1;
                case "1M":
                    d2 = d1.Add(new TimeSpan(30 - d1.Day, -d1.Hour, -(d1.Minute - 1), 0));
                    return d2 - d1;
            }
        }

        public static double BtcUsdt { get; set; }
        public static double EthUsdt { get; set; }
        public static double BnbUsdt { get; set; }
        public static double BusdUsdt { get; set; }
    }
}
