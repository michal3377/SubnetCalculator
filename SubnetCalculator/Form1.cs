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
using SubnetCalculator.Data;
using SubnetCalculator.Net;

namespace SubnetCalculator {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btApply_Click(object sender, EventArgs e) {
            IPv4Address ip;
            try {
                ip = IPv4Address.Parse(tbIpAddress.Text);
            } catch (InvalidIPv4AddressFormatException exception) {
                MessageBox.Show(exception.Message);
                return;
            }
            MessageBox.Show(ip.ToCompleteString());

            //            MessageBox.Show($"{ip} \nMaska: {ip.Mask.Value.ToBinaryString()}");
        }

        private void Form1_Load(object sender, EventArgs e) {
        }
    }
}