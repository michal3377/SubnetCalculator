using System;
using SubnetCalculator.Data;

namespace SubnetCalculator.Domain.Net {
    public class IPv4Address {
        public static readonly IPv4Address Empty = new IPv4Address(); // null object pattern

        private const int DefaultMaskSize = 24;

        public enum AddressClassType {
            A,
            B,
            C,
            D,
            E
        }

        private UInt32 _value;

        public UInt32 Value {
            get => _value;
            set {
                _value = value;
                _octets = IPv4Calculations.OctetsFromAddressValue(value);
                UpdateAddressProperties();
            }
        }

        private byte[] _octets = {0, 0, 0, 0};

        public byte[] Octets {
            get => _octets;
            set {
                if (value.Length != 4)
                    throw new ArgumentOutOfRangeException("Octet array must have length equals to 4");
                _octets = value;
                _value = IPv4Calculations.AddressValueFromOctets(value);
                UpdateAddressProperties();
            }
        }


        private int _maskSize = 0;

        public int MaskSize {
            get => _maskSize;
            set {
                if (value < 1 || value > 30)
                    throw new ArgumentOutOfRangeException(nameof(MaskSize),
                        "Mask size must be within <1-30> range");
                _maskSize = value;
                UpdateAddressProperties();
            }
        }

        public IPv4Address Mask { get; private set; }
        public AddressClassType AddressClass { get; private set; }
        public bool BelongsToPublicPool { get; private set; }
        public IPv4Address Subnet { get; private set; }
        public IPv4Address Broadcast { get; private set; }
        public IPv4Address FirstHostAddress { get; private set; }
        public IPv4Address LastHostAddress { get; private set; }
        public int MaxHostAmount { get; private set; }

        public bool IsHostAddress => DetermineWhetherIsHostAddress();

        public IPv4Address() {
        }

        public IPv4Address(uint value) {
            Value = value;
        }

        public IPv4Address(byte[] octets) {
            Octets = octets;
        }

        public IPv4Address(int firstOctet, int secondOctet, int thirdOctet, int fourthOctet) {
            if (firstOctet > 255 || secondOctet > 255 || thirdOctet > 255 || fourthOctet > 255)
                throw new ArgumentOutOfRangeException("Octet value must be within <0-255> range");
        }

        private void UpdateAddressProperties() {
            if (MaskSize == 0) return; //to avoid circular dependencies causing StackOverflow
            Mask = new IPv4Address(IPv4Calculations.CalculateMaskInteger(MaskSize));
            Subnet = new IPv4Address(IPv4Calculations.CalculateSubnetAddress(Value, Mask.Value));
            Broadcast = new IPv4Address(IPv4Calculations.CalculateBroadcastAddress(Value, Mask.Value));
            FirstHostAddress = new IPv4Address(IPv4Calculations.CalculateFirstHostAddress(Subnet.Value));
            LastHostAddress = new IPv4Address(IPv4Calculations.CalculateLastHostAddress(Broadcast.Value));
            MaxHostAmount = IPv4Calculations.CalculateMaxHostAmount(Mask.Value);
            AddressClass = CalculateClassType();
            BelongsToPublicPool = DetermineWhetherInPublicPool();
        }

        /// <summary>
        /// Factory method for creating IPv4Address from given string in IP format
        /// </summary>
        /// <param name="address">IP formatted string with mask (optional),
        /// eg. 192.168.1.220/24
        /// </param>
        /// <returns>new IPv4Address instance</returns>
        /// <exception cref="InvalidIPv4AddressFormatException">Given string is not in
        /// IPv4 format</exception>
        public static IPv4Address Parse(string address) {
            var ip = new IPv4Address();
            try {
                if (address.Contains("/")) {
                    var split = address.Split('/');
                    ip.MaskSize = Convert.ToInt32(split[1]);
                    address = split[0];
                } else {
                    ip.MaskSize = DefaultMaskSize;
                }
                var octets = address.Split('.');
                int i = 0;
                byte[] octetValues = new byte[4];
                foreach (var octet in octets) {
                    octetValues[i++] = Convert.ToByte(octet);
                }
                ip.Octets = octetValues;
            } catch (Exception e) {
                throw new InvalidIPv4AddressFormatException("Address is in invalid format.", e);
            }

            return ip;
        }

        //1st index from the right side, 0 indexed
        public byte GetOctetValue(int octetIndex) {
            byte mask = 0xFF;
            return (byte) (mask & (Value >> ((3 - octetIndex) * 8)));
        }

        public override string ToString() {
            var mask = MaskSize > 0 ? $"/{MaskSize}" : "";
            return $"{Octets[0]}.{Octets[1]}.{Octets[2]}.{Octets[3]}{mask}";
        }
        public string ToStringWithoutMask() {
            return $"{Octets[0]}.{Octets[1]}.{Octets[2]}.{Octets[3]}";
        }

        public string ToCompleteString() {
            return $"Address: {Octets[0]}.{Octets[1]}.{Octets[2]}.{Octets[3]}\n" +
                   $"Mask: {Mask.Value.ToBinaryString()}\n" +
                   $"Subnet: {Subnet}\n" +
                   $"Broadcast: {Broadcast}\n" +
                   $"First host address: {FirstHostAddress}";
        }

        private AddressClassType CalculateClassType() {
            byte firstOctet = _octets[0];
            if (firstOctet < 128) return AddressClassType.A;
            if (firstOctet < 192) return AddressClassType.B;
            if (firstOctet < 224) return AddressClassType.C;
            if (firstOctet < 240) return AddressClassType.D;
            return AddressClassType.E;
        }

        private bool DetermineWhetherInPublicPool() {
            if (_octets[0] == 10) return false;
            if (_octets[0] == 172 && _octets[1] >= 16 && _octets[1] <= 31) return false;
            if (_octets[0] == 192 && _octets[1] == 168) return false;
            return true;
        }

        private bool DetermineWhetherIsHostAddress() {
            return Value != Broadcast.Value && Value != Subnet.Value;
        }
    }
}