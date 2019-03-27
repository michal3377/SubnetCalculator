using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SubnetCalculator.Net {
    public class InvalidIPv4AddressFormatException : Exception {
        public InvalidIPv4AddressFormatException() {
        }

        public InvalidIPv4AddressFormatException(string message) : base(message) {
        }

        public InvalidIPv4AddressFormatException(string message, Exception innerException) : base(message,
            innerException) {
        }

        protected InvalidIPv4AddressFormatException(SerializationInfo info, StreamingContext context) : base(info,
            context) {
        }
    }
}