<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="newsdetails.aspx.cs" Inherits="Web.forum.newsdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" media="screen,projection" type="text/css" href="../css/site/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="center">    
            <!--#include file="../inc/ads/888/cpa_942_268.inc"-->
        </td>
    </tr>
    <tr>
    <td>
    <div class="left_content">
        <asp:Label ID="lblTitle" runat="server" Text="标题" Font-Bold="true" Font-Size="X-Large" Font-Underline="true"></asp:Label><br />
        作者：<asp:Label ID="lblAuthor" runat="server" Text="作者"></asp:Label>&nbsp;&nbsp;&nbsp;发布日期：<asp:Label ID="lblPubDate" runat="server"></asp:Label>
        <div id="divContent" runat="server">
    
        </div>

        <br />分享到腾讯微博：
        <div id="divTXWB" runat="server">
                            
        </div>
        <br />
        分享到新浪微博：
        <div id="divXLWB" runat="server">
    
        </div>
    </div>
    <div class="right_content">
        <!--#include file="../inc/ads/fk/cps_sousuo.inc"-->
        <!--#include file="../inc/ads/fk/cps_360_120.inc"-->
    
    </div>
    </td>
    </tr>

    </table>


</asp:Content>
