<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true"
    CodeBehind="wfSitePromise.aspx.cs" Inherits="ZHY.Web.admin.wfSitePromise" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Button ID="btnSave" runat="server" Text="保存" CssClass="buttonCss" 
        OnClick="btnSave_Click" Height="27px" Width="117px" />
    <FTB:FreeTextBox ID="ftSitePromise" runat="server" Height="400" Width="800">
    </FTB:FreeTextBox>
    
</asp:Content>
