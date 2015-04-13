<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myfriend_photoset.aspx.cs" Inherits="WebApplication1.myfriend_photoset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    好友相册<br />
        <br />
&nbsp;<asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" 
            RepeatColumns="5" DataKeyField="psid" OnItemCommand="DataList1_ItemCommand" >
        <ItemTemplate>
         <%--界面将myfriends字段传给后台，后台使用事件处理（DataList1_ItemCommand）或命令处理获得myfriends字段，然后将获得的字段传给另一个页面，CommandArgument传递参数，CommandName传递命令类型--%>
        <asp:ImageButton id="imagebutton1" runat="server" ImageUrl="~/Images/1.png" Width="150" CommandArgument='<%# Eval("psid") %>' CommandName="Link" ></asp:ImageButton>
        <br />
        <br />
            &nbsp&nbsp&nbsp&nbsp<asp:Label ID="psnameLabel" runat="server" Text='<%# Eval("psname") %>' />
            &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
            <br />
<br />
            <br />
        </ItemTemplate>
        </asp:DataList>
        <br />
        <br />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="留言" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <input type="button" value="返回" onclick="history.go(-<%= (int)ViewState["back_no"] %>)" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:photowallConnectionString %>" 
            
            
            SelectCommand="SELECT [psname], [createtime], [psid] FROM [photoset] WHERE (([psstate] = @psstate) AND ([username] = @username))">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="psstate" Type="Int32" />
                <asp:QueryStringParameter Name="username" QueryStringField="friendname" 
                    Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
</div>
    </form>
</body>
</html>
