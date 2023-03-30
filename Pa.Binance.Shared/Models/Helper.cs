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
        public static double GetSleepTime(Interval interval, DateTime now)
        {
            DateTime d1 = now;
            DateTime d2 = DateTime.UtcNow;
            switch (interval.ToString())
            {
                case "1m":
                case "3m":
                default:
                    return new TimeSpan(0, 1, 0).TotalMilliseconds;
                case "5m":
                    return (new TimeSpan(0, 6 - ((d1.Minute + 5) % 5), 0)).TotalMilliseconds;
                case "15m":
                    return (new TimeSpan(0, 16 - ((d1.Minute + 15) % 15), 0)).TotalMilliseconds;
                case "30m":
                    return (new TimeSpan(0, 31 - ((d1.Minute + 30) % 30), 0)).TotalMilliseconds;
                case "1h":
                    return (new TimeSpan(0, 60 - d1.Minute, 0)).TotalMilliseconds;
                case "2h":
                    int hour = 1 - d1.Hour % 2;
                    return (new TimeSpan(hour, 60 - d1.Minute, 0)).TotalMilliseconds;
                case "4h":
                    hour = 3 - d1.Hour % 4;
                    return (new TimeSpan(hour, 60 - d1.Minute, 0)).TotalMilliseconds;
                case "6h":
                    hour = 5 - d1.Hour % 6;
                    return (new TimeSpan(hour, 60 - d1.Minute, 0)).TotalMilliseconds;
                case "8h":
                    hour = 7 - d1.Hour % 8;
                    return (new TimeSpan(hour, -(d1.Minute - 1), 0)).TotalMilliseconds;
                case "12h":
                    hour = 11 - d1.Hour % 12;
                    return (new TimeSpan(hour, -(d1.Minute - 1), 0)).TotalMilliseconds;
                case "1d":
                    return (new TimeSpan(24 - d1.Hour, 60 - d1.Minute, 0)).TotalMilliseconds;
                case "1w":
                    int day = 6 - (int)d1.DayOfWeek;
                    return (new TimeSpan(day, 24 - d1.Hour, 60 - d1.Minute, 0)).TotalMilliseconds;
                case "1M":
                    return (new TimeSpan(30 - d1.Day, -d1.Hour, -(d1.Minute - 1), 0)).TotalMilliseconds;
            }
        }

        public static double BtcUsdt { get; set; }
        public static double EthUsdt { get; set; }
        public static double BnbUsdt { get; set; }
        public static double BusdUsdt { get; set; }
    }
}
