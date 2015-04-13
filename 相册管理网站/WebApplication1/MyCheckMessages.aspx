<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCheckMessages.aspx.cs" Inherits="WebApplication1.MyCheckMessages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                fromname:
                <asp:Label ID="fromnameLabel" runat="server" Text='<%# Eval("fromname") %>' />
                <br />
                message:
                <asp:Label ID="messageLabel" runat="server" Text='<%# Eval("message") %>' />
                <br />
                <a href="?op=agree&fromname=<%# Eval("fromname")%>&message=<%# Eval("message")%>">同意</a>&nbsp&nbsp
                <a href="?op=ignore&fromname=<%# Eval("fromname")%>&message=<%# Eval("message")%>">忽略</a>
<br />
            </ItemTemplate>
        </asp:DataList>
        <br />
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:photowallConnectionString %>" 
            
            SelectCommand="SELECT [fromname], [message] FROM [checkmessages] WHERE (([toname] = @toname) AND ([ishandle] = @ishandle))">
            <SelectParameters>
                <asp:SessionParameter Name="toname" SessionField="username" Type="String" />
                <asp:Parameter DefaultValue="0" Name="ishandle" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
