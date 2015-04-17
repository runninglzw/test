<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="send.aspx.cs" Inherits="send.send" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 188px;
        }
        .style2
        {
            width: 188px;
            height: 105px;
        }
        .style3
        {
            height: 105px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table style="width: 100%; height: 274px;">
            <tr>
                <td class="style2">
                    URL地址：</td>
                <td class="style3">
                    <asp:Label ID="url" runat="server" Text=""></asp:Label>
                </td>

            </tr>
            <tr>
                <td class="style1">
                    请输入你要推送的消息：</td>
                <td>
                    <asp:TextBox ID="msg" runat="server" Height="36px" Width="550px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="style1">
                    推送的方式：</td>
                <td>
                    <asp:Button ID="SendToast" runat="server"  Text="发送Toast消息" 
                        Width="113px" onclick="SendToast_Click" />
                    <asp:Button ID="SendTile" runat="server" Text="发送Tile消息" Width="128px" 
                        onclick="SendTile_Click" />
                    <asp:Button ID="SendRaw" runat="server" Text="发送Raw消息" Width="127px" 
                        onclick="SendRaw_Click" />
                </td>

            </tr>
            <tr>
                <td class="style1">
                    发送状态：</td>
                <td>
                 <asp:Label ID="state" runat="server" Text=""></asp:Label>
                </td>

            </tr>
        </table>
    </div>
    </form>
</body>
</html>
