using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SubnetCalculator.Domain.Net;

namespace SubnetCalculator.View
{
    public class IPv4AddressPresenter {

        private const int MarginBetweenViews = 8;

        public Panel Panel;

        public IPv4AddressPresenter(Panel panel) {
            Panel = panel;
        }

        public Panel UpdateView(IPv4Address address) {
            Panel.Controls.Clear();
            FieldView[] views = {
                new IPv4AddressFieldView("Address", address),
                new TextFieldView("Class", address.AddressClass.ToString()),
                new TextFieldView("Public?", address.BelongsToPublicPool.ToString()),
                new IPv4AddressFieldView("Mask", address.Mask),
                new IPv4AddressFieldView("Broadcast", address.Broadcast),
                new IPv4AddressFieldView("First host", address.FirstHostAddress),
                new IPv4AddressFieldView("Last host", address.LastHostAddress),
                new TextFieldView("Max host amount", address.MaxHostAmount.ToString()), 
            };

            int lastY = 0;
            foreach (var field in views) {
                var view = field.CreateView();
                view.Location = new Point(0, lastY);
                lastY += view.Height + MarginBetweenViews;
                Panel.Controls.Add(view);
            }
            return Panel;
        }
    }
}
