using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkPlanner
{
    public class SubnetCalculatorModel : NetworkCalculator
    {
        public string ClassType { get; private set; }

        // -- Constructors ----------------------------------------------------------

        public SubnetCalculatorModel()
        {
            ClassType = string.Empty;
        }

        public SubnetCalculatorModel(int[] octets, int cidrValue) : base(octets, cidrValue)
        {
            ClassType = GetClassType();
        }

        // -- Setters ----------------------------------------------------------

        public void SetClassType(string classType)
        {
            this.ClassType = classType;
        }

        // -- Getters ----------------------------------------------------------

        /// <summary>
        /// Returns the Network Class type, e.g 'A', 'B', 'C'
        /// </summary>
        /// <returns></returns>
        public string GetClassType()
        {
            int octet1 = Octets[0];
            string classType = string.Empty;

            // Determine the class type of the IP address based on the first octet
            if (octet1 >= 1 && octet1 <= 126)
            {
                classType = "A";
            }
            else if (octet1 == 127)
            {
                classType = "Loopback (Reserved)";
            }
            else if (octet1 >= 128 && octet1 <= 191)
            {
                classType = "B";
            }
            else if (octet1 >= 192 && octet1 <= 223)
            {
                classType = "C";
            }
            else if (octet1 >= 224 && octet1 <= 239)
            {
                classType = "D (Multicast)";
            }
            else if (octet1 >= 240 && octet1 <= 255)
            {
                classType = "E (Experimental)";
            }
            else
            {
                classType = "Unknown";
            }

            return classType;
        }


        /// <summary>
        /// Returns Wildcard (255.255.255.255) - (Calculated Subnetmask from given IP address)
        /// </summary>
        /// <returns></returns>
        public string GetWildCardMask()
        {
            string[] maskOctets = GetSubnetMask().Split('.');

            // Calculate wildcard mask by subtracting each octet of subnet mask from 255
            int octet1 = 255 - Convert.ToInt32(maskOctets[0]);
            int octet2 = 255 - Convert.ToInt32(maskOctets[1]);
            int octet3 = 255 - Convert.ToInt32(maskOctets[2]);
            int octet4 = 255 - Convert.ToInt32(maskOctets[3]);

            string wildcard = octet1 + "." + octet2 + "." + octet3 + "." + octet4;
            return wildcard;
        }
    }
}