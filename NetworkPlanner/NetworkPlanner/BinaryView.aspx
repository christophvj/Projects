<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BinaryView.aspx.cs" Inherits="NetworkPlanner.BinaryView" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>NetworkPlanner — Binary View</title>
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
                    <a href="SubnetCalculator.aspx"><span>Subnet</span></a>
                    <a href="VLSMCalculator.aspx"><span>VLSM</span></a>
                    <a href="BinaryView.aspx" class="active"><span>Binary</span></a>
                </nav>
            </div>
        </header>

        <main class="page-wrapper">
            <div class="page-title">
                <p class="eyebrow">// binary view</p>
                <h1>Binary Representation</h1>
            </div>

            <div class="card">
                <p class="card-title">Source Address</p>
                <div class="result-grid">
                    <span class="result-label">IP Address</span>
                    <span class="result-value"><asp:Label ID="lblIpAddress" runat="server" /></span>
                    <span class="result-label">CIDR Prefix</span>
                    <span class="result-value">/<asp:Label ID="lblCidrValue" runat="server" /></span>
                </div>
            </div>

            <div class="card">
                <p class="card-title">Binary Breakdown</p>

                <div class="binary-group">
                    <span class="blabel">IP Address (binary)</span>
                    <span class="binary-display text-cyan">
                        <asp:Label ID="lblIpResult" runat="server" />
                    </span>
                </div>

                <div class="binary-group">
                    <span class="blabel">Subnet Mask (binary)</span>
                    <span class="binary-display text-green">
                        <asp:Label ID="lblMaskResult" runat="server" />
                    </span>
                </div>

                <div class="bit-stats mt-16">
                    <div class="bit-stat bs-network">
                        <span class="bs-value"><asp:Label ID="lblNetworkbits" runat="server" /></span>
                        <span class="bs-label">Network Bits</span>
                    </div>
                    <div class="bit-stat bs-host">
                        <span class="bs-value"><asp:Label ID="lblHostbits" runat="server" /></span>
                        <span class="bs-label">Host Bits</span>
                    </div>
                </div>
            </div>

            <div class="flex-row mt-8">
                <a href="SubnetCalculator.aspx" class="btn btn-secondary">← Back to Subnet Calculator</a>
            </div>
        </main>


    </form>
</body>
</html>
