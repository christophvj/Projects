using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetworkPlanner
{
    public partial class BinaryView : System.Web.UI.Page
    {

        // Create an Instance of the BinaryViewModel model
        private BinaryViewModel binarymodel = new BinaryViewModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if Session Values still Exists
            if (Session["IpAddress"] == null || Session["Cidr"] == null)
            {
                // Redirect user to subnet calcualtor to enter values first
                Response.Redirect("SubnetCalculator.aspx");
                return;
            }

            // Load the already validated session values into the model
            binarymodel = new BinaryViewModel((int[])Session["IpAddress"], (int)Session["Cidr"]);

            // Display all results
            lblIpAddress.Text = binarymodel.GetIpString();
            lblCidrValue.Text = binarymodel.CidrValue.ToString();
            lblIpResult.Text = binarymodel.GetBinaryIP();
            lblMaskResult.Text = binarymodel.GetBinaryMask();
            lblNetworkbits.Text = binarymodel.NetworkBits.ToString();
            lblHostbits.Text = binarymodel.HostBits.ToString();
        }


    }
}