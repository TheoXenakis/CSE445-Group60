<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffPage.aspx.cs" 
    Inherits="WebApplication.StaffPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Portal</title>
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
        .book-section { 
            margin: 20px 0; 
            padding: 15px; 
            border: 1px solid #ddd;
            background-color: #fff;
            border-radius: 5px;
        }
        .grid-view {
            margin-top: 20px;
            width: 100%;
        }
        .table {
            width: 100%;
            border-collapse: separate;
            border-spacing: 8px;
        }
        .table th {
            background-color: #3D7169;
            color: white;
            padding: 12px;
            text-align: left;
            border: none;
        }
        .table td {
            padding: 12px;
            border: none;
            background-color: #f8f9fa;
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
        .btn-danger {
            background-color: #dc3545 !important;
        }
        .form-control {
            padding: 6px 12px;
            border: 1px solid #ddd;
            border-radius: 4px;
            margin: 5px 0;
        }
        .notification {
            margin: 15px 0;
            padding: 10px;
            border-radius: 5px;
        }
        label {
            display: block;
            margin: 8px 0;
            font-weight: bold;
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
        <div class="header">
            <h2>Staff Portal</h2>
            <p>Welcome, <asp:Label ID="Label3" runat="server" Text=""></asp:Label></p>
            <div class="navigation">
    <asp:Button ID="LogoutButton" runat="server" Text="Logout"
        OnClick="Logout_Click" CssClass="logout" />
</div>
        </div>

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
            <div>
                <asp:Label runat="server" Text="Price:" AssociatedControlID="txtPrice"></asp:Label>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="btnAddBook" runat="server" Text="Add Book" 
                OnClick="btnAddBook_Click" CssClass="button" />
        </div>

        <div class="grid-view">
            <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Id" OnRowDeleting="gvBooks_RowDeleting"
                CssClass="table" GridLines="None">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                    <asp:BoundField DataField="Year" HeaderText="Year" />
                    <asp:BoundField DataField="Genre" HeaderText="Genre" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" 
                        DeleteText="Delete" ControlStyle-CssClass="button btn-danger" />
                </Columns>
            </asp:GridView>
        </div>

        <div class="notification">
            <asp:Label ID="lblNotification" runat="server" ForeColor="Red" Visible="false" />
        </div>
    </form>
</body>
</html>