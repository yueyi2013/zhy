<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true"
    CodeBehind="wfIndexPic.aspx.cs" Inherits="ZHY.Web.admin.wfIndexPic" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="首页图片上传"></asp:Label>
    <asp:FileUpload ID="fuImage" runat="server" />
    <asp:Button ID="btnSave" runat="server" Text="上传" Width="65px" OnClick="btnSave_Click"
        CssClass="buttonCss" />
</asp:Content>
