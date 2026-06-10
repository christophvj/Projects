using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkPlanner
{
    public abstract class NetworkCalculator
    {
        public int[] Octets { get; private set; }
        public int CidrValue { get; private set; }

        // -- Constructors ----------------------------------------------------------

        public NetworkCalculator()
        {
            Octets = new int[4];
            CidrValue = 0;
        }


        public NetworkCalculator(int[] octets, int cidrValue)
        {
            Octets = octets;
            CidrValue = cidrValue;
        }

        // -- Setters ----------------------------------------------------------

        public void SetOctets(int[] octets)
        {
            this.Octets = octets;
        }


        public void SetCidrValue(int cidrValue)
        {
            this.CidrValue = cidrValue;
        }


        /// <summary>
        /// IP address format validation
        /// Returns true if IP is correct else false
        /// Validates IP based on format (****.****.****.****)
        /// Validates Octets are between 0 & 255
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <returns></returns>
        public bool IsValidIpAddress(string ipAddress)
        {
            var dotIndex = new List<int>();

            for (int i = 0; i < ipAddress.Length; i++)
            {
                if (ipAddress[i] == '.')
                    dotIndex.Add(i);
            }

            if (dotIndex.Count != 3)
                return false;

            try
            {
                Octets[0] = int.Parse(ipAddress.Substring(0, dotIndex[0]));
                Octets[1] = int.Parse(ipAddress.Substring(dotIndex[0] + 1, dotIndex[1] - dotIndex[0] - 1));
                Octets[2] = int.Parse(ipAddress.Substring(dotIndex[1] + 1, dotIndex[2] - dotIndex[1] - 1));
                Octets[3] = int.Parse(ipAddress.Substring(dotIndex[2] + 1));

                foreach (int octet in Octets)
                    if (octet < 0 || octet > 255)
                        return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validate CIDR value
        /// Returns true if CIDR is correct else false
        /// Validates CIDR is int & between 0 & 32
        /// </summary>
        /// <param name="cidr"></param>
        /// <returns></returns>
        public bool IsValidCidr(string cidr)
        {
            if (!int.TryParse(cidr, out int value))
                return false;

            if (value < 0 || value > 32)
                return false;
            CidrValue = value;

            return true;
        }


        // Return Array Octets in concatenated string
        public string GetIpString()
        {
            string ipString = $"{Octets[0]}.{Octets[1]}.{Octets[2]}.{Octets[3]}";
            return ipString;
        }


        // -- Getters ----------------------------------------------------------


        /// <summary>
        /// Calculate SubnetMask by using CIDR value and base binary to decimal convertion
        /// Return Subnetmask as string
        /// </summary>
        /// <returns></returns>
        public string GetSubnetMask()
        {
            // Create a binary string with '1' for the number of bits specified by CIDR and '0' for the remaining bits
            string binaryString = string.Empty;
            for (int i = 0; i < CidrValue; i++)
            {
                binaryString += "1";
            }

            // Append remaining 0
            for (int j = CidrValue; j < 32; j++)
            {
                binaryString += "0";
            }

            // create 4 octets by converting each 8 bits of the binary string to decimal
            int binaryOctet1 = Convert.ToInt32(binaryString.Substring(0, 8), 2);
            int binaryOctet2 = Convert.ToInt32(binaryString.Substring(8, 8), 2);
            int binaryOctet3 = Convert.ToInt32(binaryString.Substring(16, 8), 2);
            int binaryOctet4 = Convert.ToInt32(binaryString.Substring(24), 2);

            // Construct subnet mask in decimal format
            string subnetMask = binaryOctet1 + "." + binaryOctet2 + "." + binaryOctet3 + "." + binaryOctet4;

            return subnetMask;
        }

        /// <summary>
        /// Calculate Network address
        /// Use bitwise AND operation between IP and Subnetmask
        /// Return Network address as string
        /// </summary>
        /// <returns></returns>
        public string GetNetworkAddress()
        {
            string subnetmask = GetSubnetMask(); // Call once & reuse
            string[] maskOctets = subnetmask.Split('.');

            // Calculate network address by performing bitwise AND operation between IP address and subnet mask
            int networkOctet1 = Octets[0] & Convert.ToInt32(maskOctets[0]);
            int networkOctet2 = Octets[1] & Convert.ToInt32(maskOctets[1]);
            int networkOctet3 = Octets[2] & Convert.ToInt32(maskOctets[2]);
            int networkOctet4 = Octets[3] & Convert.ToInt32(maskOctets[3]);

            // Construct network address in decimal format
            string networkAddress = networkOctet1 + "." + networkOctet2 + "." + networkOctet3 + "." + networkOctet4;
            return networkAddress;
        }

        /// <summary>
        /// Calculate Broadcast address
        /// Use bitwise OR operation between IP and Subnetmask
        /// Return Broadcast address as string
        /// </summary>
        /// <returns></returns>
        public string GetBroadcastAddress()
        {
            string[] netOctets = GetNetworkAddress().Split('.');
            string[] maskOctets = GetSubnetMask().Split('.');

            // Calculate broadcast address by performing bitwise OR operation between network address and the inverse of subnet mask
            int broadcastOctet1 = Convert.ToInt32(netOctets[0]) | (255 - Convert.ToInt32(maskOctets[0]));
            int broadcastOctet2 = Convert.ToInt32(netOctets[1]) | (255 - Convert.ToInt32(maskOctets[1]));
            int broadcastOctet3 = Convert.ToInt32(netOctets[2]) | (255 - Convert.ToInt32(maskOctets[2]));
            int broadcastOctet4 = Convert.ToInt32(netOctets[3]) | (255 - Convert.ToInt32(maskOctets[3]));

            // Construct broadcast address in decimal format
            string broadcastAddress = broadcastOctet1 + "." + broadcastOctet2 + "." + broadcastOctet3 + "." + broadcastOctet4;
            return broadcastAddress;
        }


        // Return first host 
        public string GetFirstHost()
        {
            string networkAddress = GetNetworkAddress();
            return networkAddress.Substring(0, networkAddress.LastIndexOf('.')) + "." + (Convert.ToInt32(networkAddress.Split('.')[3]) + 1);
        }

       
        // Return last host
        public string GetLastHost()
        {
            string broadcastAddress = GetBroadcastAddress();
            return broadcastAddress.Substring(0, broadcastAddress.LastIndexOf('.')) + "." + (Convert.ToInt32(broadcastAddress.Split('.')[3]) - 1);
        }


        // Return total hosts
        public int GetTotalHosts()
        {
            int totalHosts = Convert.ToInt32(Math.Pow(2, (32 - CidrValue)));
            return totalHosts;
        }


        // Return Usable hosts
        public int GetUsableHosts()
        {
            return GetTotalHosts() - 2;
        }
    }
}