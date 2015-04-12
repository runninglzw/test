<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        获取天气情况：<br />
        <br />
        选择省份:<asp:TextBox 
            ID="TextBox1" runat="server"></asp:TextBox>
            &nbsp<asp:Button ID="button1" runat="server" Text="获取" 
            OnClick="button1_Click" />&nbsp
            <br />
        <br />
        天气：<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>
        <asp:TextBox ID="TextBox2" runat="server" Height="385px" TextMode="MultiLine" 
            Width="414px"></asp:TextBox>
    </form>
</body>
</html>
