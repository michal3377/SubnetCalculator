using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubnetCalculator.Net {
    public class MyIPAddress {
        public enum AddressClassType {
            A,
            B,
            C,
            D,
            E
        }
        /**
         * Jedyna modyfikacja (get/set) przez zmiane Value, Octet (przy set warunek na size==4), Maska.
         * Metoda update
         */

        public UInt32 Value;
        public byte[] Octets = {0, 0, 0, 0};


        private int _maskSize = 0;

        public int MaskSize {
            get => _maskSize;
            set {
                if (value < 0 || value > 32)
                    throw new ArgumentOutOfRangeException(nameof(MaskSize),
                        "Mask size must be within <0-32> range");
                _maskSize = value;
                Mask = new MyIPAddress(CalculateMaskInteger());
            }
        }

        public MyIPAddress Mask;

        public AddressClassType AddressClass;
        public bool BelongsToPublicPool;
        public MyIPAddress Subnet { get; private set; }
        public MyIPAddress Broadcast { get; private set; }
        public MyIPAddress FirstHostAddress { get; private set; }
        public MyIPAddress LastHostAddress { get; private set; }
        public int MaxHostAmount { get; private set; }

        public MyIPAddress() {
        }

        public MyIPAddress(uint value) {
            Value = value;
        }

        private void UpdateValues() {
            Mask = new MyIPAddress(CalculateMaskInteger());
            Subnet = new MyIPAddress(CalculateSubnetAddress());
            Broadcast = new MyIPAddress(CalculateBroadcastAddress());
            FirstHostAddress = new MyIPAddress(CalculateFirstHostAddress());
            LastHostAddress = new MyIPAddress(CalculateLastHostAddress());
            MaxHostAmount = CalculateMaxHostAmount();
            
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

        //1st index from the right side, 0 indexed
        public uint GetOctetValue(int octetIndex) {
            uint mask = 0xFF;
            return mask & (Value >> (octetIndex * 8));
        }


        private UInt32 CalculateMaskInteger() {
            int a = 0xFFFFFFF;
            return UInt32.MaxValue << 32 - MaskSize;
        }

        private UInt32 CalculateSubnetAddress() {
            return Mask.Value & Value;
        }

        private UInt32 CalculateFirstHostAddress() {
            return Subnet.Value + 1;
        }


        private UInt32 CalculateBroadcastAddress() {
            return ~Mask.Value | Value;
        }

        private UInt32 CalculateLastHostAddress() {
            return Broadcast.Value + 1;
        }

        private int CalculateMaxHostAmount() {
            var am = Convert.ToInt32((~Mask.Value) - 2);
            return am >= 0 ? am : 0;
        }
    }
}