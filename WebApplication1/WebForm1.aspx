<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 349px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            ADDRESS ID<asp:TextBox ID="addressid" runat="server"></asp:TextBox>
            <br />
            <br />
            FIRST NAME
            <asp:TextBox ID="fname" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style1"></asp:TextBox>
            <br />
            <br />
            LAST NAME<asp:TextBox ID="lname" runat="server"></asp:TextBox>
            <br />
            <br />
            PHONE NO.<asp:TextBox ID="phnno" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="UPDATE" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="DELETE" />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="INSERT" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="SEARCH" />
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
    </form>
</body>
</html>
