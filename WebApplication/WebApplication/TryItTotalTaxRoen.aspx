<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItTotalTaxRoen.aspx.cs" Inherits="WebApplication.TryItTotalTaxRoen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Try It Page Total & Tax Calculation Service</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Total & Tax Calculation Service Try It Page</h1>

            <h2>Calculate Total Prices</h2>
            <div>
                <label for="txtPrices">Enter Prices (comma-separated):</label><br />
                <asp:TextBox ID="txtPrices" runat="server" Width="300px" />
            </div>
            <br />
            <div>
                <asp:Button ID="btnCalculateTotal" runat="server" Text="Calculate Total" OnClick="calcTotal" />
            </div>
            <br />
            <div>
                <label>Total (Before Tax):</label><br />
                <asp:Label ID="lblTotal" runat="server" Text="None" />
            </div>

            <hr />

            <h2>Calculate Tax</h2>
            <div>
                <label for="txtSubtotal">Enter Subtotal:</label><br />
                $ <asp:TextBox ID="txtSubtotal" runat="server" Width="100px" />
            </div>
            <br />
            <div>
                <label for="txtTaxRate">Enter Tax as floating point number (e.g., 0.055 for 5.5%):</label><br />
                <asp:TextBox ID="txtTaxRate" runat="server" Width="100px" /> * 100 %
            </div>
            <br />
            <div>
                <asp:Button ID="btnCalculateTax" runat="server" Text="Calculate Post-Tax Total" OnClick="calcTax" />
            </div>
            <br />
            <div>
                <label>Total (Including Tax):</label><br />
                <asp:Label ID="lblTotalWithTax" runat="server" Text="None" />
            </div>
        </div>
    </form>
</body>
</html>
