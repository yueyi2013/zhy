//1.我们首先创建一个全局变量
//2.我们在创建一个XmlHttpRequest对象
var xmlHttp;

function createXmlHttpRequest() {
    if (window.XMLHttpRequest) {
        xmlHttp = new XMLHttpRequest();

        if (xmlHttp.overrideMimeType) {
            xmlHttp.overrideMimeType("text/xml");
        }
    }
    else if (window.ActiveXObject) {
        try {
            xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch (e) {
            xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
    }
    if (!xmlHttp) {
        window.alert("你的浏览器不支持创建XMLhttpRequest对象");
    }
    return xmlHttp;
}

function AddConComment(conId) {
    if (xmlHttp == null) {
        createXmlHttpRequest();
    }
    var userId = document.getElementById("txtUserName").value;
    var userPsw = document.getElementById("txtPsw").value;
    var comment = document.getElementById("txtPLContent").value;
    var isHide = document.getElementById("chkNiMing").checked;
    var conId = GetURLParam("ConID"); //首页获取url ID
    var url = "/../LanMu/wfWebInfo.aspx?conId=" + conId + "&param=comment&userId=" + userId + "&userPsw=" + userPsw + "&isHide=" + isHide + "&comment=" + comment;
    
    
    xmlHttp.open("GET", url, true);

    xmlHttp.onreadystatechange = CommentResult;

    xmlHttp.send(null);
}


function CommentResult() {
    if (xmlHttp.readyState == 4) {

        if (xmlHttp.status == 200) {
            if (xmlHttp.responseText == "YES") {
                window.alert("评论成功！");
                document.getElementById("txtPLContent").value = "";
            }
            else {
                window.alert("评论失败！请先登录");
                window.location.reload();
            }
        }
    }
}

function UpdateTop() {
    if (xmlHttp == null) {
        createXmlHttpRequest();
    }
    var conId = GetURLParam("conId"); //首页获取url ID
    var url = "/../LanMu/wfWebInfo.aspx?conId=" + conId + "&param=top";

    xmlHttp.open("GET", url, true);

    xmlHttp.onreadystatechange = Update;

    xmlHttp.send(null);
}


function UpdateLow() {
    if (xmlHttp == null) {
        createXmlHttpRequest();
    }
    var conId = GetURLParam("conId"); //首页获取url ID

    var url = "/../LanMu/wfWebInfo.aspx?conId=" + conId + "&param=low";

    xmlHttp.open("GET", url, true);

    xmlHttp.onreadystatechange = Update;

    xmlHttp.send(null);
}

function UpdateClick(conId) {
    if (xmlHttp == null) {
        createXmlHttpRequest();
    }

    var url = "/../LanMu/wfWebInfo.aspx?conId=" + conId+"&param=update";

    xmlHttp.open("GET", url, true);

    xmlHttp.onreadystatechange = UpdateResult;

    xmlHttp.send(null);
}

function GetClick(conId) {
    if (xmlHttp == null) {
        createXmlHttpRequest();
    }

    var url = "/../LanMu/wfWebInfo.aspx?conId=" + conId + "&param=get";

    xmlHttp.open("GET", url, true);

    xmlHttp.onreadystatechange = GetResult;

    xmlHttp.send(null);
}



function UpdateResult() {
    if (xmlHttp.readyState == 4) {

        if (xmlHttp.status == 200) {
            if (xmlHttp.responseText == "YES") {
                var spanValue;
                var spanTest = document.getElementById('ConClick');
                if (spanTest != null) {

                    spanValue = spanTest.outerText;
                    spanTest.outerText = (Number(spanValue) + 1);

                }
                else {
                    spanValue = spanTest.textContent;
                    spanTest.textContent = (Number(spanValue) + 1);
                }
            }
            else {
                window.alert("更新失败");
                window.location.reload();
            }
        }
    }
}

function Update() {
    if (xmlHttp.readyState == 4) {

        if (xmlHttp.status == 200) {
            if (xmlHttp.responseText == "YES") {
                var spanValue;
                var spanTest = document.getElementById('ConClick');
                if (spanTest != null) {

                    spanValue = spanTest.outerText;
                    spanTest.outerText = (Number(spanValue) + 1);

                }
                else {
                    spanValue = spanTest.textContent;
                    spanTest.textContent = (Number(spanValue) + 1);
                }
            }
            else {
                window.alert("更新失败");
                window.location.reload();
            }
        }
    }
}

function GetResult() {
    if (xmlHttp.readyState == 4) {

        if (xmlHttp.status == 200) {
            if (xmlHttp.responseText != "") {
                var spanValue;
                var spanTest = document.getElementById('ConClick');
                if (spanTest != null) {

                    spanValue = spanTest.outerText;
                    spanTest.outerText = xmlHttp.responseText;

                }
                else {
                    spanValue = spanTest.textContent;
                    spanTest.textContent = xmlHttp.responseText;
                }
            } 
        }
    }
}

