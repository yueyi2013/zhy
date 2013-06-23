<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="regsuccess.aspx.cs" Inherits="Web.forum.regsuccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" media="screen,projection" type="text/css" href="../css/site/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">

    <div class="content_login">
<div class="top_bg"></div>
<ul class="login_top">
	<li><img src="../images/reg/register04.gif"/></li>
	<li><img src="../images/reg/register03.gif"/></li>
	<li><img src="../images/reg/register06.gif"/></li>
</ul>
<div class="login_cont03">
	<img src="../images/reg/pic_07.gif" alt=""><p class="cont"><span> 
        <asp:Label ID="lblUser" runat="server"></asp:Label>您好，恭喜您已经成功完成了激活，</span>请尽情享受SYIHY提供的各种服务！<span id="sp_go"><br>系统将在<b id="b_sec">2</b>秒后自动跳转到 <a href="http://www.syihy.com/">http://www.syihy.com</a></span></p>
</div>
<div class="login_cont05">
<dl>
	<dt>SYIHY产品导航</dt>
	<a href="http://www.syihy.com" target="_blank"><dd class="bg01">SYIHY.COM</dd></a>
</dl>
</div>
<div class="btm_bg"></div>
</div>
</asp:Content>
