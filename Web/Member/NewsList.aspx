<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="NewsList.aspx.cs" Inherits="Web.Member.NewsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
<tr>
<td style="width:30%">
    <asp:TreeView ID="tvNewsCategory" runat="server">
    </asp:TreeView>
</td>
<td>
    <asp:DataList ID="dlNewsList" runat="server">
    </asp:DataList>
</td>
</tr>

</table>
</asp:Content>
