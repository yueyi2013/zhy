<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfTop.aspx.cs" Inherits="ZHY.Web.admin.wfTop" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-left: 0px; margin-top: 0px; background-image: url('../images/bg_top.bmp');
    background-repeat: repeat-x">
    <form id="form1" runat="server">
    <div>
        <table cellpadding="" cellspacing="" width="100%">
            <tr>
                <td>
                    <img src="../images/topBg.png" />
                </td>
                <td align="right">
                    <a id="zx" name="zx" onclick="javascript:top.window.opener=null;window.close();" href="../Logout.aspx" target='_parent'>
                        注销</a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
