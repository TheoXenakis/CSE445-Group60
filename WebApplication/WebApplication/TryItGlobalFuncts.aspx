<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryItGlobalFuncts.aspx.cs" Inherits="WebApplication.TryItGlobalFuncts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Global Functions Tracker</title>
    <style>
        .request-grid {
            margin-top: 20px;
            border-collapse: collapse;
            width: 80%;
        }
        .request-grid th, .request-grid td {
            border: 1px solid #ddd;
            padding: 8px;
        }
        .request-grid tr:nth-child(even) {
            background-color: #f2f2f2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Style="font-weight: 700" Text="Global.asax Statistics"></asp:Label>
        </div>
        <p>Theo Xenakis</p>
        <div style="margin-left: 40px">
            <h3>Current Statistics:</h3>
            <asp:Label ID="visitorCountLabel" runat="server" Text="Active Visitors: " />
            <asp:TextBox ID="txtActiveVisitors" runat="server" ReadOnly="true" Width="50px"></asp:TextBox>
            
            <br /><br />
            
            <asp:Label ID="requestCountLabel" runat="server" Text="Total Requests: " />
            <asp:TextBox ID="txtTotalRequests" runat="server" ReadOnly="true" Width="50px"></asp:TextBox>
            
            <br /><br />
            
            <asp:Button ID="btnRefresh" runat="server" Text="Refresh Counts" OnClick="btnRefresh_Click" />
            
            <h3 style="margin-top: 20px;">Recent Requests (Last 100):</h3>
            <asp:GridView ID="gvRecentRequests" runat="server"

                CssClass="request-grid"
                AutoGenerateColumns="true"
                EmptyDataText="No requests recorded yet">
                <HeaderStyle BackColor="#1a307f" ForeColor="White" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>