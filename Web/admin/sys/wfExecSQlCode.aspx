<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main0.Master" AutoEventWireup="true" CodeBehind="wfExecSQlCode.aspx.cs" Inherits="Web.admin.sys.wfExecSQlCode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<fieldset style="width: 800px">
    <legend>执行SQL脚本</legend>
    <asp:Button ID="btnExecute" runat="server" Text="开始执行" CausesValidation="false" 
        CssClass="buttonCss" onclick="btnExecute_Click" />
    <hr style="width:100%"/>
    <asp:UpdatePanel ID="MyUpdatePanelBody" runat="server" UpdateMode="Conditional">
        <Triggers>
               <asp:AsyncPostBackTrigger ControlID="btnExecute" EventName="Click" />    
        </Triggers>
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="right" valign="top" style=" width:60px">
                        SQL语句：
                    </td>
                    <td align="left" valign="top">
                        <asp:TextBox ID="txtSQLCode" runat="server" Width="100%" TextMode="MultiLine" Height="100"></asp:TextBox>
                    </td>
                    </tr>
                <tr>
                <td align="right" valign="top"
                    SQL类型</td>                
                <td>
                    <asp:RadioButtonList ID="rbSQLType" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Text="查询" Value="0"></asp:ListItem>
                        <asp:ListItem Text="其他" Value="1"></asp:ListItem>
                    </asp:RadioButtonList>
                </td></tr>
                <tr>
                <td align="right" valign="top">
                    返回结果：
                </td>                
                <td>
                    <asp:GridView ID="gvResult" runat="server" Width="98%">
                    </asp:GridView>
                    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                </td></tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</fieldset>
</asp:Content>
