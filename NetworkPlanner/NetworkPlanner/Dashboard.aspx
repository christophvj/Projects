<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="NetworkPlanner.Dashboard" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>NetworkPlanner — Dashboard</title>
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
                    <a href="Dashboard.aspx" class="active"><span>Dashboard</span></a>
                    <a href="SubnetCalculator.aspx"><span>Subnet</span></a>
                    <a href="VLSMCalculator.aspx"><span>VLSM</span></a>
                    <a href="BinaryView.aspx"><span>Binary</span></a>
                </nav>
            </div>
        </header>

        <main class="page-wrapper">
            <div class="page-title">
                <p class="eyebrow">// NetworkPlanner v1.0</p>
                <h1>IP Address Tools</h1>
            </div>

            <div class="card">
                <p class="card-title">Available Tools</p>
                <div class="dash-grid">

                    <a class="dash-card" href="SubnetCalculator.aspx">
                        <div class="dc-icon">⊞</div>
                        <div class="dc-title">Subnet Calculator</div>
                        <div class="dc-desc">Calculate network address, broadcast, host range, wildcard mask, and class type from any IP/CIDR pair.</div>
                        <div class="dc-arrow">→ Open</div>
                    </a>

                    <a class="dash-card" href="VLSMCalculator.aspx">
                        <div class="dc-icon">◫</div>
                        <div class="dc-title">VLSM Calculator</div>
                        <div class="dc-desc">Variable-length subnet masking. Allocate efficient subnets to multiple departments from a single address block.</div>
                        <div class="dc-arrow">→ Open</div>
                    </a>

                    <a class="dash-card" href="BinaryView.aspx">
                        <div class="dc-icon">◉</div>
                        <div class="dc-title">Binary View</div>
                        <div class="dc-desc">Inspect your IP address and subnet mask in binary — see exactly which bits define the network and host portions.</div>
                        <div class="dc-arrow">→ Open</div>
                    </a>

                </div>
            </div>

            <div class="card">
                <p class="card-title">Quick Reference</p>
                <table class="vlsm-table">
                    <thead>
                        <tr>
                            <th>CIDR</th><th>Subnet Mask</th><th>Total Addresses</th><th>Usable Hosts</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr><td class="mono">/24</td><td class="mono">255.255.255.0</td><td class="mono">256</td><td class="hosts-cell">254</td></tr>
                        <tr><td class="mono">/25</td><td class="mono">255.255.255.128</td><td class="mono">128</td><td class="hosts-cell">126</td></tr>
                        <tr><td class="mono">/26</td><td class="mono">255.255.255.192</td><td class="mono">64</td><td class="hosts-cell">62</td></tr>
                        <tr><td class="mono">/27</td><td class="mono">255.255.255.224</td><td class="mono">32</td><td class="hosts-cell">30</td></tr>
                        <tr><td class="mono">/28</td><td class="mono">255.255.255.240</td><td class="mono">16</td><td class="hosts-cell">14</td></tr>
                        <tr><td class="mono">/29</td><td class="mono">255.255.255.248</td><td class="mono">8</td><td class="hosts-cell">6</td></tr>
                        <tr><td class="mono">/30</td><td class="mono">255.255.255.252</td><td class="mono">4</td><td class="hosts-cell">2</td></tr>
                    </tbody>
                </table>
            </div>
        </main>


    </form>
</body>
</html>
