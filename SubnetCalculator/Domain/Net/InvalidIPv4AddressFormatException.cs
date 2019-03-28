using System;
using System.Runtime.Serialization;

namespace SubnetCalculator.Domain.Net {
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