﻿<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="bolg.aspx.cs" Inherits="Web.forum.bolg" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" media="screen,projection" type="text/css" href="../css/site/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
    <tr align="left" valign="top">
        <td >
        <fieldset>
        <legend>博客列表</legend> 
        <asp:UpdatePanel ID="MyUpdatePanelBody" runat="server" UpdateMode="Conditional">
            <Triggers>                        
                <asp:AsyncPostBackTrigger ControlID="tvBolgCat" EventName="SelectedNodeChanged" />                      
            </Triggers>
            <ContentTemplate> 
                <asp:Label ID="lblCategory" runat="server"></asp:Label>   
                <asp:UpdateProgress ID="upgLoading" runat="server">
                    <ProgressTemplate>
                      &nbsp;<p style=" font-weight:bold; color:Blue; text-align:center">正在努力为您加载，请稍等......</p>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <asp:Repeater ID="rpBolgList" runat="server" 
                    onitemcommand="rpBolgList_ItemCommand">
                    <HeaderTemplate>
                    <table style="table-layout:fixed;word-break: break-all; overflow:hidden">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                             <td>
                                <asp:LinkButton ID="lbACName" runat="server" CausesValidation="false" CommandName="ACName" Text='<%# GetACName(Eval("ACName").ToString())%>'/>
                                     &nbsp;&nbsp;
                                <a href='bolgdetails.aspx?bgid=<%# Eval("ArId")%>' target="self" style="font-size:larger; font-weight:bold"><%# Eval("ArTitle")%></a>                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img alt="" src="#"/>&nbsp;&nbsp;<%# ParseContent(Eval("ArContent").ToString())%></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="lbAuthor" runat="server" CausesValidation="false" CommandName="ArAuthor" Text='<%# Eval("ArAuthor")%>'/>&nbsp;&nbsp; 
                                <%# Eval("ArPubDate")%> 
                                <asp:LinkButton ID="lbArClicks" runat="server" CausesValidation="false" CommandName="ArClicks" Text='<%# GetArClicks(Eval("ArClicks").ToString())%>'/> &nbsp;&nbsp; 
                                <asp:LinkButton ID="lbArCmtNumber" runat="server" CausesValidation="false" CommandName="ArCmtNumber" Text='<%# GetCmtNumber(Eval("ArCmtNumber").ToString())%>'/>&nbsp;&nbsp; 
                                <asp:LinkButton ID="lbACMTops" runat="server" CausesValidation="false" CommandName="ACMTops" Text='<%# GetACMTops(Eval("ACMTops").ToString())%>'/>&nbsp;&nbsp; 
                                <asp:LinkButton ID="lbACMDowns" runat="server" CausesValidation="false" CommandName="ACMDowns" Text='<%# GetACMDowns(Eval("ACMDowns").ToString())%>'/>&nbsp;&nbsp;                             
                                <hr style=" width:100%" />
                            </td>                        
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                         </table>
                    </FooterTemplate>
                </asp:Repeater>
                <asp:HiddenField ID="hfACID" runat="server" />
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
        <!--分类-->
        <td style="width:160px;">
        <fieldset>
            <legend>博客分类</legend>
                <asp:UpdatePanel ID="upNewsCategory" runat="server" UpdateMode="Conditional">
                    <Triggers>                        
                            <asp:AsyncPostBackTrigger ControlID="tvBolgCat" EventName="SelectedNodeChanged" />                        
                    </Triggers>
                    <ContentTemplate>
                    <asp:TreeView ID="tvBolgCat" runat="server" 
                        NodeStyle-Font-Bold="true"
                        NodeStyle-HorizontalPadding="30"
                        onselectednodechanged="tvBolgCat_SelectedNodeChanged" >
                    </asp:TreeView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <!--#include file="../inc/ads/clicksor/160_600.inc"-->  
        </fieldset>        
    </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foot" runat="server">     
     <!--#include file="../inc/ads/clicksor/txt_link_rb.inc"-->
</asp:Content>