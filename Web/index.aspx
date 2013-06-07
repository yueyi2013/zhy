<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Web.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/manage.js" type="text/javascript"></script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">

<table cellpadding="0" cellspacing="0" width="100%">
<tr>
<!--主体1--Flash-->
<td style="width:60%">
    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,28,0"
                    width="600" height="80">
        <param name="movie" value="images/flash/cont_top.swf" />
        <param name="quality" value="high" />
        <param name="wmode" value="opaque" />
        <embed src="images/flash/cont_top.swf" quality="high" wmode="opaque" pluginspage="http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash"
        type="application/x-shockwave-flash" width="950" height="80"></embed>
    </object>
    <!--显示首面Falsh-->
    <div style="height: 0px" id="divflashContent" runat="server"></div>
    <script type="text/javascript">fDisplayFalsh();</script>                                       
                                          
</td>
<!--主体1--最新更新-->
<td>
    <div id="topNews">
        <asp:DataList ID="dlNewsTop" runat="server">
            
        </asp:DataList>        
    </div>
</td>
</tr>
<!--新闻-->
<tr><td colspan="2">




</td></tr>

<!--博客-->
<tr><td colspan="2">




</td></tr>
</table>



</asp:Content>
