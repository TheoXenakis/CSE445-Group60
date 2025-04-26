<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookLibrary.aspx.cs" Inherits="WebApplication.BookLibrary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Library</title>

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
        <a href="Default.aspx">← Back to Default.aspx</a> <br /> <br />

        <div class="header">
            <h2>Book Library</h2>
            <p>View all books in the library available for purchase</p>
        </div>
        
        <div>
            <asp:GridView ID="GridViewBooks" runat="server" AutoGenerateColumns="False" 
                GridLines="None" OnRowCommand="GridViewBooks_RowCommand" CellPadding="10" CellSpacing="5"
                CssClass="book-grid" AlternatingRowStyle-BackColor="#F8F8F8">
                <HeaderStyle HorizontalAlign="Left" BackColor="#3D7169" ForeColor="#FFFFFF" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="ButtonAddToCart" runat="server" 
                                CommandName="AddToCart" 
                                CommandArgument='<%# Eval("Id") %>' 
                                Text="Add to Cart" CssClass="button" />
                            <asp:Button ID="Button2" runat="server" 
                                CommandName="RemoveFromCart" 
                                CommandArgument='<%# Eval("Id") %>' 
                                Text="Remove" CssClass="button" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <div class="navigation">
            <asp:LinkButton ID="bookServiceBtn" runat="server" OnClick="ViewCartBtn_Click" 
                CssClass="cart-link">View Shopping Cart</asp:LinkButton>
        </div>
    </form>
</body>
</html>
