<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ZHY.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>syihy.com</title>
<%--    <link href="css/manage.css" rel="stylesheet" type="text/css" />
--%><link href="css/css.css" rel="stylesheet" type="text/css" />
    <script src="js/manage.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <br/>
    <table width="620" border="0" align="center" cellpadding="0" cellspacing="0">
        <tbody>
            <tr>
                <td width="620">
                    <img alt="" height="11" src="images/login_p_img02.gif" width="650"/>
                </td>
            </tr>
            <tr>
                <td align="center" background="images/login_p_img03.gif">
                    <br/>
                    <table width="570" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <table cellspacing="0" cellpadding="0" width="570" border="0">
                                    <tbody>
                                        <tr>
                                            <td width="245" height="80" align="center" valign="top">
                                                <img alt="" height="67" src="images/member_t04.jpg" width="245"/>
                                            </td>
                                            <td align="right" valign="top">
                                                <br/>
                                                &nbsp;
                                                <img alt="" height="9" src="images/point07.gif" width="13" border="0"/><a href="#" onclick="window.external.addFavorite('http://www.nh178.com','宁海购物网')">加入收藏</a>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;<asp:Label ID="lblGUID" runat="server" Style="display: none"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img alt="" src="images/a_te01.gif" width="570" height="3"/>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="background-image:images/a_te02.gif">
                                <table width="520" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="123" height="120">
                                            <img alt="" height="95" src="images/login_p_img05.gif" width="123" border="0"/>
                                        </td>
                                        <td align="center">
                                            <table cellspacing="0" cellpadding="0" border="0">
                                                <tr>
                                                    <td width="80"  align="right" valign="bottom">
                                                        用户名：</td>
                                                    <td align="left" valign="bottom">
                                                        <input class="nemo01" tabindex="1" maxlength="22" size="22" name="user" id="txtUsername"
                                                            runat="server" onkeypress="return focusNext('txtPass', event,1,this,null)"/>
                                                    </td>
                                                    <td width="80" rowspan="3" align="right" valign="middle">
                                                        <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="images/login_p_img11.gif"
                                                            OnClick="btnLogin_Click"></asp:ImageButton>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" valign="bottom">
                                                        密&nbsp;&nbsp;码：                                                        
                                                    </td>
                                                    <td align="left" valign="bottom">
                                                        <input name="user" type="password" class="nemo01" tabindex="1" size="22" maxlength="22"
                                                            id="txtPass" runat="server" onkeypress="return focusNext('CheckCode', event,2,this,'txtUsername')"/>
                                                    
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" valign="bottom">
                                                       验证码：
                                                    </td>
                                                    <td align="left" valign="bottom">
                                                        <input class="nemo01" id="CheckCode" tabindex="3" maxlength="22" size="11" name="user"
                                                                        runat="server"/>
                                                        <a id="A2" href="" onclick="ChangeCode();return false;">
                                                                        <asp:Image ID="ImageCheck" runat="server" ImageUrl="ValidateCode.aspx?GUID=GUID"
                                                                            ImageAlign="AbsMiddle" ToolTip="看不清，换一个" Width="40px" Height="25px"></asp:Image></a>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br/>
                                            <asp:Label ID="lblMsg" runat="server" BackColor="Transparent" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#d5d5d5">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="70" align="center">
                                            Copyright(C) 2010-2013 Zhou Hongyang All Rights Reserved.
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <img alt="" height="11" src="images/login_p_img04.gif" width="650"/>
                </td>
            </tr>
        </tbody>
    </table>
    <br>
    </form>
</body>
</html>
