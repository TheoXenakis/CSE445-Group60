<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookManager.aspx.cs" Inherits="BookApplication.BookManager" %>

<!-- Theo Xenakis -->

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Manager</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Book Manager</h1>
            
            <div>
                <div>
                    <asp:Label ID="LabelTitle" runat="server" Text="Title:"></asp:Label>
                    <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Label ID="LabelAuthor" runat="server" Text="Author:"></asp:Label>
                    <asp:TextBox ID="TextBoxAuthor" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="ButtonAddBook" runat="server" Text="Add Book" OnClick="ButtonAddBook_Click" />
                </div>
            </div>
            
            <div>
                <h2>Books</h2>
                <asp:GridView ID="GridViewBooks" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Author" HeaderText="Author" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>