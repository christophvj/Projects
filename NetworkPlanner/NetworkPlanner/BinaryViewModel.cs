using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetworkPlanner
{
    public class BinaryViewModel : NetworkCalculator
    {
        public int NetworkBits { get; private set; }
        public int HostBits { get; private set; }

        // -- Constructors ----------------------------------------------------------

        public BinaryViewModel()
        {
            NetworkBits = 0;
            HostBits = 0;
        }


        public BinaryViewModel(int[] octets, int cidrValue) : base(octets, cidrValue)
        {
            NetworkBits = cidrValue;
            HostBits = 32 - cidrValue;
        }

        // -- Getters ----------------------------------------------------------


        /// <summary>
        /// Convert each IP octet in Octets[] Array into binary
        /// Return binary IP string
        /// </summary>
        /// <returns></returns>
        public string GetBinaryIP()
        {
            return string.Join(".", Array.ConvertAll(Octets, o =>
                Convert.ToString(o, 2).PadLeft(8, '0')));
        }


        /// <summary>
        /// Convert Submask into binary string
        /// Use base convertion on Submask
        /// Retrun binary Submask string
        /// </summary>
        /// <returns></returns>
        public string GetBinaryMask()
        {
            string bits = new string('1', CidrValue).PadRight(32, '0');
            return $"{bits.Substring(0, 8)}.{bits.Substring(8, 8)}" +
                   $".{bits.Substring(16, 8)}.{bits.Substring(24, 8)}";
        }

        // -- Setters ----------------------------------------------------------

        public void SetNetworkBits(int networkBits)
        {
            this.NetworkBits = networkBits;
        }

        public void SetHostBits(int hostBits)
        {
            this.HostBits = hostBits;
        }
    }
}