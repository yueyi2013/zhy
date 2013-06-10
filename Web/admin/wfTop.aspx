<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfTop.aspx.cs" Inherits="ZHY.Web.admin.wfTop" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-left: 0px; margin-top: 0px;">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="table-layout:fixed;">
    <tr>
        <td height="9" style="line-height:9px; background-image:url(../images/admin/top/main_04.gif)">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="97" height="9" background="../images/admin/top/main_01.gif">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
    <td height="47" background="../images/admin/top/main_09.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="38" height="47" background="../images/admin/top/main_06.gif">&nbsp;</td>
        <td width="59"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="29" background="../images/admin/top/main_07.gif">&nbsp;</td>
          </tr>
          <tr>
            <td height="18" background="../images/admin/top/main_14.gif"><table width="100%" border="0" cellspacing="0" cellpadding="0" style="table-layout:fixed;">
              <tr>
                <td  style="width:1px;">&nbsp;</td>
                <td >
                    <asp:Label ID="lblAdmin" runat="server"></asp:Label></td>
              </tr>
            </table></td>
          </tr>
        </table></td>
        <td width="155" background="../images/admin/top/main_08.gif">&nbsp;</td>
        <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td height="23" valign="bottom"><img src="../images/admin/top/main_12.gif" width="367" height="23" border="0" usemap="#Map" /></td>
          </tr>
        </table></td>
        <td width="200" background="../images/admin/top/main_11.gif">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="11%" height="23">&nbsp;</td>
            <td width="89%" valign="bottom">
            <span id="webasp_time" class="word_14">
                <script language="javascript" charset="gbk2312" type="text/javascript">
                    setInterval("document.getElementById('webasp_time').innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt (new Date().getDay());", 1000);
                </script> 
             </span>
           </td>
          </tr>
        </table>
        </td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="5" style="line-height:5px; background-image:url(../images/admin/top/main_18.gif)"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="180" background="../images/admin/top/main_16.gif"  style="line-height:5px;">&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
    </table></td>
  </tr>
</table>

<map name="Map" id="Map">
    <area shape="rect" coords="3,1,49,22" href="wfMain.aspx" target="mainFrame"/>
    <area shape="rect" coords="52,2,95,21"  onclick="javaScript:history.go(-1);" href="#" />
    <area shape="rect" coords="102,2,144,21" onclick="javaScript:history.go(1);" href="#"/>
    <area shape="rect" coords="150,1,197,22" href="#" />
    <area shape="rect" coords="210,2,304,20" href="wfPassword.aspx" target="mainFrame"/>
    <area shape="rect" coords="314,1,361,23" onclick="javascript:top.window.opener=null;window.close();" href="../Logout.aspx" target='_parent'/>
</map>


<!--

        <table cellpadding="" cellspacing="" width="100%">
            <tr>
                <td>
                    <img src="../../images/admin/top/topBg.png" />
                </td>
                <td align="right">
                    <a id="zx" name="zx" onclick="javascript:top.window.opener=null;window.close();" href="" target='_parent'>
                        注销</a>
                </td>
            </tr>
        </table>
        -->
    </form>
</body>
</html>
