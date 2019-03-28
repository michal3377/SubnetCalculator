using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SubnetCalculator.Data {
    public class Pinger {
        public static async Task<string> PingHost(string nameOrAddress) {
            Ping pinger;
            try {
                pinger = new Ping();
                PingReply reply = await Task.Run(() => pinger.Send(nameOrAddress));
                return $"Status: {reply.Status}\n" +
                       $"Time [ms]: {reply.RoundtripTime}";
            } catch (Exception e) {
                return $"Ping failed with exception: {e.Message}";
            }
        }
    }
}