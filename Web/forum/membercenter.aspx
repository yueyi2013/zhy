<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="membercenter.aspx.cs" Inherits="Web.forum.membercenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" media="screen,projection" type="text/css" href="../css/site/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="left" valign="top" style="width:200px">
            <asp:BulletedList ID="blNav" runat="server" DataTextField="MMName" DataValueField="MMId">
            </asp:BulletedList>
        </td>
        <td>
            <asp:UpdatePanel ID="MyUpdatePanelBody" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                   
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="blNav" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
</asp:Content>
