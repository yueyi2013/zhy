<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="password.aspx.cs" Inherits="Web.forum.password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyTop" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpBody" runat="server">
    <table cellpadding="0" cellspacing="0">
            <tr>
				<td class="right" valign="top"><dfn>*</dfn>原密码：</td>
				<td>
					<div class="oneline">
                        <asp:TextBox ID="txtOldPsw" runat="server" CssClass="inputbox" MaxLength="50" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入原密码！" ControlToValidate="txtOldPsw" Display="Dynamic"></asp:RequiredFieldValidator>
					</div><div class="clear"></div>						
				</td>
			</tr>
            <tr>
				<td class="right" valign="top"><dfn>*</dfn>新密码：</td>
				<td>
					<div class="oneline">
                        <asp:TextBox ID="txtNewPassword" runat="server" CssClass="inputbox" MaxLength="50" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入新密码！" ControlToValidate="txtNewPassword" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvNewPsw" runat="server" ClientValidationFunction="validateUIPsw"
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
                        <asp:TextBox ID="txtTwoPassword" runat="server" CssClass="inputbox" MaxLength="50" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入确认密码！" ControlToValidate="txtTwoPassword" Display="Dynamic"></asp:RequiredFieldValidator>
					    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassWord"
                            ControlToValidate="txtTwoPassword" Display="Dynamic" ErrorMessage="两次密码输入不一致，请重新输入！"></asp:CompareValidator>
                    </div>
					<div class="twoline">
                        （确保您记住密码。）
					</div>
								
				</td>
			</tr>
    
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
