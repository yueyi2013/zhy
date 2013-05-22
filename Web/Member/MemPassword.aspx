<%@ Page Title="" Language="C#" MasterPageFile="~/Index0.Master" AutoEventWireup="true"
    CodeBehind="MemPassword.aspx.cs" Inherits="ZHY.Web.Member.MemPassword" %>

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
                <asp:UpdatePanel ID="upPsw" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <fieldset>
                    <legend>修改密码</legend>
                    <table align="right" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="right">
                                原密码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtYPsw" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                新密码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtNPsw" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                确认密码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtSPsw" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                            </td>
                            <td align="left">
                                <asp:Button ID="btnSure" runat="server" Text="确认" onclick="btnSure_Click" />
                                &nbsp; &nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="取消" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
