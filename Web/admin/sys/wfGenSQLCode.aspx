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
                数据库名：<asp:TextBox ID="txtDBName" runat="server"></asp:TextBox>
                <div id="divSQLCode" runat="server" style="font-weight:bold">
                    
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</fieldset>
</asp:Content>
