   <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myfriends.aspx.cs" Inherits="WebApplication1.myfriends" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        我的好友列表<br />
        <br />
    
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
            <%--界面将myfriends字段传给后台，后台使用事件处理或命令处理（myfriendsLabel_Command）获得myfriends字段，然后将获得的字段传给另一个页面，CommandArgument传递参数，CommandName传递命令类型--%>
                &nbsp<asp:LinkButton ID="myfriendsLabel" runat="server" Text='<%# Eval("myfriends") %>' CommandArgument='<%#Eval("myfriends") %>' OnCommand="myfriendsLabel_Command"/>
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:photowallConnectionString %>" 
            SelectCommand="SELECT [myfriends] FROM [friendslist] WHERE ([myname] = @myname)">
            <SelectParameters>
                <asp:SessionParameter Name="myname" SessionField="username" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
