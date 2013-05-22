<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true"
    CodeBehind="wfUpSmallPic.aspx.cs" Inherits="ZHY.Web.admin.wfUpSmallPic" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FileUpload ID="fuCarPic" runat="server" Width="300px" />
    <asp:Button ID="btnUpload" runat="server" Text="开始上传" 
        onclick="btnUpload_Click" />
</asp:Content>
