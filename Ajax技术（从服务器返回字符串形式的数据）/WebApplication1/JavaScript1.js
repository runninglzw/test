//用js创建兼容浏览器的ajax异步对象
function createAjax() {
    var ajaxObject = false;
    try {
        ajaxObject = new ActiveXObject("Msxml2.XMLHTTP");
    } catch (e) {
        try {
            ajaxObject = new ActiveXObject("Microsoft.XMLHTTP");
        } catch (e) {
            ajaxObject = false;
        }
    }
    if (!ajaxObject && typeof (XMLHttpRequest) != 'undefinded') {
        ajaxObject = new XMLHttpRequest();
    }
    return ajaxObject;
}
//页面中ajax的使用
