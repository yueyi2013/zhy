<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="download.aspx.cs" Inherits="Web.forum.download" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td colspan="3">
             <!--#include file="../inc/ads/zm/cpa_960_60.inc"-->
        </td>
    </tr>
    <tr>
        <td align="right" valign="middle" style="width:60px">分类：</td>
        
        <td align="left" valign="bottom">
            <asp:RadioButtonList ID="rbAdCat" runat="server" 
                RepeatColumns="5" RepeatDirection="Horizontal"
                DataTextField="AdCategoryName" DataValueField="AdCategoryId"
                AutoPostBack="true" onselectedindexchanged="rbAdCat_SelectedIndexChanged">
            </asp:RadioButtonList>
        </td>
        <td rowspan="2" align="left" valign="top">
            <!--#include file="../inc/ads/zm/ys_cpa_300_120.inc"-->
        </td>
    </tr>
    <tr>
        <td align="right" valign="middle">名称：</td>
        <td align="left" valign="top">
            <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton ID="imgBtnSearch" runat="server" ImageUrl="~/images/search_icon.gif" />
        </td>
        
    </tr>
    <tr>
        <td></td>
        <td align="left" valign="bottom">
            <hr style="width:100%" />
            <asp:UpdatePanel ID="MyUpdatePanelBody" runat="server" UpdateMode="Conditional">
                        <Triggers>                        
                            <asp:AsyncPostBackTrigger ControlID="imgBtnSearch" EventName="Click" />                        
                            <asp:AsyncPostBackTrigger ControlID="rbAdCat" 
                                EventName="SelectedIndexChanged" />
                        </Triggers>
                    <ContentTemplate>   
                    <asp:DataList ID="dlAdFeeds" runat="server" CellPadding="0" CellSpacing="0"
                        ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" 
                        RepeatDirection="Horizontal" RepeatColumns="1">
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" width="100%">
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td style=" width:160px">
                                <img alt="" src='<%# Eval("AdLogo") %>' />
                            </td>
                            <td align="left">
                                <asp:Label ID="lblTitle" runat="server" Font-Bold="true" Font-Size="Larger" Text='<%# Eval("AdName") %>'></asp:Label><br />
                                <%# Eval("AdDesc")%>
                            </td>
                            <td align="right" valign="bottom">
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("AdCode") %>' Target="_blank">点击下载</asp:HyperLink>
                            
                            </td>                            
                        </tr>
                        <tr>
                            <td colspan="3">
                                <hr style="width:100%" /> 
                            </td>
                        </tr>
                                              
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>                
                    </FooterTemplate>
                    </asp:DataList>
                    <asp:HiddenField ID="hfAdID" runat="server" Value="1" />
                     当前页索引：
                        <asp:Label ID="lblPageIndex0" runat="server" ForeColor="Red"></asp:Label>/
                                    总页数：<asp:Label ID="lblPageAll0" runat="server" ForeColor="Red"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp; 每页:
                        <asp:Label ID="lblPageSize0" runat="server" ForeColor="Red"></asp:Label>条/ 共：<asp:Label
                                        ID="lblPageRecord0" runat="server" ForeColor="Red"></asp:Label>条&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnFirst0" runat="server" Text="" CssClass="PagingFirstButtonCss" CausesValidation="false"
                                        OnClick="Button_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnPrev0" runat="server" Text="" CssClass="PagingBackButtonCss" CausesValidation="false"
                                        OnClick="Button_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnNext0" runat="server" Text="" CssClass="PagingNextButtonCss" CausesValidation="false"
                                        OnClick="Button_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnLast0" runat="server" Text="" CssClass="PagingLastButtonCss" CausesValidation="false"
                                        OnClick="Button_Click" />&nbsp;&nbsp;&nbsp;&nbsp; 跳转到第：
                        <asp:TextBox ID="txtPageIndex0" runat="server" Width="40px" Text="1"></asp:TextBox>页
                        <asp:Button ID="btnGo0" runat="server" Text="" CssClass="PagingGoButtonCss" CausesValidation="false"
                                        OnClick="Button_Click" />
                        <asp:CustomValidator ID="cvGo" runat="server" ClientValidationFunction="validateNumber"
                                        ControlToValidate="txtPageIndex0" Display="none" ValidateEmptyText="true" ErrorMessage="<font size='2'>请填写大于0的数字！</font>">
                        </asp:CustomValidator>
                        <ajaxToolkit:ValidatorCalloutExtender ID="vceGo" runat="server" TargetControlID="cvGo"
                            HighlightCssClass="validatorCalloutHighlight">
                        </ajaxToolkit:ValidatorCalloutExtender>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td align="center" valign="top">
            <!--#include file="../inc/ads/zm/y_cpa_300_250.inc"-->       
        
        </td>
    </tr>
</table>
<div id="divDouYX">
    <script type="text/javascript">
        ddgu_uid = "20710";
        ddgu_wid = "22192";
        ddgu_zid = "23942";
        ddgu_aid = "29";
        ddgu_type = "4";
        ddgu_w = "270";
        ddgu_h = "200";
    </script>
    <script src="http://js.union.doudouguo.com/c.js"></script>
</div>
</asp:Content>
