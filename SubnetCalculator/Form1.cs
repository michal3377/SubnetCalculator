using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using SubnetCalculator.Data;
using SubnetCalculator.Domain.Net;
using SubnetCalculator.View;

namespace SubnetCalculator {
    public partial class Form1 : Form {
        private IPv4AddressPresenter presenter;

        private IPv4Address currentAddress;
        public Form1() {
            InitializeComponent();        
            presenter = new IPv4AddressPresenter(presenterPanel);
        }

        private void btApply_Click(object sender, EventArgs e) {
            try {
                currentAddress = IPv4Address.Parse(tbIpAddress.Text);
            } catch (InvalidIPv4AddressFormatException exception) {
                MessageBox.Show(exception.Message);
                return;
            }
//            MessageBox.Show(ip.ToCompleteString());
            presenter.UpdateView(currentAddress);
            btPing.Enabled = currentAddress.IsHostAddress;
            //            MessageBox.Show($"{ip} \nMaska: {ip.Mask.Value.ToBinaryString()}");
        }

        private void Form1_Load(object sender, EventArgs e) {
        }

        private void btGetLocalIP_Click(object sender, EventArgs e)
        {
            tbIpAddress.Text = DataUtils.GetLocalIPAddress();

        }

        private void btPing_Click(object sender, EventArgs e)
        {
            SendPing(currentAddress.ToStringWithoutMask());
        }

        private async void SendPing(string ip) {
            var resp = await Pinger.PingHost(currentAddress.ToStringWithoutMask());
            MessageBox.Show(resp);
        }
    }
}