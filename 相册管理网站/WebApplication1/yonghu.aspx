<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="yonghu.aspx.cs" Inherits="WebApplication1.yonghu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">修改密码</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">修改用户信息</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">相册列表</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">增加相册</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click">添加好友</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">我的好友列表</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click">验证消息</asp:LinkButton>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">我的留言板</asp:LinkButton>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="退出" />
    </form>
</body>
</html>
