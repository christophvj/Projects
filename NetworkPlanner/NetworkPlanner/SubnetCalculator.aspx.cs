using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetworkPlanner
{
    public partial class SubnetCalculator : System.Web.UI.Page
    {
        // Create instance of Subnet Calculator Model
        private SubnetCalculatorModel submodel = new SubnetCalculatorModel();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            // Get user input
            string ipAddress = txtIPAddress.Text.Trim();
            string cidr = txtCIDR.Text.Trim();

            // Validate that input is not empty
            if (string.IsNullOrEmpty(ipAddress) || string.IsNullOrEmpty(cidr))
            {
                lblError.Text = "**Please enter both IP Address and CIDR.**";
                return;
            }

            lblError.Text = string.Empty;

            // Validate IP address
            if (!submodel.IsValidIpAddress(ipAddress))
            {
                lblError.Text = "**Invalid IP Address format. Please enter a valid IP Address (****.****.****.****).";
                return;
            }

            // Validate CIDR value
            if (!submodel.IsValidCidr(cidr))
            {
                lblError.Text = "**Invalid CIDR format. Please enter a valid CIDR (1 - 32)";
            }

            // Store Validated data in Session
            Session["IpAddress"] = submodel.Octets;
            Session["Cidr"] = submodel.CidrValue;

            // Display all calculated Addresses results 
            lblSubnetMask.Text = submodel.GetSubnetMask();
            lblNetwork.Text = submodel.GetNetworkAddress();
            lblFirstHost.Text = submodel.GetFirstHost();
            lblBroadcast.Text = submodel.GetBroadcastAddress();
            lblLastHost.Text = submodel.GetLastHost();
            lblWildcardMask.Text = submodel.GetWildCardMask();
            lblTotalHosts.Text = submodel.GetTotalHosts().ToString();
            lblUsableHosts.Text = submodel.GetUsableHosts().ToString();
            lblClass.Text = submodel.GetClassType();
            lblRange.Text = submodel.GetFirstHost() + " ------ " + submodel.GetLastHost();
        }
    }
}