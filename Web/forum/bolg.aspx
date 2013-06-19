<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="bolg.aspx.cs" Inherits="Web.forum.bolg" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" media="screen,projection" type="text/css" href="../css/site/main.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">

<table>
<tr>
<!--分类-->
<td style="width:100px">

    <asp:TreeView ID="tvBolgCat" runat="server" 
                    onselectednodechanged="tvBolgCat_SelectedNodeChanged" >
                </asp:TreeView>
</td>
<!--博客列表-->
<td>

    <asp:UpdatePanel ID="MyUpdatePanelBody" runat="server" UpdateMode="Conditional">
        <Triggers>                        
           <asp:AsyncPostBackTrigger ControlID="tvBolgCat" EventName="SelectedNodeChanged" />                      
        </Triggers>
        <ContentTemplate> 
        <asp:Label ID="lblCategory" runat="server"></asp:Label>   
            <asp:Repeater ID="rpBolgList" runat="server">
                <HeaderTemplate>
                    <table>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>[<%# Eval("ATName")%>]&nbsp;&nbsp;<%# Eval("ArTitle")%></td>
                        <td><img alt="" src="#"/>&nbsp;&nbsp; <%# Eval("ArContent")%></td>
                        <td><%# Eval("ArAuthor")%>&nbsp;&nbsp; <%# Eval("ArPubDate")%> <%# Eval("ArClicks")%> <%# Eval("ArCmtNumber")%> <%# Eval("ACMTop")%> <%# Eval("ACMDown")%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            <asp:HiddenField ID="hfACID" runat="server" Value="0" />
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
</tr>
</table>


</asp:Content>
