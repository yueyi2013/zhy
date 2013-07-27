<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Web.forum.register1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script language="javascript" type="text/javascript">

        function validateEmail(oSrc, args) {
            var RegEmali = /^([a-z0-9][a-z0-9_\-\.]*)@([a-z0-9][a-z0-9\.\-]{0,20})\.([a-z]{2,4})$/;
            if (!RegEmali.exec(args.Value)) {
                args.IsValid = false;
            }
        };

        function validateUIPsw(oSrc, args) {
            var RegPWord = /^([\w]){5,16}$/;
            if (!RegPWord.exec(args.Value)) {
                args.IsValid = false;
            }
        };

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
			<tbody>
            <tr>
			    <td width="150" class="right" valign="top"><dfn>*</dfn>E-mail：</td>
				<td>
                    <asp:UpdatePanel ID="upEmail" runat="server" UpdateMode="Conditional">
                        <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="txtEmail" EventName="TextChanged" />                             
                        </Triggers>
                        <ContentTemplate>
					    <div class="oneline">                            
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="inputbox" MaxLength="100" 
                                AutoPostBack="True" ontextchanged="txtEmail_TextChanged" CausesValidation="true" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入邮箱地址！" ControlToValidate="txtEmail" Display="Dynamic"></asp:RequiredFieldValidator>
					        <asp:CustomValidator ID="cvEmail" runat="server" ClientValidationFunction="validateEmail"
                            ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="请输入真实的Email地址！"></asp:CustomValidator>
                        </div>
					    <div class="twoline">
						    （有效的E-mail地址才能收到激活码，帐户在激活后才能享受网站服务。）
					    </div>
					    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upEmail">
                            <ProgressTemplate>
                                &nbsp;正在验证邮箱地址,请稍后......
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        </ContentTemplate>
                    </asp:UpdatePanel>		
				</td>
			</tr>	
            <tr>
            <td class="right" valign="top"><dfn>*</dfn>用户名：</td>
            <td>
                <div class="oneline">
                    <asp:TextBox ID="txtUserName" runat="server" class="inputbox" MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="请输入用户名,长度不能超过30且由字母和数字组成！"></asp:RequiredFieldValidator>
                </div>
            </td>
            </tr>		
			<tr>
				<td class="right" valign="top"><dfn>*</dfn>校验码：</td>
				<td>
					<div class="oneline">
						<input type="text" id="CheckCode" runat="server" class="inputbox" maxlength="10"/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="请输入验证码！" ControlToValidate="CheckCode" Display="Dynamic"></asp:RequiredFieldValidator>
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
		<tbody>
            <tr>
			    <td width="300" class="right" valign="top"></td>
			    <td>
                    <asp:LinkButton ID="lbReg" runat="server" CssClass="btn_logintwo" 
                            onclick="lbReg_Click" OnClientClick="javascript:DisableRegButton(this)"><span id="regMem">注 册</span></asp:LinkButton>
                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upLogin">
                            <ProgressTemplate>
                                &nbsp;正在验证信息,请稍后......
                            </ProgressTemplate>
                    </asp:UpdateProgress>
			    </td>
		    </tr>
            <tr>
                <td></td>
                <td> <asp:Label ID="lblMsg" runat="server" BackColor="Transparent" ForeColor="Red"></asp:Label></td>
            </tr>
	    </tbody>
    </table>
	</div>
</div>
    <asp:Label ID="lblGUID" runat="server" Style="display: none"></asp:Label>
    </ContentTemplate>
</asp:UpdatePanel>
<div class="btm_bg">
</div>
</div>
</asp:Content>
