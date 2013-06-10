<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/manage.js" type="text/javascript"></script>   
    <link rel="stylesheet" media="screen,projection" type="text/css" href="css/site/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">

<table cellpadding="0" cellspacing="0" width="100%">
<tr>
<!--主体1--Flash-->
<td>
    <div id="col" class="box">
    <div id="ribbon"></div>
    <div id="divflashContent" runat="server"></div>
    <script type="text/javascript">fDisplayFalsh();</script>
    <!--显示首面Falsh-->
    <div id="col-text">
        <h2 id="slogan">
            <asp:Label ID="lblNewsTitle" runat="server" Text="最新消息"></asp:Label>
        </h2>
        <asp:DataList ID="dlNewsTop" runat="server" RepeatDirection="Vertical">
            <ItemTemplate>
                <a target="_blank" href="forum/newsdetails.aspx?rciid=<%# Eval("NTId")%>" title='<%# DataBinder.Eval(Container, "DataItem.NTTitle")%>'><%# DataBinder.Eval(Container, "DataItem.NTTitle")%></a>         
            </ItemTemplate>
        </asp:DataList>
    </div>
    </div>    
</td>
</tr>
<!--新闻-->
<tr><td>
    <div id="col-bottom"></div>
    <hr class="noscreen" />
    <div id="cols3-top"></div>
    <div id="cols3" class="box">
    <asp:DataList ID="dlNewsList" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
     ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" >
         <ItemTemplate>
                <div id="cols3" class="box">
                <div class="col">
                    <h3>
                        <a href="forum/news.aspx"><%# DataBinder.Eval(Container, "DataItem.NewsCategoryName")%></a>
                    </h3>                    
                    <ul class="ul-01">
                        <asp:DataList ID="dlNewsDetails" runat="server" RepeatDirection="Vertical" DataSource='<%# DataBinder.Eval(Container, "DataItem.RiList") %>'>
                            <ItemTemplate>
                                <li>
                                    <a target="_blank" href="forum/newsdetails.aspx?rciid=<%# Eval("RCItemId")%>" title='<%# DataBinder.Eval(Container, "DataItem.RCItemTitle")%>'><%# DataBinder.Eval(Container, "DataItem.RCItemTitle")%></a>
                                </li>                           
                            </ItemTemplate>
                        </asp:DataList>                     
                    </ul>
                    <div class="col-more"><a href="forum/news.aspx"><img src="images/site/cols3-more.gif" alt="" /></a></div>
                </div>
                </div>
         </ItemTemplate>
    </asp:DataList>
    </div>
    <hr />
</td></tr>

<!--租房-->
<tr><td>




</td></tr>

<!--游戏-->
<tr><td>




</td></tr>
<!--博客-->
<tr><td>




</td></tr>
</table>



</asp:Content>
