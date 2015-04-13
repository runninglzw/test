<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMessage.aspx.cs" Inherits="WebApplication1.SendMessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    &nbsp;&nbsp;&nbsp; 好友验证<br />
        <br />
        发送给：<asp:Label ID="Label1" runat="server"></asp:Label>
    
    </div>
        <p>
            附加消息：</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Height="67px" 
                style="margin-left: 0px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="发送" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回" />
        </p>
    </form>
</body>
</html>
