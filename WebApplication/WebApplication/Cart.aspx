﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebApplication.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Shopping Cart</title>

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
        .button_blue {
            padding: 8px 16px;
            margin-right: 10px;
            background-color: #3399ff;
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
        <div class="header">
            <h2>Your Shopping Cart</h2>
            <p>Review the books in your cart before checkout</p>
        </div>
        
        <div id="cartContent" runat="server">
            <asp:GridView CellPadding="5" CellSpacing="20" ID="GridViewCart" runat="server" AutoGenerateColumns="False" 
                CssClass="cart-grid" GridLines="None" OnRowCommand="GridViewCart_RowCommand"
                ShowFooter="true" EmptyDataText="Your cart is empty">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />

                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="ButtonRemove" runat="server" 
                                CommandName="RemoveItem" 
                                CommandArgument='<%# Eval("Id") %>' 
                                Text="Remove" CssClass="button" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle CssClass="total-row" />
            </asp:GridView>
        </div>
        
        <div class="navigation">
            <asp:Button ID="ButtonContinueShopping" runat="server" Text="Continue Shopping" 
                OnClick="ButtonContinueShopping_Click" CssClass="button" />
        </div>

        <div class="header" style="margin-top:20px;">
            <h2>Checkout</h2>
            <p>If your cart looks good, purchase your books here</p>
        </div>

        Subtotal: $<asp:Label ID="CartTotalLabel" runat="server"></asp:Label> <br />
        Total with Tax (4.712%): $<asp:Label ID="CartTaxTotalLabel" runat="server"></asp:Label>

        <div style="margin-top:20px">
            <h3>Select Payment Method</h3>

            <label>
                <input type="radio" name="paymentMethod" checked="checked" value="creditCard" />
                <span>Credit Card</span>
            </label>

            <label>
                <input type="radio" name="paymentMethod" value="check" />
                <span>Check</span>
            </label>

            <label>
                <input type="radio" name="paymentMethod" value="paypal" />
                <span>PayPal</span>
            </label>

            <br /> <br />

            <asp:Button runat="server" ID="PurchaseBtn" Text="Complete Purchase" 
                OnClick="BuyNowButton_Click" CssClass="button_blue" />
        </div>
    </form>
</body>
</html>
