<%@ Page Title="" Language="C#" MasterPageFile="~/Index0.Master" AutoEventWireup="true"
    CodeBehind="MemberPson.aspx.cs" Inherits="Web.Member.MemberPson" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphCarInfo" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px" align="left" valign="top">
                &nbsp;
                <asp:Menu ID="MenuLeft" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2"
                    Font-Names="Verdana" Font-Size="Larger" ForeColor="#990000" Height="107px" StaticSubMenuIndent="10px"
                    Width="146px" Font-Bold="True">
                    <StaticSelectedStyle BackColor="#FFCC66" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                    <DynamicMenuStyle BackColor="#FFFBD6" />
                    <DynamicSelectedStyle BackColor="#FFCC66" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                    <Items>
                        <asp:MenuItem Text="发布信息" Value="发布信息"></asp:MenuItem>
                        <asp:MenuItem Text="信息查询" Value="信息查询"></asp:MenuItem>
                        <asp:MenuItem Text="修改密码" Value="修改密码"></asp:MenuItem>
                        <asp:MenuItem Text="个人信息" Value="个人信息"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </td>
            <td align="left" valign="top">
                <fieldset>
                    <legend>个人信息</legend>
                    <table align="left" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="right">
                                会员帐号：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemAccount" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                密码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemPsw" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                重复密码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemPsw1" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                中介名称：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemMedium" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                单位电话：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemUnitTel" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                工作虚拟号：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemShotNum" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                手机：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemMobile" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                真实姓名：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemRealName" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:Button ID="btnSave" runat="server" Text="保存" onclick="btnSave_Click" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="取消" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
