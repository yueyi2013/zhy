<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="newsdetails.aspx.cs" Inherits="Web.forum.newsdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link rel="stylesheet" media="screen,projection" type="text/css" href="../css/site/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
<table>
<tr><td>
    <asp:Label ID="lblTitle" runat="server" Text="标题" Font-Bold="true" Font-Size="X-Large" Font-Underline="true"></asp:Label>

</td></tr>
<tr>
<td>
    作者：<asp:Label ID="lblAuthor" runat="server" Text="作者"></asp:Label>&nbsp;&nbsp;&nbsp;发布日期：<asp:Label ID="lblPubDate" runat="server"></asp:Label>

</td>
</tr>
<tr>
<td>
    <div id="divContent" runat="server">
    
    </div>
</td>
</tr>

</table>


</asp:Content>
