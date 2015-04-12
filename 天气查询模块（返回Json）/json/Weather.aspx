<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Weather.aspx.cs" Inherits="json.Weather" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
<script type="text/javascript">

    function compareprice() {

        return true;<%--return false则表示不提交表单，也就是不执行onclick事件--%>
    }

</script>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="Button1" runat="server" Text="获取" OnClientClick="return compareprice()" OnClick="Button1_Click" />
    
    </div>
    <p>
        天气情况：<asp:label id="label1" runat="server" Text=""></asp:label></p>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Height="218px" 
            Width="353px"></asp:TextBox>
    </form>
    </body>
</html>
