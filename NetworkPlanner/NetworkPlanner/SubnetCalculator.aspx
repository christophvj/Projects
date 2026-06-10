<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubnetCalculator.aspx.cs" Inherits="NetworkPlanner.SubnetCalculator" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>NetworkPlanner — Subnet Calculator</title>
    <link rel="stylesheet" href="Styles/site.css" />
</head>
<body>
    <form id="form1" runat="server">

        <header class="site-header">
            <div class="site-header-inner">
                <div class="site-logo">
                    <div class="logo-icon">NP</div>
                    <span>Network<span class="logo-accent">Planner</span></span>
                </div>
                <nav class="site-nav">
                    <a href="Dashboard.aspx"><span>Dashboard</span></a>
                    <a href="SubnetCalculator.aspx" class="active"><span>Subnet</span></a>
                    <a href="VLSMCalculator.aspx"><span>VLSM</span></a>
                    <a href="BinaryView.aspx"><span>Binary</span></a>
                </nav>
            </div>
        </header>

        <main class="page-wrapper">
            <div class="page-title">
                <p class="eyebrow">// subnet calculator</p>
                <h1>Subnet Calculator</h1>
            </div>

            <div class="card">
                <p class="card-title">Input</p>

                <asp:Label ID="lblError" runat="server" CssClass="error-msg" />

                <div class="form-grid">
                    <div class="form-group">
                        <label for="txtIPAddress">IP Address</label>
                        <asp:TextBox ID="txtIPAddress" runat="server" placeholder="e.g. 192.168.1.0" />
                    </div>
                    <div class="form-group">
                        <label for="txtCIDR">CIDR Prefix</label>
                        <asp:TextBox ID="txtCIDR" runat="server" placeholder="e.g. 24" />
                    </div>
                </div>

                <div class="flex-row">
                    <asp:Button ID="btnCalculate" runat="server" Text="▶  Calculate"
                        OnClick="btnCalculate_Click" CssClass="btn btn-primary" />
                    <a href="BinaryView.aspx" class="btn btn-secondary">◉  Binary View</a>
                    <a href="VLSMCalculator.aspx" class="btn btn-secondary">◫  VLSM</a>
                </div>
            </div>

            <div class="results-panel">
                <p class="panel-header">Results</p>
                <div class="result-grid">
                    <span class="result-label">Subnet Mask</span>
                    <span class="result-value"><asp:Label ID="lblSubnetMask" runat="server" Text="—" /></span>

                    <span class="result-label">Network Address</span>
                    <span class="result-value"><asp:Label ID="lblNetwork" runat="server" Text="—" /></span>

                    <span class="result-label">Broadcast Address</span>
                    <span class="result-value"><asp:Label ID="lblBroadcast" runat="server" Text="—" /></span>

                    <span class="result-label">First Usable Host</span>
                    <span class="result-value"><asp:Label ID="lblFirstHost" runat="server" Text="—" /></span>

                    <span class="result-label">Last Usable Host</span>
                    <span class="result-value"><asp:Label ID="lblLastHost" runat="server" Text="—" /></span>

                    <span class="result-label">Host Range</span>
                    <span class="result-value"><asp:Label ID="lblRange" runat="server" Text="—" /></span>

                    <span class="result-label">Wildcard Mask</span>
                    <span class="result-value"><asp:Label ID="lblWildcardMask" runat="server" Text="—" /></span>

                    <span class="result-label">Total Addresses</span>
                    <span class="result-value"><asp:Label ID="lblTotalHosts" runat="server" Text="—" /></span>

                    <span class="result-label">Usable Hosts</span>
                    <span class="result-value"><asp:Label ID="lblUsableHosts" runat="server" Text="—" /></span>

                    <span class="result-label">IP Class</span>
                    <span class="result-value"><asp:Label ID="lblClass" runat="server" Text="—" /></span>
                </div>
            </div>
        </main>


    </form>
</body>
</html>
