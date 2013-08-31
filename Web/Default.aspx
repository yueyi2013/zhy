<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Web.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
    <script src="js/main.js" type="text/javascript"></script>
    <link rel="stylesheet" media="screen,projection" type="text/css" href="css/site/main.css" />
     <!--#include file="inc/api/qq/wb/ydq_head.inc"-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
<tr>
<!--主体1--Flash-->
<td>
    <div id="col" class="box">
    <div id="ribbon"></div>
    <div id="col-text">
    <!--#include file="inc/ads/admimsy/300_250.inc"-->
    </div>
    <div style=" height:280px">              
        <p style=" font-size:larger; font-weight:bold">
            <asp:HyperLink ID="hlNew" runat="server" Target="_blank"></asp:HyperLink>
        </p>
        <asp:Label ID="lblContent" runat="server" ></asp:Label>
        <asp:HyperLink ID="hlNewDetail" runat="server" Target="_blank" Text="更多>>>" Font-Bold="true" ForeColor="Blue"></asp:HyperLink>       

        <asp:DataList ID="dlNewsTop" runat="server" RepeatDirection="Vertical">
            <ItemTemplate>
                <a target="_blank" href="forum/newsdetails.aspx?rciid=<%# Eval("NTId")%>" title='<%# DataBinder.Eval(Container, "DataItem.NTTitle")%>'><%# HtmlDecode(DataBinder.Eval(Container, "DataItem.NTTitle").ToString())%></a>         
            </ItemTemplate>
        </asp:DataList>
    </div>
    
    </div>    
</td>
</tr>
<!--新闻-->
<tr>
    <td>
        <div id="col-bottom"></div>
        <hr class="noscreen" /> 
        <asp:DataList ID="dlNewsList" runat="server" RepeatColumns="3" RepeatDirection="Vertical"
            ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Top" Width="99%" CellSpacing="6">
            <ItemTemplate>            
                <div id="cols3-top"></div>
                <div id="cols3" class="box">
                    <div class="col last" style="text-align:left">                    
                        <h3>
                            <a href="forum/news.aspx"><%# DataBinder.Eval(Container, "DataItem.NewsCategoryName")%></a>
                        </h3>
                    </div>                    
                    <asp:Repeater ID="rpNewsList" runat="server" 
                        DataSource='<%# DataBinder.Eval(Container, "DataItem.RiList") %>'>
                            <HeaderTemplate>
                               <div class="col-text">
                                <table cellpadding="5" cellspacing="0" width="100%">
                                   
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <img alt="" src="images/site/ul-01.gif" />
                                    </td>
                                    <td>
                                        <a target="_blank" href="forum/newsdetails.aspx?rciid=<%# Eval("RCItemId")%>" title='<%# DataBinder.Eval(Container, "DataItem.RCItemTitle")%>'><%# CutTitleString(DataBinder.Eval(Container, "DataItem.RCItemTitle").ToString())%></a>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>    
                                </div>
                                <div class="col-more"><a href="forum/news.aspx"><img src="images/site/cols3-more.gif" alt="" /></a></div>
                                                              
                            </FooterTemplate>
                    </asp:Repeater>                    
                    <hr class="noscreen">
                </div>
                <div id="cols3-bottom"></div>
         </ItemTemplate>
         <FooterTemplate>
            
         </FooterTemplate>
    </asp:DataList>
    <hr />
</td></tr>

<!--租房-->
<tr><td >
    
</td></tr>

<!--游戏-->
<tr><td>
    

</td></tr>
<!--博客-->
<tr><td>



</td></tr>
</table>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">
    <!--#include file="inc/ads/tb/chongzhi.inc"-->
</asp:Content>

