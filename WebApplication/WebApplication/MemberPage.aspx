<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberPage.aspx.cs" Inherits="WebApplication.MemberPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Dashboard</title>
    <style type="text/css">
        body {
            font-family: Arial, Helvetica, sans-serif;
            margin: 20px;
            background-color: #f8f9fa;
        }
        .header {
            background-color: #3D7169;
            color: white;
            padding: 20px;
            margin-bottom: 30px;
            border-radius: 5px;
        }
        .dashboard-section {
            max-width: 600px;
            margin: 0 auto;
            padding: 30px;
            background-color: white;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }
        .section-title {
            color: #3D7169;
            margin-bottom: 25px;
            font-size: 1.4em;
        }
        .button {
            padding: 12px 25px;
            background-color: #3399ff;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            margin: 10px 0;
            width: 100%;
            max-width: 300px;
        }
        .button:hover {
            background-color: #2678cc;
        }
        .member-info {
            font-size: 1.2em;
            color: #FFF;
            margin-bottom: 30px;
        }
        .section-group {
            margin: 30px 0;
            padding: 20px;
            border-bottom: 1px solid #eee;
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
            <h1>Member Dashboard</h1>
            <div class="member-info">
                Welcome back, <strong><asp:Label ID="Label4" runat="server"></asp:Label></strong>
            </div>
            <asp:Button ID="Logout_Button" runat="server" 
                OnClick="Logout_Clicked" 
                Text="Logout" 
                CssClass="logout" />
        </div>

        <div class="dashboard-section">
            <div class="section-group">
                <h3 class="section-title">Library Books</h3>
                <asp:Button ID="Button1" runat="server" 
                    OnClick="Button1_Click" 
                    Text="View Books For Sale" 
                    CssClass="button" />
            </div>

            <div class="section-group">
                <h3 class="section-title">Your Collection</h3>
                <asp:Button ID="Button2" runat="server" 
                    OnClick="Button2_Click" 
                    Text="View Purchased Books" 
                    CssClass="button" />
            </div>
        </div>
    </form>
</body>
</html>