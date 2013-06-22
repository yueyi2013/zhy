<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Web.forum.register1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" media="screen,projection" type="text/css" href="../css/site/main.css" />
    <script language="javascript" type="text/javascript">
        function validateNumber(oSrc, args) {
            var RegPWord = /^([\w]){5,16}$/;
            if (!RegPWord.exec(args.Value)) {
                args.IsValid = false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
<br />
<br />
<br />
<div class="content_login">
<div class="top_bg"></div>
<ul class="login_top">
	<li><img alt="" src="../images/reg/register01.gif"/></li>
	<li><img alt="" src="../images/reg/register02.gif"/></li>
	<li><img alt="" src="../images/reg/register03.gif"/></li>
</ul>
<asp:UpdatePanel ID="upLogin" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="lbReg" EventName="Click" />
            </Triggers>
            <ContentTemplate>
<div class="login_cont01">
	<h5></h5>
	<div class="table">
        
		        <table border="0" width="100%">
			        <tbody><tr>
				        <td width="150" class="right" valign="top"><dfn>*</dfn>E-mail：</td>
				<td>
					<div class="oneline">
                        <asp:UpdatePanel ID="upVldEmail" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="lbReg" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="txtEmail" EventName="TextChanged" />
                            </Triggers>
                        <ContentTemplate>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="inputbox" MaxLength="100" 
                                ontextchanged="txtEmail_TextChanged" AutoPostBack="True"></asp:TextBox>
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upVldEmail">
                                <ProgressTemplate>
                                    &nbsp;正在验证,请稍后......
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:Label ID="lblEmailMsg" runat="server" BackColor="Transparent" ForeColor="Red"></asp:Label>
                        </ContentTemplate>
                        </asp:UpdatePanel>
					</div>
					<div class="twoline">
						（有效的E-mail地址才能收到激活码，帐户在激活后才能享受网站服务。）
					</div>
								
				</td>
			</tr>
			<tr>
				<td class="right" valign="top"><dfn>*</dfn>密码：</td>
				<td>
					<div class="oneline">
                        <asp:TextBox ID="txtNewPassword" runat="server" CssClass="inputbox" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入密码！" ControlToValidate="txtNewPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvNewPsw" runat="server" ClientValidationFunction="validateNumber"
                            ControlToValidate="txtNewPassWord" Display="Dynamic" ErrorMessage="密码只能由英文字母或数字组成并且不能少于1位大于16位！"></asp:CustomValidator>
                        <ul id="pwd-strong" style="display:none;"><li>弱</li><li>中</li><li>强</li></ul>
					</div><div class="clear"></div>
					<div class="twoline">
						（为了您帐户的安全，建议使用字符+数字等多种不同类型的组合，且长度大于5位。）
					</div>
								
				</td>
			</tr>
			<tr>
				<td class="right" valign="top"><dfn>*</dfn>再次输入密码：</td>
				<td>
					<div class="oneline">
                        <asp:TextBox ID="txtTwoPassword" runat="server" CssClass="inputbox" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入确认密码！" ControlToValidate="txtTwoPassword" Display="Dynamic"></asp:RequiredFieldValidator>
					    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassWord"
                            ControlToValidate="txtTwoPassword" Display="Dynamic" ErrorMessage="两次密码输入不一致，请重新输入！"></asp:CompareValidator>
                    </div>
					<div class="twoline">
                        （确保您记住密码。）
					</div>
								
				</td>
			</tr>
			<tr>
				<td class="right" valign="top"><dfn>*</dfn>校验码：</td>
				<td>
					<div class="oneline">
						<input type="text" id="cd" class="inputbox" maxlength="10">
					</div><div style="clear:both;"></div>
					<div style="color:Red;font-size:12px;">
						（如果您连续输入不对验证码，请检查您的浏览器是否禁用了Cookie。<a href="/help/faq" target="_blank">如何启用Cookie？</a>）
					</div>
				</td>
			</tr>
			<tr id="tr_vc" style="">
				<td class="right" valign="top"></td>
				<td>
                    <asp:Image ID="ImageCheck" runat="server" ImageUrl="~/ValidateCode.aspx?GUID=GUID"  ImageAlign="AbsMiddle" ToolTip="看不清，换一个" Width="150px" Height="45px"></asp:Image>
                    <asp:LinkButton ID="lbSwitchPic" runat="server" Text="看不清，换一张"/>
                </td>
			</tr>
			<tr>
				<td class="right" valign="middle"><dfn>*</dfn>注册条款：</td>
				<td>
					<div class="oneline">
                    <p class="error_two">
						<input type="checkbox" id="chkTerms" name="chkTerms" value="1"/>
                        <label for="chkTerms">我已仔细阅读并接受 <a href="/help/terms" class="font_gray14" target="_blank">SYIHY注册条款</a>。</label>
                        </p>
					</div>
				</td>
			</tr>	
		</tbody></table>
        
	</div>
</div>
<div class="login_cont10">
	<div class="table">
	<table border="0">
		<tbody><tr>
			<td width="300" class="right" valign="top"></td>
			<td>
                <asp:LinkButton ID="lbReg" runat="server" CssClass="btn_logintwo" 
                    onclick="lbReg_Click"><span>注 册</span></asp:LinkButton>
			</td>
		</tr>
	</tbody></table>
	</div>
</div>
</ContentTemplate>
        </asp:UpdatePanel>
<div class="btm_bg"></div>
</div>
</asp:Content>
