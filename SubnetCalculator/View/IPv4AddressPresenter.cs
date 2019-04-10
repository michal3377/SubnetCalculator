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
        private FieldView[] _views;

        public IPv4AddressPresenter(Panel panel) {
            Panel = panel;
        }

        public Panel UpdateView(IPv4Address address) {
            Panel.Controls.Clear();
            _views = new FieldView[]{
                new IPv4AddressFieldView("Address", address),
                new TextFieldView("Class", address.AddressClass.ToString()),
                new TextFieldView("Public?", address.BelongsToPublicPool.ToString()),
                new IPv4AddressFieldView("Mask", address.Mask),
                new IPv4AddressFieldView("Subnet", address.Subnet),
                new IPv4AddressFieldView("Broadcast", address.Broadcast),
                new IPv4AddressFieldView("First host", address.FirstHostAddress),
                new IPv4AddressFieldView("Last host", address.LastHostAddress),
                new TextFieldView("Max host amount", address.MaxHostAmount.ToString()), 
                new TextFieldView("Is host?", address.IsHostAddress.ToString()), 
            };

            int lastY = 0;
            foreach (var field in _views) {
                var view = field.CreateView();
                view.Location = new Point(0, lastY);
                lastY += view.Height + MarginBetweenViews;
                Panel.Controls.Add(view);
            }
            return Panel;
        }

        public string GenerateStringDescription() {
            var sb = new StringBuilder("IPv4 Address:");
            foreach (var fieldView in _views) {
                sb.AppendLine(fieldView.ToString());
            }
            return sb.ToString();
        }
    }
}
