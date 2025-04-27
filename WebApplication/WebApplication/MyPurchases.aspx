<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyPurchases.aspx.cs" Inherits="WebApplication.MyPurchases" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View My Purchases</title>

    <style type="text/css">
        body {
            font-family: Arial, Helvetica, sans-serif;
            margin: 20px;
        }
        .header {
            background-color: #f0f0f0;
            padding: 10px;
            margin-bottom: 20px;
            border-radius: 5px;
        }
        .book-grid {
            width: 100%;
            border-collapse: separate;
            border-spacing: 15px;
        }
        .book-grid th {
            background-color: #3D7169;
            color: white;
            padding: 15px;
            text-align: left;
            border: none;
        }
        .book-grid td {
            padding: 15px;
            border: none;
        }
        .book-grid tr:nth-child(even) {
            background-color: #F8F8F8;
        }
        .navigation {
            margin-top: 20px;
        }
        .button {
            padding: 8px 16px;
            margin-right: 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 4px;
        }
        .back_button {
            padding: 8px 16px;
            margin-right: 10px;
            background-color: #BDBDBD;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 4px;
        }
        .cart-link {
            display: inline-block;
            margin-top: 20px;
            padding: 10px 15px;
            background-color: #6C6B66;
            color: white;
            text-decoration: none;
            border-radius: 4px;
        }
        .no-purchases {
            padding: 20px;
            background-color: #f9f9f9;
            border-radius: 5px;
            text-align: center;
            margin: 20px 0;
        }
        .logout {
            padding: 8px 16px;
            margin-right: 10px;
            background-color: #D32F2F;
            color: white;
            border: none;
            cursor: pointer;
            border-radius: 4px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header">
                <h2>My Purchases</h2>
                <p>View all your purchases here</p>
                <asp:Button ID="BackButton" runat="server" Text="Back"
    OnClick="Back_Clicked" CssClass="back_button" />
            </div>
            
            <asp:GridView ID="GridViewPurchases" runat="server" AutoGenerateColumns="False" 
                CssClass="book-grid" GridLines="None" EmptyDataText="You haven't made any purchases yet."
                AlternatingRowStyle-BackColor="#F8F8F8">
                <HeaderStyle HorizontalAlign="Left" BackColor="#3D7169" ForeColor="#FFFFFF" />
                <Columns>
                    <asp:BoundField DataField="BookTitle" HeaderText="Book Title" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="PurchaseDate" HeaderText="Purchase Date" />
                </Columns>
            </asp:GridView>
            
            <div class="navigation">
                <asp:Button ID="ButtonContinueShopping" runat="server" Text="Continue Shopping" 
                    OnClick="ButtonContinueShopping_Click" CssClass="button" />
                <asp:Button ID="LogoutButton" runat="server" Text="Logout"
                    OnClick="Logout_Click" CssClass="logout" />
            </div>
        </div>
    </form>
</body>
</html>
