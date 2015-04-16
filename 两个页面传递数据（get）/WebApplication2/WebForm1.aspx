<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server" >
    用户名:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <br />
    <br />
    &nbsp;密码：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <br />
    <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />  
        &nbsp;&nbsp;&nbsp;  
        <asp:Button ID="Button2" runat="server" Text="重置" /> 
    </form>
</body>
</html>
