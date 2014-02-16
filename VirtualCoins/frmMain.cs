using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BtcE;

namespace VirtualCoins
{
    public partial class frmMain : Form
    {
        private static decimal extRateCnyUsd = 0; 

        public frmMain()
        {
            InitializeComponent();
            extRateCnyUsd = Decimal.Parse(this.txtExtRateUSD.Text);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            bgWorkThread.RunWorkerAsync();
        }

        private void bgWorkThread_DoWork(object sender, DoWorkEventArgs e)
        {
            RefreshBTCEMarketData();
        }

        private void RefreshBTCEMarketData() 
        {
            try
            {
                // var depth3 = BtceApiV3.GetDepth(new BtcePair[] { BtcePair.btc_usd });
                var tickets = BtceApiV3.GetTicker(new BtcePair[] { BtcePair.btc_usd, BtcePair.ltc_usd, 
                BtcePair.nmc_btc, BtcePair.ppc_btc,BtcePair.nvc_btc,BtcePair.trc_btc,BtcePair.ftc_btc });

                bool isDisplayCNY = this.chkIsRMB.Checked;
                decimal btc_usd = tickets[BtcePair.btc_usd].Last;
                decimal ltc_usd = tickets[BtcePair.ltc_usd].Last;
                decimal nmc_usd = Math.Round(tickets[BtcePair.nmc_btc].Last * btc_usd, 3);
                decimal ppc_usd = Math.Round(tickets[BtcePair.ppc_btc].Last * btc_usd, 3);
                decimal nvc_usd = Math.Round(tickets[BtcePair.nvc_btc].Last * btc_usd, 3);
                //decimal xpm_usd = Math.Round(tickets[BtcePair.ppc_btc].Last * btc_usd, 3);
                decimal ftc_usd = Math.Round(tickets[BtcePair.ftc_btc].Last * btc_usd, 3);
                decimal trc_usd = Math.Round(tickets[BtcePair.trc_btc].Last * btc_usd, 3);


                this.lblBTC.Text = isDisplayCNY ? "" + Math.Round(btc_usd * extRateCnyUsd, 3) : "" + btc_usd;
                this.lblLTC.Text = isDisplayCNY ? "" + Math.Round(ltc_usd * extRateCnyUsd, 3) : "" + ltc_usd;
                this.lblNMC.Text = isDisplayCNY ? "" + Math.Round(nmc_usd * extRateCnyUsd, 3) : "" + nmc_usd;
                this.lblPPC.Text = isDisplayCNY ? "" + Math.Round(ppc_usd * extRateCnyUsd, 3) : "" + ppc_usd;
                this.lblNVC.Text = isDisplayCNY ? "" + Math.Round(nvc_usd * extRateCnyUsd, 3) : "" + nvc_usd;
                //this.lblXPM.Text = isDisplayCNY ? "" + Math.Round(xpm_usd * extRateCnyUsd, 3) : "" + xpm_usd;
                this.lblFTC.Text = isDisplayCNY ? "" + Math.Round(ftc_usd * extRateCnyUsd, 3) : "" + ftc_usd;
                this.lblTRC.Text = isDisplayCNY ? "" + Math.Round(trc_usd * extRateCnyUsd, 3) : "" + trc_usd;
            }
            catch(Exception ex) {
                MessageBox.Show("发生异常：" + ex.Message);
                this.tmRefresh.Stop();
            }
           // var trades3 = BtceApiV3.GetTrades(new BtcePair[] { BtcePair.btc_usd });
            /*var ticker = BtceApi.GetTicker(BtcePair.btc_usd);
            var trades = BtceApi.GetTrades(BtcePair.btc_usd);
            var btcusdDepth = BtceApi.GetDepth(BtcePair.usd_rur);
            var fee = BtceApi.GetFee(BtcePair.usd_rur);

            var btceApi = new BtceApi("4CIG2016-8D8E49BZ-XRCU75U3-19L4TWLP-WR0H9HZU", "d2d9d25fdf44c6c365f0da2740a2f7c0e0b97bc662431296fa849dfbea5963b3");
            var info = btceApi.GetInfo();
            var transHistory = btceApi.GetTransHistory();
            var tradeHistory = btceApi.GetTradeHistory(count: 20);
            var orderList = btceApi.GetOrderList();*/
            //var tradeAnswer = btceApi.Trade(BtcePair.btc_usd, TradeType.Sell, 20, 0.1m);
            //var cancelAnswer = btceApi.CancelOrder(tradeAnswer.OrderId);
        }

        private void bgWorkThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //bgWorkThread.CancelAsync();
        }

        private void tmRefresh_Tick(object sender, EventArgs e)
        {
            RefreshBTCEMarketData();
        }

        private void nudRefresh_ValueChanged(object sender, EventArgs e)
        {
            this.tmRefresh.Interval = int.Parse(this.nudRefresh.Value.ToString());
        }

        private void btnAutoRefresh_Click(object sender, EventArgs e)
        {
            if ("开始自动刷新".Equals(this.btnAutoRefresh.Text))
            {

                this.tmRefresh.Start();
                this.btnAutoRefresh.Text = "停止自动刷新";
            }
            else {

                this.tmRefresh.Stop();
                this.btnAutoRefresh.Text = "开始自动刷新";
            }
        }
    }
}
