<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Store Hub</title>
    <style type="text/css">
        body {
            font-family: Arial, Helvetica, sans-serif;
            margin: 20px;
            background-color: #f8f9fa;
        }
        .header {
            background-color: #3D7169;
            color: white;
            padding: 20px;
            margin-bottom: 30px;
            border-radius: 5px;
        }
        .main-content {
            max-width: 1200px;
            margin: 0 auto;
            padding: 30px;
            background-color: white;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }
        .section-title {
            color: #3D7169;
            margin: 30px 0;
            font-size: 1.8em;
        }
        .button {
            padding: 10px 20px;
            background-color: #3399ff;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            margin: 10px 0;
            text-decoration: none;
            display: inline-block;
        }
        .button:hover {
            background-color: #2678cc;
        }
        .description {
            margin: 25px 0;
            padding: 20px;
            background-color: #f8f9fa;
            border-radius: 4px;
            line-height: 1.6;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin: 25px 0;
            box-shadow: 0 1px 3px rgba(0,0,0,0.1);
        }
        table th {
            background-color: #3D7169;
            color: white;
            padding: 15px;
            text-align: left;
        }
        table td {
            padding: 12px;
            border-bottom: 1px solid #ddd;
            text-align: left;
        }
        table tr:nth-child(even) {
            background-color: #f9f9f9;
        }
        table tr:hover {
            background-color: #f1f1f1;
        }
        .portal-section {
            margin: 30px 0;
            padding: 20px;
            border-bottom: 1px solid #eee;
        }
        .portal-title {
            color: #444;
            font-size: 1.4em;
            margin-bottom: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h1>Book Store Management Portal</h1>
        </div>

        <div class="main-content">
            <div class="portal-section">
                <h3 class="portal-title">Quick Access</h3>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" 
                    Text="Member Portal" CssClass="button" />
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" 
                    Text="Staff Portal" CssClass="button" />
            </div>

            <div class="description">
                <h3 class="section-title">Application Overview</h3>
                <p>A comprehensive e-commerce platform for book enthusiasts. Features include:</p>
                <ul>
                    <li>User registration and authentication</li>
                    <li>Book browsing and purchasing</li>
                    <li>Shopping cart management</li>
                    <li>Order processing with tax calculation</li>
                    <li>Inventory management for staff</li>
                </ul>
            </div>

            <h3 class="section-title">Service Directory</h3>
            <table>
                <thead>
                    <tr>
                        <th>Service Provider</th>
                        <th>Service Details</th>
                        <th>Try It</th>
                        <th>Description</th>
                        <th>Implementation Requirements</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>Roen Wainscoat</td>
                        <td>
                            <strong>TotalAndTaxSvc</strong><br />
                            calculateTotal(ArrayList prices) : float<br />
                            calculateTax(float subtotal, float taxRate) : float
                        </td>
                        <td>
                            <a href="TryItTotalTaxRoen.aspx" class="button">Test Service</a>
                        </td>
                        <td>Cart/checkout processing with total calculation and tax computation</td>
                        <td>WCF service with iterative price summation and tax calculation logic</td>
                    </tr>
                    <tr>
                        <td>John Bostater</td>
                        <td><strong>DataBase Services</strong></td>
                        <td>
                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click" 
                                CssClass="button">Test Service</asp:LinkButton>
                        </td>
                        <td>Account management system for staff and members</td>
                        <td>WCF service with database integration for user authentication</td>
                    </tr>
                    <tr>
                        <td>Theo Xenakis</td>
                        <td><strong>Book Services</strong></td>
                        <td>
                            <asp:LinkButton ID="bookServiceBtn" runat="server" OnClick="BookServiceBtn_Click" 
                                CssClass="button">Test Service</asp:LinkButton>
                        </td>
                        <td>Inventory management with book metadata handling</td>
                        <td>WCF service for add/delete operations integrated with database</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>