<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="mymessages.aspx.cs" Inherits="WebApplication1.mymessages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1"  OnItemCommand="DataList1_ItemCommand">
            <ItemTemplate>
                留言人:
                <asp:Label ID="friendnameLabel" runat="server" 
                    Text='<%# Eval("friendname") %>' />
                <br />
                邮箱:
                <asp:Label ID="friendemailLabel" runat="server" 
                    Text='<%# Eval("friendemail") %>' />
                <br />
                留言时间:
                <asp:Label ID="talkdateLabel" runat="server" Text='<%# Eval("talkdate") %>' />
                <br />
                留言内容:
                <asp:Label ID="contentsLabel" runat="server" Text='<%# Eval("contents") %>' />
                <br />
                <br />
                <%-- button传递多个参数 利用CommandArgument--%>
                &nbsp&nbsp<asp:Button ID="Button1" runat="server" Text="回复" CommandArgument='<%# Eval("friendname")+"|"+ Eval("contents") %>' CommandName="answer"></asp:Button>&nbsp&nbsp&nbsp
                <asp:Button ID="Button2" runat="server" Text="忽略" CommandArgument='<%# Eval("friendname")+"|"+  Eval("contents") %>' CommandName="ignore"></asp:Button>
<br />
<br />
            </ItemTemplate>
        </asp:DataList>
    
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="返回" />
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:photowallConnectionString %>" 
            SelectCommand="SELECT [friendname], [friendemail], [talkdate], [contents] FROM [talkmessage] WHERE (([myname] = @myname) AND ([ishandle] = @ishandle))">
            <SelectParameters>
                <asp:SessionParameter Name="myname" SessionField="username" Type="String" />
                <asp:Parameter DefaultValue="0" Name="ishandle" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
