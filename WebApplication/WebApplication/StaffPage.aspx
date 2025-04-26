<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffPage.aspx.cs" 
    Inherits="WebApplication.StaffPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Portal</title>
    <style>
        .book-section { margin: 20px 0; padding: 15px; border: 1px solid #ddd; }
        .grid-view { margin-top: 20px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <strong>Staff:</strong>
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            
            <!-- Existing content remains above this line -->
            
            <!-- New Book Management Section -->
            <div class="book-section">
                <h3>Book Management</h3>
                <div>
                    <asp:Label runat="server" Text="Title:" AssociatedControlID="txtTitle"></asp:Label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" Text="Author:" AssociatedControlID="txtAuthor"></asp:Label>
                    <asp:TextBox ID="txtAuthor" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" Text="Year:" AssociatedControlID="txtYear"></asp:Label>
                    <asp:TextBox ID="txtYear" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" Text="Genre:" AssociatedControlID="txtGenre"></asp:Label>
                    <asp:TextBox ID="txtGenre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnAddBook" runat="server" Text="Add Book" 
                    OnClick="btnAddBook_Click" />
            </div>

            <div class="grid-view">
                <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="Id" OnRowDeleting="gvBooks_RowDeleting"
                    CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Author" HeaderText="Author" />
                        <asp:BoundField DataField="Year" HeaderText="Year" />
                        <asp:BoundField DataField="Genre" HeaderText="Genre" />
                        <asp:CommandField ShowDeleteButton="True" ButtonType="Button" 
                            DeleteText="Delete" ControlStyle-CssClass="btn btn-danger" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="notification">
                <asp:Label ID="lblNotification" runat="server" ForeColor="Red" Visible="false" />
            </div>
        </div>
    </form>
</body>
</html>