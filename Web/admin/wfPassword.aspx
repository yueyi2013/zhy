<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main0.Master" AutoEventWireup="true"
    CodeBehind="wfPassword.aspx.cs" Inherits="ZHY.Web.admin.wfPassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style="width: 585px">
    <legend>密码管理</legend>
    <asp:UpdatePanel ID="upPsw" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            
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
                                <asp:Button ID="btnSure" runat="server" Text="确认" onclick="btnSure_Click" CssClass="buttonCss"/>
                                &nbsp; &nbsp;
                                <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="buttonCss"/>
                            </td>
                        </tr>
                    </table>
              
        </ContentTemplate>
    </asp:UpdatePanel>
    </fieldset>
</asp:Content>
