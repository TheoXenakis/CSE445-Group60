<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseComplete.aspx.cs" Inherits="WebApplication.PurchaseComplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thank You</title>

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
            border-spacing: 8px;
        }
        .book-grid th {
            background-color: #3D7169;
            color: white;
            padding: 12px;
            text-align: left;
            border: none;
        }
        .book-grid td {
            padding: 12px;
            border: none;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header">
                <h2>Thank You!</h2>
                <p>Your purchase has been completed</p>
            </div>

            <asp:Button ID="ButtonContinueShopping" runat="server" Text="Continue Shopping" 
                OnClick="ButtonContinueShopping_Click" CssClass="button" />

            <asp:Button ID="ViewPurchasesButton" runat="server" Text="My Purchases" 
                OnClick="ButtonViewPurchases_Click" CssClass="button" />
        </div>
    </form>
</body>
</html>
