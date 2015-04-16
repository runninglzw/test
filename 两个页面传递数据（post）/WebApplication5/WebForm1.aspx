<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication5.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" action="view.aspx">
    <table width="304" height="113" border="0"
    <tr>
    <td width="96">用户名：</td>
    <td width="198">
        <input id="Text1" type="text" name="text1" /></td>
    </tr>
    <tr>
    <td>密码：</td>
    <td>
        <input id="Password1" type="password" name="password1"/></td>
    </tr>
    <tr>
    <td height="39">
        <input id="Submit1" type="submit" value="提交" name="submit1"/></td>
        <td>
            <input id="Reset1" type="reset" value="重置" name="reset1"/></td>
    </tr>
    </form>
</body>
</html>
