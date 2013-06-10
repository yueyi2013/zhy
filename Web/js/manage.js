//全选CheckBox按钮
function GetAllCheckBox(parentItem) {
    var items = document.getElementsByTagName("input");

    for (i = 0; i < items.length; i++) {

        if (parentItem.checked) {
            if (items[i].type == "checkbox") {
                items[i].checked = true;
                items[i].parentElement.parentElement.style.background = "#6699ff";
                parentItem.parentElement.parentElement.style.background = "#ffffff";
                document.getElementById("ctl00$ContentPlaceHolder1$btnModify").disabled = "disabled";
            }
        }
        else {
            if (items[i].type == "checkbox") {
                items[i].checked = false;
                items[i].parentElement.parentElement.style.background = "";
            }
        }
    }
}

function validateFileupload(picFile) {
    var name = picFile.id;
    var num = 0;
    num = name.substr(name.length - 2, 1);

    if (!isNaN(num)) {
        alert("FileUpload" + (num - 1));
        if(num%2==0)
            document.getElementById("FileUpload" + (num-1));
        else
            document.getElementById("FileUpload" + (num+1));
    }
}

function GetAllCheckBox0(parentItem) {
    var items = document.getElementsByTagName("input");

    for (i = 0; i < items.length; i++) {

        if (parentItem.checked) {
            if (items[i].type == "checkbox") {
                items[i].checked = true;
                items[i].parentElement.parentElement.style.background = "#6699ff";
                parentItem.parentElement.parentElement.style.background = "#ffffff";
            }
        }
        else {
            if (items[i].type == "checkbox") {
                items[i].checked = false;
                items[i].parentElement.parentElement.style.background = "";
            }
        }
    }
}

function changecolor0(parameter) {
    if (parameter.checked) {
        parameter.parentElement.parentElement.style.background = "#ff9900";
    }
    else {
        parameter.parentElement.parentElement.style.background = "";
    }
}


var m = 0;
function changecolor(parameter) {
    if (parameter.checked) {
        parameter.parentElement.parentElement.style.background = "#ff9900";
        m = m + 1;
    }
    else {
        parameter.parentElement.parentElement.style.background = "";
        m = m - 1;
    }

    if (m == 1) {

        document.getElementById("ctl00$ContentPlaceHolder1$btnModify").disabled = "";
    } else {
        document.getElementById("ctl00$ContentPlaceHolder1$btnModify").disabled = "disabled";
    }

}

function ClearZero() {
    m = 0;
    document.getElementById("ctl00$ContentPlaceHolder1$btnModify").disabled = "disabled";
}

function Confirm() {
    if (confirm('您确定要删除选中的记录吗？')) {
        ClearZero();
        return true;
    } else
        return false;
}

// 展开/关闭
function extend() {
    var tHeight = parseInt(gs($("box"), "height"));
    if (!isOpen) {
        $("box").style.display = "block";
        if (tHeight < HeightEnd) {
            $("box").style.height = (tHeight + aNum) + "px";
            $("box").filters.alpha.opacity += 3;
            setTimeout("extend()", timer);
        } else {
            isOpen = true; //打开状态
            $("tabTop").innerHTML = "关闭";
            $("box").filters.alpha.opacity = 100;
        }
    } else {
        if ((tHeight - aNum) > 0) {
            $("box").style.height = (tHeight - aNum) + "px";
            $("box").filters.alpha.opacity -= 5;
            setTimeout("extend()", timer);
        } else {
            isOpen = false; //关闭状态
            $("box").style.display = "none";
            $("tabTop").innerHTML = "展开";
            $("box").filters.alpha.opacity = 2;
        }
    }
}

var timer = 10;   //计时器时钟
var HeightEnd = 400; //Div高度
var aNum = 20;   //步进速度
var isOpen = false; //层状态 打开还是关闭 默认关闭
function $(name) { return document.getElementById(name); }
function voids() {
    setTimeout("extend()", 66);
}


function gs(d, a) {
    if (d.currentStyle) {
        var curVal = d.currentStyle[a]
    } else {
        var curVal = document.defaultView.getComputedStyle(d, null)[a]
    }
    return curVal;
}

//验证数字
function validateNumber(oSrc, args) {

    var RegPWord = /^\d+(\.\d+)?$/;
    if (!RegPWord.exec(args.Value)) {
        args.IsValid = false;
    }
}

//验证选择
function validateInput(oSrc, args) {
    if (args.Value == "1") {
        document.getElementById("ctl00_ContentPlaceHolder1_txtProPublish").disabled = "disabled";
    } else {
    document.getElementById("ctl00_ContentPlaceHolder1_txtProPublish").disabled = "";
    }
}

/*
* 类    名：fDisplayFalsh
* 功    能：显示首页Falsh
* 作    者：周红洋
* 输入参数：无
* 输出参数：显示首页
* 创建时间：2010-7-1
* 修改人员：
* 修改时间： 
* 描    述：
*/
var pics = "";
var links = "";
var texts = "";

function fDisplayFalsh() {

    var focus_width = 400
    var focus_height = 200
    var text_height = 0
    var swf_height = focus_height + text_height
    if (pics != "") {
        document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="' + focus_width + '" height="' + swf_height + '">');
        document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="images/site/focus.swf"><param name="quality" value="high"><param name="bgcolor" value="#F0F0F0">');
        document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
        document.write('<param name="FlashVars" value="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '">');
        document.write('<embed src="images/site/pixviewer.swf" wmode="opaque" FlashVars="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '" menu="false" bgcolor="#F0F0F0" quality="high" width="' + focus_width + '" height="' + focus_height + '" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />'); document.write('</object>');
    }
    else {
        document.write('<img widht="' + focus_width + '" height="' + swf_height + '" src="images/upfiles/gonggao/20100709035221.JPG" border="0" >');
    }

}

function fDisplayFalsh0() {

    var focus_width = 600
    var focus_height = 300
    var text_height = 0
    var swf_height = focus_height + text_height
    if (pics != "") {
        document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="' + focus_width + '" height="' + swf_height + '">');
        document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="../images/site/focus.swf"><param name="quality" value="high"><param name="bgcolor" value="#F0F0F0">');
        document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
        document.write('<param name="FlashVars" value="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '">');
        document.write('<embed src="../images/site/pixviewer.swf" wmode="opaque" FlashVars="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '" menu="false" bgcolor="#F0F0F0" quality="high" width="' + focus_width + '" height="' + focus_height + '" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />'); document.write('</object>');
    }
    else {
        document.write('<img widht="' + focus_width + '" height="' + swf_height + '" src="../images/upfiles/gonggao/20100709035221.JPG" border="0" >');
    }

}



function GetURLParam(n, s) {//获取URL传递参数
    if (!s) var s = location.search;
    var r = new RegExp("^\\?(?:" + n + "=|.+=.*&" + n + "=)([^&]+).*", "i");
    if (r.test(s)) {
        return unescape(s.replace(r, "$1"));
    } else {
        return null;
    }
}
function ReadCookie(n) {//读取cookie
    var id = GetURLParam("conId"); //首页获取url ID
    //    alert("读取cookie  id=" + id);
    var c = document.cookie.match(new RegExp("(^| )" + n + "=([^;]*)(;|$)"));
    //    alert("读取cookie  c=" + c);
    if (c == null) {
        WriteCookie('ConID', id);
        //一部更新数据库Click字段
        UpdateClick(id);

    } else {
        GetClick(id);
    }
}
function WriteCookie(n, v, s) {//存储cookie
    if (!s) var s = 86400000;  //cookie有效期设为一天
    var d = new Date();
    d.setTime(d.getTime() + s);
    //    alert("存储cookie  d=" +  d.toLocaleString());
    document.cookie = n + "=" + escape(v) + ";expires=" + d.toLocaleString();
}

//function ReadCookiePL(n,btnPL) {//读取cookie
//    var id = GetURLParam("conId"); //首页获取url ID
//    //    alert("读取cookie  id=" + id);
//    var c = document.cookie.match(new RegExp("(^| )" + n + "=([^;]*)(;|$)"));
//    if (btnP.value == "顶一下")
//    {
//    
//    }else {
//    
//    }
//    
//    //    alert("读取cookie  c=" + c);
//    if (c == null) {
//        WriteCookie('ConIDPL', id);
//        //一部更新数据库Click字段
//        UpdateTop(id);

//    } else {
//        GetClick(id);
//    }
//}
//function WriteCookiePL(n, v, s) {//存储cookie
//    if (!s) var s = 86400000;  //cookie有效期设为一天
//    var d = new Date();
//    d.setTime(d.getTime() + s);
//    //    alert("存储cookie  d=" +  d.toLocaleString());
//    document.cookie = n + "=" + escape(v) + ";expires=" + d.toLocaleString();
//}

function ChangeCode() {
    var date = new Date();
    var myImg = document.getElementById("ImageCheck");
    var GUID = document.getElementById("lblGUID");

    if (GUID != null) {
        if (GUID.innerHTML != "" && GUID.innerHTML != null) {
            myImg.src = "ValidateCode.aspx?GUID=" + GUID.innerHTML + "&flag=" + date.getMilliseconds()
        }
    }
    return false;
}

function validate() {
    var username = $("txtUsername");
    var password = $("txtPass");
    var checkcode = $("CheckCode");
    if (isEmptyStr(username.value)) {
        alert("请输入用户名！");
        username.focus();
        return false;
    }
    if (isEmptyStr(password.value)) {
        alert("请输入密码！");
        password.focus();
        return false;
    }

    if (isEmptyStr(checkcode.value)) {
        alert("请输入验证码！");
        checkcode.focus();
        return false;
    }
    return true;
}



function focusNext(nextName, evt, num, t, lastName) {
    evt = (evt) ? evt : event;
    var charCode = (evt.charCode) ? evt.charCode :
((evt.which) ? evt.which : evt.keyCode);
    if (charCode == 13 || charCode == 3) {
        var nextobj = document.getElementById(nextName);
        var lastobj = document.getElementById(lastName);

        if (num == 1 && isEmptyStr(t.value)) {
            alert("请输入用户名！");
            t.focus();
            return false;
        }


        if (num == 2 && isEmptyStr(t.value)) {
            alert("请输入密码！");
            t.focus();
            return false;
        }

        if (lastobj != null && isEmptyStr(lastobj.value)) {
            alert("请输入用户名！");
            lastobj.focus();
            return false;
        }

        nextobj.focus();
        return false;
    }
    return true;
}