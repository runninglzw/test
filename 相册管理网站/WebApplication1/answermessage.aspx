<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="answermessage.aspx.cs" Inherits="WebApplication1.answermessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 回复留言<br />
        <br />
        留言人：<asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox>
        <br />
        <br />
        留言内容：<br />
        <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" ReadOnly="true" 
            Height="53px" Width="207px"></asp:TextBox>
        <br />
        <br />
        回复内容：<br />
        <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Height="52px" 
            Width="207px"></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="回复" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;
        <input type="button" value="返回" onclick="history.go(-<%= (int)ViewState["back_no"] %>)" />
    
    </div>
    </form>
</body>
</html>
