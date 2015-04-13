<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showphoto.aspx.cs" Inherits="WebApplication1.showphoto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" 
            Width="801px">
        
            <ItemTemplate>
            <table>
               <img src="photos/<%# Eval("purl") %>" width="160" height="160" alt="" />
                <br/>
                <asp:Label ID="pnameLabel" runat="server" Text='<%# Eval("pname") %>' />
                <a href="?op=del&pid=<%# Eval("pid")%>&psid=<%# Eval("psid")%>">
                    删除</a>
                </table>
            </ItemTemplate> 
            
        </asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:photowallConnectionString %>" 
            SelectCommand="SELECT * FROM [photo] WHERE ([psid] = @psid)">
            <SelectParameters>
                <asp:SessionParameter Name="psid" SessionField="psid" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上传照片" />
    &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button２_Click" Text="返回相册列表" />
    </form>
</body>
</html>
