<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Web.forum.news" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" media="screen,projection" type="text/css" href="../css/site/main.css" />
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr align="left" valign="top">
            <td style="width:150px">
            <fieldset>
                    <legend>新闻分类</legend>
                        <asp:TreeView ID="tvNews" runat="server" 
                            onselectednodechanged="tvNews_SelectedNodeChanged" >
                        </asp:TreeView>                        
            </fieldset>
            </td>
            <td align="left" valign="top">
                <fieldset>
                    <legend>新闻列表</legend>
                    <asp:UpdatePanel ID="MyUpdatePanelBody" runat="server" UpdateMode="Conditional">
                    <Triggers>                        
                        <asp:AsyncPostBackTrigger ControlID="tvNews" EventName="SelectedNodeChanged" />                        
                    </Triggers>
                    <ContentTemplate>         
                    <asp:Label ID="lblCategory" runat="server"></asp:Label>           
                    <asp:DataList ID="dlNewsList" runat="server" 
                        ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Left" 
                        RepeatDirection="Horizontal" RepeatColumns="1">
                        <HeaderTemplate>
                            <ul class="ul-01">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <li>
                                <p style=" font-size:larger; font-weight:bold"><a target="_blank" href="newsdetails.aspx?rciid=<%# Eval("RCItemId")%>" title='<%# DataBinder.Eval(Container, "DataItem.RCItemTitle")%>'> <%# HtmlDecode(DataBinder.Eval(Container, "DataItem.RCItemTitle").ToString())%></a>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <font  style="font-size:small; color:Blue; text-align:right">发布日期：<%# Eval("RCItemPubDate")%></font></p><br/>
                                &nbsp;&nbsp;&nbsp;&nbsp;<%# GetNewsContent(DataBinder.Eval(Container, "DataItem.RCItemDescription").ToString())%><hr style="width:100%"/></li>       
                        </ItemTemplate>
                        <FooterTemplate></ul></FooterTemplate>
                    </asp:DataList>                    
                    <asp:HiddenField ID="hfRCID" runat="server" Value="1" />
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
            </fieldset>
            </td>
        </tr>
    </table>

</asp:Content>
