<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="memberlogin.aspx.cs" Inherits="Web.forum.register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" media="screen,projection" type="text/css" href="../css/site/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 50%">
                <asp:UpdatePanel ID="upLogin" runat="server" UpdateMode="Conditional">
                    <Triggers>
                             <asp:AsyncPostBackTrigger ControlID="imgbtnLogin" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
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
                        <td><asp:Label ID="lblGUID" runat="server" Style="display: none"></asp:Label>
                            <asp:TextBox ID="txtUserPsw" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            验证码：
                        </td>
                        <td>
                            <asp:TextBox ID="CheckCode" runat="server"></asp:TextBox>
                            &nbsp; <a id="A2" href="" onclick="ChangeCode();return false;">
                                <asp:Image ID="ImageCheck" runat="server" ImageUrl="../ValidateCode.aspx?GUID=GUID"
                                    ImageAlign="AbsMiddle" ToolTip="看不清，换一个" Width="40px" Height="25px"></asp:Image></a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:ImageButton ID="imgbtnLogin" runat="server" 
                                ImageUrl="~/images/Member/login_button.gif" onclick="imgbtnLogin_Click" />
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upLogin">
                     <ProgressTemplate>
                            &nbsp;正在登录,请稍后......
                     </ProgressTemplate>
                </asp:UpdateProgress>
                <br />
                    <asp:Label ID="lblMsg" runat="server" BackColor="Transparent" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    </table>
                    </ContentTemplate>  
                </asp:UpdatePanel>              
            </td>
            <td align="center"  style=" border-left: 1px solid Gray; width:100%; border-left-color:#ccc" >
            
                还不是本站会员？<a href="register.aspx">立即注册</a><br />
                -----------------------------------------------------------<br />
                <a href="register.aspx"><img alt="" src="../images/Member/button_reg.gif" /></a>
                
            </td>
        </tr>
    </table>
</asp:Content>
