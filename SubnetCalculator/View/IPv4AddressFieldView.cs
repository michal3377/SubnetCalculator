using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SubnetCalculator.Data;
using SubnetCalculator.Net;

namespace SubnetCalculator.View {
    public class IPv4AddressFieldView : FieldView {

        public IPv4Address Address;

        private Button btSwitch;
        private TextBox tbDec;
        private TextBox[] tbBinArray;

        private readonly int[] _tbBinLocationXs = {51, 113, 175, 237};

        private bool displayInDec = true;


        public IPv4AddressFieldView(string name, IPv4Address address) : base(name) {
            Address = address;
        }

        protected override Control CreateInnerView() {
            var panel = new Panel();
//            panel.BackColor = Color.CornflowerBlue;
            panel.Size = new System.Drawing.Size(307, 36);

            btSwitch = new Button {
                Location = new System.Drawing.Point(2, 8),
                Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point, ((byte) (238))),
                Text = "BIN",
                Size = new System.Drawing.Size(38, 20),
                UseVisualStyleBackColor = true
            };
            btSwitch.Click += (sender, args) => { SwitchDisplayType(); };
            panel.Controls.Add(btSwitch);

            tbDec = new TextBox {
                Location = new System.Drawing.Point(51, 8),
                Size = new System.Drawing.Size(94, 20),
                ReadOnly = true,
                Text = GetDecAddress()
            };
            panel.Controls.Add(tbDec);


            tbBinArray = new TextBox[4];
            for (int i = 0; i < 4; i++) {
                var tb = new TextBox {
                    Location = new System.Drawing.Point(_tbBinLocationXs[i], 8),
                    Size = new System.Drawing.Size(56, 20),
                    Text = GetBinaryOctet(i),
                    Visible = false
                };
                tbBinArray[i] = tb;
                panel.Controls.Add(tb);
            }
            return panel;
        }

        private void SwitchDisplayType() {
            displayInDec = !displayInDec;
            foreach (var textBox in tbBinArray) {
                textBox.Visible = !displayInDec;
            }
            tbDec.Visible = displayInDec;
            btSwitch.Text = displayInDec ? "BIN" : "DEC";
        }

        private string GetDecAddress() {
            return Address.ToString();
        }

        private string GetBinaryOctet(int octetIndex) {
            return Address.GetOctetValue(octetIndex).ToBinaryString();
        }
    }
}