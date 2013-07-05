<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="bolgdetails.aspx.cs" Inherits="Web.forum.bolgdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td style="width:200px; text-align:left; vertical-align:top">
            
        </td>
        <td>
            <table>
                <tr><td>
                    <asp:Label ID="lblTitle" runat="server" Font-Size="X-Large" Font-Bold="true"></asp:Label></td></tr>
                <tr><td>
                    <div id="divBlog" runat="server"/>
                </td></tr>
                <tr><td></td></tr>
            </table>
                  
        </td>
    </tr>
</table>
</asp:Content>
