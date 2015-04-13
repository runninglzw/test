<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sendtalkmessage.aspx.cs" Inherits="WebApplication1.sendtalkmessage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 留言给
    
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    
    </div>
        <p>
            Email：<asp:TextBox ID="TextBox1" runat="server" ReadOnly="true"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                ControlToValidate="TextBox1" ErrorMessage="邮箱地址不正确" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </p>
        <p>
            留言内容：</p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server" Height="57px" Rows="1" 
                TextMode="MultiLine" Width="286px"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="留言" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="button" value="返回" onclick="history.go(-<%= (int)ViewState["back_no"] %>)" />
        </p>
    </form>
</body>
</html>
