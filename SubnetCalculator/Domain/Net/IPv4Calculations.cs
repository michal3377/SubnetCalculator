using System;

namespace SubnetCalculator.Domain.Net {
    class IPv4Calculations {
        public static UInt32 AddressValueFromOctets(byte[] octets) {
            UInt32 value = 0;
            for (int i = 0; i < 4; i++) {
                var oct = octets[i] << ((3 - i) * 8);
                value += (uint) oct;
            }
            return value;
        }

        public static byte[] OctetsFromAddressValue(UInt32 value) {
            byte[] octets = new byte[4];
            for (int i = 0; i < 4; i++) {
                octets[i] = (byte) (value >> ((3 - i) * 8));
            }
            return octets;
        }

        public static UInt32 CalculateMaskInteger(int maskSize) {
            return UInt32.MaxValue << 32 - maskSize;
        }

        public static UInt32 CalculateSubnetAddress(UInt32 address, UInt32 mask) {
            return mask & address;
        }


        public static UInt32 CalculateFirstHostAddress(UInt32 subnetAddress) {
            return subnetAddress + 1;
        }


        public static UInt32 CalculateBroadcastAddress(UInt32 address, UInt32 mask) {
            return ~mask | address;
        }


        public static UInt32 CalculateLastHostAddress(UInt32 broadcastAddress) {
            return broadcastAddress - 1;
        }

        public static int CalculateMaxHostAmount(UInt32 mask) {
            var am = Convert.ToInt32((~mask) - 1);
            return am >= 0 ? am : 0;
        }
    }
}