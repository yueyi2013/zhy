<%@ Page Title="" Language="C#" MasterPageFile="~/Index0.Master" AutoEventWireup="true"
    CodeBehind="MemLogin.aspx.cs" Inherits="Web.Member.MemLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphCarInfo" runat="server">
    <table width="100%">
        <tr>
            <td style="width: 50%">
                <table width="100%" cellpadding="5" cellspacing="5">
                    <tr>
                        <td align="right">
                            <img alt="" src="../images/Member/login_title.gif" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lblUserName" runat="server" Text="用户名："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            密码：
                        </td>
                        <td>
                            <asp:TextBox ID="txtUserPsw" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            验证码：
                        </td>
                        <td>
                            <asp:TextBox ID="txtValidate" runat="server"></asp:TextBox>
                            &nbsp; <a id="A2" href="" onclick="ChangeCode();return false;">
                                <asp:Image ID="ImageCheck" runat="server" ImageUrl="../ValidateCode.aspx?GUID=GUID"
                                    ImageAlign="AbsMiddle" ToolTip="看不清，换一个" Width="40px" Height="25px"></asp:Image></a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:ImageButton ID="imgbtnLogin" runat="server" ImageUrl="~/images/Member/login_button.gif" />
                        </td>
                    </tr>
                </table>
            </td>
            <td align="center"  style=" border-left: 1px solid Gray; width:100%; border-left-color:#ccc" >
            
                还不是本站会员？<a href="register.html">立即注册</a><br />
                -----------------------------------------------------------<br />
                <img alt="" src="../images/Member/button_reg.gif" />
                
            </td>
        </tr>
    </table>
</asp:Content>
