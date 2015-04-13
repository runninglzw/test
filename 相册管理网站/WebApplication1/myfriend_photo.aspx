<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myfriend_photo.aspx.cs" Inherits="WebApplication1.myfriend_photo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="5">
            <ItemTemplate>
                <img src="photos/<%# Eval("purl") %>" width="160" height="160" alt="" />
                <br />
                &nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="purlLabel" runat="server" Text='<%# Eval("pname") %>' /> &nbsp&nbsp&nbsp&nbsp&nbsp
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
    
        <br />
        <input type="button" value="返回" onclick="history.go(-<%= (int)ViewState["back_no"] %>)" />
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:photowallConnectionString %>" 
            SelectCommand="SELECT [pname], [purl] FROM [photo] WHERE (([username] = @username) AND ([psid] = @psid))">
            <SelectParameters>
                <asp:QueryStringParameter Name="username" QueryStringField="friendname" 
                    Type="String" />
                <asp:QueryStringParameter Name="psid" QueryStringField="psid" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
