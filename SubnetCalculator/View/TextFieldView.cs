using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubnetCalculator.View
{
    public class TextFieldView : FieldView {
        public string Value;

        public TextFieldView(string name, string value) : base(name) {
            Value = value;
        }


        protected override Control CreateInnerView() {
            var tb = new TextBox {
                Location = new System.Drawing.Point(4, 8),
                Size = new System.Drawing.Size(142, 20),
                ReadOnly = true,
                Text = Value
            };
            var panel = new Panel();
            panel.Size = new Size(200, 36);
            panel.Controls.Add(tb);
            return panel;
        }
    }
}
