<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Weather.aspx.cs" Inherits="WebApplication1.Weather" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        省份：<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
    
    &nbsp; 城市：<asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
        </asp:DropDownList>
    
    &nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="获取" />
        <br />
        <br />
        <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
            <br />
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
            <br />
        </div>
    
    </div>
    </form>
</body>
</html>
