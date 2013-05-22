<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true"
    CodeBehind="wfInputFL.aspx.cs" Inherits="Web.admin.wfInputFL" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="0" border="0">
        <tr>
            <td height="25" width="30%" align="right">
                链接名称 ：
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtFLName" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" width="30%" align="right">
                网址 ：
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtFLSite" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" width="30%" align="right">
                图标 ：
            </td>
            <td height="25" width="*" align="left">
                <asp:FileUpload ID="fuPic" runat="server" />
            </td>
        </tr>
        <tr>
            <td height="25" width="30%" align="right">
                排序 ：
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtFLOrder" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td height="25" width="30%" align="right">
                显示方式 ：
            </td>
            <td height="25" width="*" align="left">
                <asp:RadioButtonList ID="rblViewMethod" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="文字" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="图标" Value="2"></asp:ListItem>
                    <asp:ListItem Text="全显示" Value="3"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td height="25" width="30%" align="right">
                描述 ：
            </td>
            <td height="25" width="*" align="left">
                <asp:TextBox ID="txtFLDes" runat="server" Width="200px" TextMode="MultiLine" Height="50px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnSave" runat="server" Text="保存" Width="65px" OnClick="btnSave_Click"
                    CssClass="buttonCss" />
            </td>
        </tr>
    </table>
</asp:Content>
