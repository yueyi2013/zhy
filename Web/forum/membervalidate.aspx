<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="membervalidate.aspx.cs" Inherits="Web.forum.membervalidate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">

<div class="content_login">
<div class="top_bg"></div>
<div id="put_div" class="login_cont02">
<p><span class="remark" id="spNote" style="">激活码已过期，请重新获取。</span></p>
<div class="table">
	<table border="0" align="center">
						
		<tbody><tr class="padding">
			<td class="right" valign="top">E-mail：</td>
			<td class="left">
				<div class="oneline">
					<input type="text" id="u" class="inputbox" maxlength="100"/>
                </div>
			</td>
		</tr>
        <tr>
			<td class="right" valign="top"></td>
			<td class="left">
				<div class="oneline"><br>
                    <a id="aAct" class="btn_logintwo" href="javascript:void(0);"><span>获取激活码</span></a>
				</div>
			</td>
		</tr>
	</tbody></table>
</div>
</div>
<div id="suc_div" style="display:none;">
    <div class="login_cont06">
	    您的申请已提交成功，请进入您注册的邮箱进行激活。
    </div>
    <div class="login_cont07">
	    <a class="btn_logintwo" href="javascript:void(0);" onclick="javascript:return csdn.closeWin(this);"><span>关闭此页</span></a>
    </div>
</div>
<div class="login_cont04">
	<img src="/images/pic_06.gif" alt="">
	<ul>
		<li>激活码从获得起12小时内有效；</li>
		<li>用户修改邮箱，需要重新激活，激活码将发送到新注册邮箱。</li>
		<li>如果还有其他问题，请查看<a href="/help/faq">帮助文档</a>。</li>
	</ul>
</div>
<div class="btm_bg"></div>
</div>
</asp:Content>
