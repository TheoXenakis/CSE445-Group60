<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookLibrary.aspx.cs" Inherits="WebApplication.BookLibrary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <h2>Book Library</h2>
            <p>View all books in the library collection</p>
        </div>
        
        <div>
            <asp:GridView ID="GridViewBooks" runat="server" AutoGenerateColumns="False" 
                GridLines="None" OnRowCommand="GridViewBooks_RowCommand" CellPadding="10" CellSpacing="5">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="ButtonAddToCart" runat="server" 
                                CommandName="AddToCart" 
                                CommandArgument='<%# Eval("Id") %>' 
                                Text="Add to Cart" />
                            <asp:Button ID="Button2" runat="server" 
                                CommandName="RemoveFromCart" 
                                CommandArgument='<%# Eval("Id") %>' 
                                Text="Remove from Cart" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
