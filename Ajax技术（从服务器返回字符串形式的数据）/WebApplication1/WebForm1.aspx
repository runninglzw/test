<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <label for="txt_username">
        姓名:</label>
    <input type="text" id="txt_username" />
    <br />
    <label for="txt_age">
        年龄:</label>
    <input type="text" id="txt_age" />
    <br />
    <input type="button" value="GET" id="btn" onclick="btn_click();" />
    <div id="result">
    </div>
    <script type="text/javascript">
        function btn_click() {
            //创建XMLHttpRequest对象
            var xmlHttp = new XMLHttpRequest();

            //获取值
            var username = document.getElementById("txt_username").value;
            var age = document.getElementById("txt_age").value;

            //配置XMLHttpRequest对象
            xmlHttp.open("get", "Get.aspx?username=" + username
                + "&age=" + age);

            //设置回调函数
            xmlHttp.onreadystatechange = function () {
                if (xmlHttp.readyState == 4 && xmlHttp.status == 200) {
                    document.getElementById("result").innerHTML = xmlHttp.responseText;
                }
            }

            //发送请求
            xmlHttp.send(null);
        }
</script>
    </div>
    </form>
</body>
</html>
