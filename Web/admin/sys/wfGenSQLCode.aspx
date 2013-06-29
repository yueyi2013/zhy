<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main0.Master" AutoEventWireup="true" CodeBehind="wfGenSQLCode.aspx.cs" Inherits="Web.admin.sys.wfGenSQLCode" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<fieldset style="width: 800px">
    <legend>公共数据脚本</legend>
        <asp:Button ID="btnGen" runat="server" Text="开始生成" CausesValidation="false" 
        CssClass="buttonCss" onclick="btnGen_Click" />
        <asp:Button ID="btnCreateDB" runat="server" Text="创建表结构" CausesValidation="false" 
        CssClass="buttonCss" onclick="btnCreateDB_Click" />

        <hr style="width:100%"/>
        <asp:UpdatePanel ID="MyUpdatePanelBody" runat="server" UpdateMode="Conditional">
            <Triggers>
               <asp:AsyncPostBackTrigger ControlID="btnGen" EventName="Click" />    
            </Triggers>
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="right" valign="top" style=" width:60px">
                            数据库名：
                        </td>
                        <td>
                            <asp:TextBox ID="txtDBName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            SQL语句：
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtSQLCode" runat="server" Width="100%" TextMode="MultiLine" Height="150"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">语句类型:</td>
                        <td>
                            <asp:RadioButtonList ID="rbSQLCodeType" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="0" Text="文本" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="0" Text="SQL文件"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">执行结果：</td>
                        <td><div id="divSQLCode" runat="server" style="font-weight:bold; width:98%"/></td>
                    </tr>
                </table>              
                
            </ContentTemplate>
        </asp:UpdatePanel>
</fieldset>
</asp:Content>
