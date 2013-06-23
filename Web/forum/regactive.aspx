<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="regactive.aspx.cs" Inherits="Web.forum.regactive" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" media="screen,projection" type="text/css" href="../css/site/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <div class="content_login">
<div class="top_bg"></div>
<ul class="login_top">
	<li><img src="../images/reg/register04.gif"/></li>
	<li><img src="../images/reg/register05.gif"/></li>
	<li><img src="../images/reg/register03.gif"/></li>
</ul>
<div class="login_cont03">
	<img src="../images/reg/pic_04.gif" alt=""/>
    <p class="cont">您的信息已经成功提交，激活链接已发送到您的邮箱 <em style="color:#f00; font-style:normal;">
        <asp:Label ID="lblEmail" runat="server" ></asp:Label></em>.
                    <br>登录注册邮箱，按照邮件内容提示，激活您的帐户即可完成注册。</p>
</div>
<div class="login_cont04">
	<img src="../images/reg/pic_06.gif" alt="">
	<ul>
		<li>确认邮件是否被您提供的邮箱系统自动拦截，或被误认为垃圾邮件放到垃圾箱了。</li>
		<li>如果您确认邮箱地址正确，可以请求<a id="aReact" href="../forum/regactive.aspx">再次发送激活码</a></li>
	</ul>
</div>
<div class="btm_bg"></div>
</div>
</asp:Content>
