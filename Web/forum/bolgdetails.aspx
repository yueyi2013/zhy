<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="bolgdetails.aspx.cs" Inherits="Web.forum.bolgdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" media="screen,projection" type="text/css" href="../css/site/main.css" />
    <!--#include file="../inc/api/qq/wb/ydq_head.inc"-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
<!--#include file="../inc/ads/google/970_90.inc"-->
<table cellpadding="0" cellspacing="0" width="98%">  
    <tr>
        <td>
            <div class="left_blog_content">
                <asp:Label ID="lblTitle" runat="server" Font-Size="X-Large" Font-Bold="true"></asp:Label>                
                <div id="divBlog" runat="server"/>         
                分享到腾讯微博：
                <div id="divTXWB" runat="server" />
                <br />
                分享到新浪微博：
                <div id="divXLWB" runat="server" />
                
                查看评论：
                <div id="divComments"  runat="server" style=" display:none">
                    <table cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>用户名：</td>
                        <td>
                            <asp:Label ID="lblUser" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>评论：</td>
                        <td>
                            <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Width="300px" Height="100px"></asp:TextBox>                                
                        </td>
                    </tr>
                    <tr>
                    <td>
                    
                    </td>
                    <td>
                    
                    </td>
                    </tr>
                </table>                
                </div>
                <div id="divLogin" runat="server">
                    您还没有登录,请<a href="memberlogin.aspx" style="color:Red; font-weight:bold">[登录]</a>或<a href="register.aspx" style="color:Red; font-weight:bold">[注册]</a>
                </div>               

                * 以上用户言论只代表其个人观点，不代表SYIHY网站的观点或立场.
            </div>
            <div class="right_blog_content" >
        
            </div>
        </td>
    </tr>
    </table>

    <!--#include file="../inc/api/qq/wb/Q-Share.inc"-->
    <!--#include file="../inc/api/qq/wb/yjfx.inc"-->
</asp:Content>
