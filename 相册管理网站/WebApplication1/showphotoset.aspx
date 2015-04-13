<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showphotoset.aspx.cs" Inherits="WebApplication1.showphotoset" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" 
            OnSelectedIndexChanged="GridView1_SelectedIndexChanged" 
            OnRowCommand="GridView1_RowCommand" DataKeyNames="psname" OnRowUpdating="GridView1_RowUpdating" 
        >
            <Columns>
                <asp:BoundField DataField="psname" HeaderText="相册名" 
                    SortExpression="psname" />
                <asp:ButtonField CommandName="look" HeaderText="查看相片" Text="查看" />
                <asp:CommandField HeaderText="修改相册" ShowEditButton="True" />
                <asp:TemplateField HeaderText="删除相册">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" 
                            CommandName="del" Text="删除相册" OnClientClick="return confirm('确认删除？')"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="返回" OnClick="Button1_Click" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:photowallConnectionString %>" 
            
            SelectCommand="SELECT [psname] FROM [photoset] WHERE ([username] = @username)" 
            UpdateCommand="UPDATE photoset SET psname = @psname WHERE (username = @username)">
            <SelectParameters>
                <asp:SessionParameter Name="username" SessionField="username" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="psname" />
                <asp:Parameter Name="username" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
