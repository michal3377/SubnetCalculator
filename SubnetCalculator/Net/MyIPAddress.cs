using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnetCalculator.Net
{
    public class MyIPAddress {

        public enum AddressClass {
            A, B, C, D, E
        }
        /**
         * Jedyna modyfikacja (get/set) przez zmiane AddressValue, Octet (przy set warunek na size==4), Maska.
         * Metoda update
         */

        public UInt32 AddressValue;
        public byte[] Octets = {0, 0, 0, 0};


        private int _maskSize = 0;
        public int MaskSize {
            get => _maskSize;
            set {
                if (value < 0 || value > 32) throw new ArgumentOutOfRangeException(nameof(MaskSize),
                    "Mask size must be within <1-32> range");
                _maskSize = value;
            }
        }

        public UInt32 MaskValue => CalculateMaskInteger();
        public MyIPAddress Mask;


        public MyIPAddress Subnet;

        public MyIPAddress() {
        }

        public MyIPAddress(uint addressValue) {
            AddressValue = addressValue;
        }

        public static MyIPAddress Parse(string address) {
            var ip = new MyIPAddress();
            if (address.Contains("/")) {
                var split = address.Split('/');
                ip.MaskSize = Convert.ToInt32(split[1]);
                address = split[0];
            }
            var octets = address.Split('.');
            int i = 0;
            foreach (var octet in octets) {
                ip.Octets[i++] = Convert.ToByte(octet);
            }
            return ip;
        }


        private UInt32 CalculateMaskInteger() {
            return UInt32.MaxValue << 32 - MaskSize; 
        }

        private MyIPAddress CalculateSubnetAddress() {
            return new MyIPAddress(MaskValue & AddressValue);
        }

        private MyIPAddress CalculateFirstHostAddress() {
            return new MyIPAddress(Subnet.AddressValue + 1);
        }



    }
}
