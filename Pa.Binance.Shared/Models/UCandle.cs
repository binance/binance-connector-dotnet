using System;

namespace Binance.Shared.Models
{
    public class Candlestick
    {
        public string SymbolName { get; set; }
        public string Interval { get; set; }
        public DateTime OpenTime { get; set; }
        public double OpenPrice { get; set; }
        public double HighPrice { get; set; }
        public double LowPrice { get; set; }
        public double ClosePrice { get; set; }
        public double Volume { get; set; }
        public DateTime CloseTime { get; set; }
        public double QuoteAssetVolume { get; set; }
        public long NumberOfTrades { get; set; }
        public int FullBodyPercent { get; set; }
        public bool IsFullBody
        {
            get
            {
                return BodyLen >= FullBodyPercent;
            }
        }
        public double BodyLen
        {
            get
            {
                return (Math.Abs(ClosePrice - OpenPrice) / Math.Abs(HighPrice - LowPrice)) * 100;
            }
        }
        public bool Ascending
        {
            get
            {
                return ClosePrice - OpenPrice > 0;
            }
        }
        public bool IsStandard
        {
            get
            {
                decimal height = (decimal)HighPrice - (decimal)LowPrice;
                return height >= (WATR * 80 / 100) && height <= (WATR * 3);
            }
        }
        public DateTime OpenUTC
        {
            get
            {
                return OpenTime.ToUniversalTime();
            }
        }
        public DateTime CloseUTC
        {
            get
            {
                return CloseTime.ToUniversalTime();
            }
        }
        public decimal WATR
        {
            get
            {
                return ((ATR264 * 8) + (ATR132 * 5) + (ATR66 * 3) + (ATR21 * 2) + (ATR10) + (ATR5)) / 20;
            }
        }
        public decimal RSI
        {
            get;
            set;
        }
        public decimal ATR264 { get; set; }
        public decimal ATR132 { get; set; }
        public decimal ATR66 { get; set; }
        public decimal ATR21 { get; set; }
        public decimal ATR10 { get; set; }
        public decimal ATR5 { get; set; }
        public decimal EMA { get; set; }
        public decimal SMA { get; set; }
        public decimal RMA { get; set; }

        public Candlestick()
        {
            HighPrice = 3.7;
            FullBodyPercent = 60;
        }
        public string GetSerialize()
        {
            return string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\"",
                SymbolName,
                Interval,
                Helper.DateTimeToUnixTimeStamp(OpenUTC),
                Helper.DateTimeToUnixTimeStamp(CloseUTC),
                OpenPrice,
                HighPrice,
                LowPrice,
                ClosePrice,
                RSI,
                WATR,
                SMA,
                EMA,
                RMA
                );
        }

        public override string ToString()
        {
            return string.Format("[{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}]",
                SymbolName,
                Interval,
                Helper.DateTimeToUnixTimeStamp(OpenUTC),
                Helper.DateTimeToUnixTimeStamp(CloseUTC),
                OpenPrice,
                HighPrice,
                LowPrice,
                ClosePrice,
                RSI,
                WATR,
                SMA,
                EMA,
                RMA
                );
        }

        public void CopyFrom(Candlestick instance)
        {
            this.ATR264 = instance.ATR264;
            this.ATR132 = instance.ATR132;
            this.ATR66 = instance.ATR66;
            this.ATR21 = instance.ATR21;
            this.ATR10 = instance.ATR10;
            this.ATR5 = instance.ATR5;
            this.SMA = instance.SMA;
            this.EMA = instance.EMA;
            this.RSI = instance.RSI;
            this.ClosePrice = instance.ClosePrice;
            this.OpenPrice = instance.OpenPrice;
            this.HighPrice = instance.HighPrice;
            this.LowPrice = instance.LowPrice;
            this.FullBodyPercent = instance.FullBodyPercent;
            this.Interval = instance.Interval;
            this.CloseTime = instance.CloseTime;
            this.OpenTime = instance.OpenTime;
            this.RMA = instance.RMA;
            this.SymbolName = instance.SymbolName;
            this.Volume = instance.Volume;
        }
    }
}
