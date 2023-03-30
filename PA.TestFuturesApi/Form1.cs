using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Binance.Futures;
using Binance.Shared.Models;

namespace PA.TestFuturesApi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            FMarket bapi = new FMarket();
            string ping = await bapi.TestConnectivity();
            logListBox.Items.Add(ping);
            logListBox.Items.Add(await bapi.CheckServerTime());
            logListBox.Items.Add(await bapi.ExchangeInformation());
            var content = await bapi.KlineCandlestickData("BTCUSDT", Interval.ONE_DAY, null, null, 100);
            logListBox.Items.Add(content);
        }
    }
}
