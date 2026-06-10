using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetworkPlanner
{
    public partial class VLSMCalculator : System.Web.UI.Page
    {
        // ViewState helpers (For Dynamic Controls Generation)
        private int RowCount
        {
            get { return (int)(ViewState["RowCount"] ?? 0); }
            set { ViewState["RowCount"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            // Recreate dynamic rows on every postback
            for (int i = 0; i < RowCount; i++)
                CreateRow(i);
        }

        // Add Department entry rows
        protected void btnADD_Click(object sender, EventArgs e)
        {
            CreateRow(RowCount);
            RowCount++;
        }

        private void CreateRow(int index)
        {
            // Outer container
            Panel rowPanel = new Panel();
            rowPanel.ID = "row_" + index;
            rowPanel.CssClass = "vlsm-row-panel";

            // Row index label
            Literal idx = new Literal
            {
                Text = $"<span class=\"row-index\">#{index + 1:D2}</span>"
            };

            // Department name input
            TextBox txtDept = new TextBox();
            txtDept.ID = "txtDept_" + index;
            txtDept.CssClass = "";
            txtDept.Attributes["placeholder"] = "Department name";
            txtDept.Width = Unit.Empty;  // controlled by CSS flex

            // Hosts needed input
            TextBox txtHosts = new TextBox();
            txtHosts.ID = "txtHosts_" + index;
            txtHosts.Attributes["placeholder"] = "Hosts needed";
            txtHosts.Width = Unit.Empty;

            // Delete button
            Button btnDelete = new Button();
            btnDelete.Text = "✕ Remove";
            btnDelete.CssClass = "btn btn-danger";
            btnDelete.CommandArgument = index.ToString();
            btnDelete.Click += DeleteRow;
            // Prevent validation on delete
            btnDelete.CausesValidation = false;

            rowPanel.Controls.Add(idx);
            rowPanel.Controls.Add(txtDept);
            rowPanel.Controls.Add(txtHosts);
            rowPanel.Controls.Add(btnDelete);

            phRows.Controls.Add(rowPanel);
        }

        protected void DeleteRow(object sender, EventArgs e)
        {
            int indexToRemove = int.Parse(((Button)sender).CommandArgument);

            // Save current values from every row except the deleted one
            var saved = new List<(string dept, string hosts)>();
            for (int i = 0; i < RowCount; i++)
            {
                if (i == indexToRemove) continue;

                string dept = (FindControl("txtDept_" + i) as TextBox)?.Text ?? string.Empty;
                string hosts = (FindControl("txtHosts_" + i) as TextBox)?.Text ?? string.Empty;
                saved.Add((dept, hosts));
            }

            // Rebuild
            phRows.Controls.Clear();
            RowCount = 0;

            foreach (var (dept, hosts) in saved)
            {
                CreateRow(RowCount);

                // Restore values in newly created controls
                if (FindControl("txtDept_" + RowCount) is TextBox td) td.Text = dept;
                if (FindControl("txtHosts_" + RowCount) is TextBox th) th.Text = hosts;

                RowCount++;
            }

            // Hide results if visible
            pnlResults.Visible = false;
            lblError.Text = string.Empty;
        }


        // Calculate Address for each Subnet
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            pnlResults.Visible = false;

            // Get base IP address and CIDR and Validate
            string ipInput = txtIpAddress.Text.Trim();
            string cidrInput = txtCidr.Text.Trim();

            if (string.IsNullOrEmpty(ipInput) || string.IsNullOrEmpty(cidrInput))
            {
                lblError.Text = "Please enter a base IP address and CIDR prefix.";
                return;
            }

            // Use a temporary SubnetCalculatorModel for validation 
            var validator = new SubnetCalculatorModel();

            if (!validator.IsValidIpAddress(ipInput))
            {
                lblError.Text = "Invalid IP address format — expected x.x.x.x with each octet 0–255.";
                return;
            }

            if (!validator.IsValidCidr(cidrInput))
            {
                lblError.Text = "Invalid CIDR — enter a value between 0 and 32.";
                return;
            }

            int[] baseOctets = validator.Octets;
            int baseCidr = validator.CidrValue;

            // Read and validate subnet rows
            if (RowCount == 0)
            {
                lblError.Text = "Add at least one subnet row before calculating.";
                return;
            }

            var requests = new List<(string dept, int hosts)>();

            for (int i = 0; i < RowCount; i++)
            {
                string dept = (FindControl("txtDept_" + i) as TextBox)?.Text.Trim() ?? string.Empty;
                string hostsStr = (FindControl("txtHosts_" + i) as TextBox)?.Text.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(dept)) dept = $"Subnet {i + 1}";

                if (!int.TryParse(hostsStr, out int hosts) || hosts < 1)
                {
                    lblError.Text = $"Row #{i + 1}: Hosts needed must be a positive integer.";
                    return;
                }

                requests.Add((dept, hosts));
            }

            // -- VLSM allocation ----------------------------------------------------------
            // Sort largest first
            requests = requests.OrderByDescending(r => r.hosts).ToList();

            // Total addresses available in the base block
            int baseTotalAddresses = (int)Math.Pow(2, 32 - baseCidr);

            // Verify the total demand fits
            int totalRequired = requests.Sum(r =>
            {
                int cidrNeeded = VLSMModel.GetRequiredCidr(r.hosts);
                return (int)Math.Pow(2, 32 - cidrNeeded);
            });

            if (totalRequired > baseTotalAddresses)
            {
                lblError.Text = $"Not enough address space. Base /{baseCidr} has {baseTotalAddresses} addresses " +
                                $"but the subnets require at least {totalRequired}.";
                return;
            }

            // Walk through allocations
            var results = new List<VLSMModel>();
            int[] currentBase = (int[])baseOctets.Clone();
            int remaining = baseTotalAddresses;

            foreach (var (dept, hosts) in requests)
            {
                int cidrNeeded = VLSMModel.GetRequiredCidr(hosts);
                int blockSize = (int)Math.Pow(2, 32 - cidrNeeded);

                remaining -= blockSize;

                var subnet = new VLSMModel(
                    octets: (int[])currentBase.Clone(),
                    cidrValue: cidrNeeded,
                    departmentName: dept,
                    hostsNeeded: hosts,
                    remainingAddSpace: remaining
                );

                results.Add(subnet);

                // Advance the pointer to the next available network address
                currentBase = subnet.GetNextNetworkOctets();
            }

            // Render the results table
            BuildResultsTable(results);
            pnlResults.Visible = true;
        }

        // Results table builder
        private void BuildResultsTable(List<VLSMModel> results)
        {
            tblResults.Rows.Clear();

            // Header row
            TableRow header = new TableRow();
            header.CssClass = "";
            foreach (string col in new[] { "#", "Department", "Hosts Needed", "Network Address", "Subnet Mask",
                                           "First Host", "Last Host", "Broadcast", "Usable Hosts" })
            {
                header.Cells.Add(new TableHeaderCell { Text = col });
            }
            tblResults.Rows.Add(header);

            // Data rows
            int seq = 1;
            foreach (var s in results)
            {
                TableRow row = new TableRow();

                AddCell(row, seq.ToString(), "");
                AddCell(row, s.DepartmentName, "dept");
                AddCell(row, s.HostsNeeded.ToString(), "hosts-cell");
                AddCell(row, s.GetCidrNotation(), "mono");
                AddCell(row, s.GetSubnetMask(), "mono");
                AddCell(row, s.GetFirstHost(), "mono");
                AddCell(row, s.GetLastHost(), "mono");
                AddCell(row, s.GetBroadcastAddress(), "mono");
                AddCell(row, s.GetUsableHosts().ToString(), "hosts-cell");

                tblResults.Rows.Add(row);
                seq++;
            }
        }

        private static void AddCell(TableRow row, string text, string cssClass)
        {
            var cell = new TableCell { Text = text };
            if (!string.IsNullOrEmpty(cssClass)) cell.CssClass = cssClass;
            row.Cells.Add(cell);
        }
    }
}
