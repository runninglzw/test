alert("开始解析！");
loadXML = function (xmlFile) {
    alert("loadxml已启动！");
    var xmlDoc = null;
    //判断浏览器的类型
    //支持IE浏览器
    if (!window.DOMParser && window.ActiveXObject) {
        var xmlDomVersions = ['MSXML.2.DOMDocument.6.0', 'MSXML.2.DOMDocument.3.0', 'Microsoft.XMLDOM'];
        for (var i = 0; i < xmlDomVersions.length; i++) {
            try {
                xmlDoc = new ActiveXObject(xmlDomVersions[i]);
                break;
            } catch (e) {
            }
        }
    }
        //支持Mozilla浏览器
    else if (document.implementation && document.implementation.createDocument) {
        try {
            /* document.implementation.createDocument('','',null); 方法的三个参数说明
             * 第一个参数是包含文档所使用的命名空间URI的字符串； 
             * 第二个参数是包含文档根元素名称的字符串； 
             * 第三个参数是要创建的文档类型（也称为doctype）
             */
            xmlDoc = document.implementation.createDocument('', '', null);
        } catch (e) {
        }
    }
    else {
        return null;
    }

    if (xmlDoc != null) {
        xmlDoc.async = false;
        xmlDoc.load(xmlFile);
    }
    return xmlDoc;
}
    function ajax() {
        alert("方法调用成功！")
        var xmldoc = loadXML(text.xml)
        alert("获得xml文件");
        var elements = xmlDoc.getElementsByTagName("Company");
        alert(elements);
        for (var i = 0; i < elements.length; i++) {
            var name = elements[i].getElementsByTagName("cNname")[0].firstChild.nodeValue;
            var ip = elements[i].getElementsByTagName("cIP")[0].firstChild.nodeValue;

        }
    }