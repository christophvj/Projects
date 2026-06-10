using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkPlanner
{

    public class VLSMModel : NetworkCalculator
    {
        public string DepartmentName { get; private set; }
        public int HostsNeeded { get; private set; }
        public int AllocatedHosts { get; private set; }   // usable hosts in the assigned block
        public int RemainingAddSpace { get; private set; }   // addresses remaining after this subnet

        // -- Constructors ----------------------------------------------------------

        public VLSMModel()
        {
            DepartmentName = string.Empty;
            HostsNeeded = 0;
            AllocatedHosts = 0;
            RemainingAddSpace = 0;
        }

        public VLSMModel(int[] octets, int cidrValue, string departmentName, int hostsNeeded, int remainingAddSpace) : base(octets, cidrValue)
        {
            DepartmentName = departmentName;
            HostsNeeded = hostsNeeded;
            AllocatedHosts = GetUsableHosts();
            RemainingAddSpace = remainingAddSpace;
        }

        // -- Setters ----------------------------------------------------------

        public void SetDepartmentName(string departmentName)
        {
            DepartmentName = departmentName;
        }
        public void SetHostsNeeded(int hostsNeeded)
        {
            HostsNeeded = hostsNeeded;
        }
        public void SetRemainingAddSpace(int remainingAddSpace)
        {
            RemainingAddSpace = remainingAddSpace;
        }

        // -- Getters ----------------------------------------------------------

        public string GetDepartmentName() => DepartmentName;
        public int GetHostsNeeded() => HostsNeeded;
        public int GetRemainingAddSpace() => RemainingAddSpace;

 

        /// <summary>
        /// Returns the CIDR prefix length
        /// </summary>
        public static int GetRequiredCidr(int hostsNeeded)
        {
            // Need at least 2 usable hosts (network + broadcast excluded)
            int hostBits = 1;
            while ((Math.Pow(2, hostBits) - 2) < hostsNeeded)
                hostBits++;

            return 32 - hostBits;
        }

        /// <summary>
        /// Returns the CIDR notation string for this subnet, e.g. "192.168.1.0/26".
        /// </summary>
        public string GetCidrNotation()
        {
            return $"{GetNetworkAddress()}/{CidrValue}";
        }

        /// <summary>
        /// Calculates the next available network address that follows
        /// the broadcast address of this subnet.
        /// Returns it as a 4-element int array.
        /// </summary>
        public int[] GetNextNetworkOctets()
        {
            // Convert broadcast to a 32-bit integer, add 1
            string[] bcastOctets = GetBroadcastAddress().Split('.');
            long bcastInt = (Convert.ToInt64(bcastOctets[0]) << 24)
                          | (Convert.ToInt64(bcastOctets[1]) << 16)
                          | (Convert.ToInt64(bcastOctets[2]) << 8)
                          | Convert.ToInt64(bcastOctets[3]);

            long nextInt = bcastInt + 1;

            return new int[]
            {
                (int)((nextInt >> 24) & 0xFF),
                (int)((nextInt >> 16) & 0xFF),
                (int)((nextInt >>  8) & 0xFF),
                (int)( nextInt        & 0xFF)
            };
        }
    }
}
