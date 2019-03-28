using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubnetCalculator.View
{
    public abstract class FieldView {

        private const int Margin = 90;

        public string Name;

        protected FieldView(string name) {
            Name = name;
        }

        public Panel CreateView() {
            var inner = CreateInnerView();
            var panel = new Panel();
            //panel.BackColor = Color.Bisque;
            panel.Size = new Size(inner.Width + Margin, 36);

            var label = new Label {
                Location = new Point(3, 11),
                AutoSize = true,
                Text = Name
            };
            panel.Controls.Add(label);

            inner.Location = new Point(Margin, 0);
            panel.Controls.Add(inner);
            return panel;
        }
        protected abstract Control CreateInnerView();
    }
}
