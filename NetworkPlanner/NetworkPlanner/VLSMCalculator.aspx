<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VLSMCalculator.aspx.cs" Inherits="NetworkPlanner.VLSMCalculator" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>NetworkPlanner — VLSM Calculator</title>
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
                    <a href="VLSMCalculator.aspx" class="active"><span>VLSM</span></a>
                    <a href="BinaryView.aspx"><span>Binary</span></a>
                </nav>
            </div>
        </header>

        <main class="page-wrapper">
            <div class="page-title">
                <p class="eyebrow">// variable-length subnet masking</p>
                <h1>VLSM Calculator</h1>
            </div>

            <%-- ── Base Network ─────────────────────────────────────────────── --%>
            <div class="card">
                <p class="card-title">Base Network</p>

                <asp:Label ID="lblError" runat="server" CssClass="error-msg" />

                <div class="form-grid">
                    <div class="form-group">
                        <label for="txtIpAddress">Base IP Address</label>
                        <asp:TextBox ID="txtIpAddress" runat="server" placeholder="e.g. 192.168.1.0" />
                    </div>
                    <div class="form-group">
                        <label for="txtCidr">Base CIDR Prefix</label>
                        <asp:TextBox ID="txtCidr" runat="server" placeholder="e.g. 24" />
                    </div>
                </div>
            </div>

            <%-- ── Subnet Rows ──────────────────────────────────────────────── --%>
            <div class="card">
                <p class="card-title">Subnets to Allocate</p>

                <%-- Dynamic rows rendered here by code-behind --%>
                <asp:PlaceHolder ID="phRows" runat="server" />

                <div class="flex-row mt-16">
                    <asp:Button ID="btnADD" runat="server" Text="+ Add Subnet"
                        OnClick="btnADD_Click" CssClass="btn btn-add"
                        CausesValidation="false" />
                </div>

                <asp:Label ID="lblSpace" runat="server" />
            </div>

            <%-- ── Actions ─────────────────────────────────────────────────── --%>
            <div class="flex-row mb-16">
                <asp:Button ID="btnCalculate" runat="server" Text="▶  Calculate VLSM"
                    OnClick="btnCalculate_Click" CssClass="btn btn-primary" />
            </div>

            <%-- ── Results ─────────────────────────────────────────────────── --%>
            <asp:Panel ID="pnlResults" runat="server" Visible="false">
                <div class="results-panel">
                    <p class="panel-header">Allocation Results — sorted largest-first</p>
                    <div class="vlsm-table-wrap">
                        <asp:Table ID="tblResults" runat="server" CssClass="vlsm-table" />
                    </div>
                </div>
            </asp:Panel>

        </main>


    </form>
</body>
</html>
