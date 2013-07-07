<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main0.Master" AutoEventWireup="true" CodeBehind="wfAdList.aspx.cs" Inherits="Web.admin.site.ads.wfAdList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<fieldset style="width: 900px">
    <legend>广告管理</legend>
    <asp:UpdatePanel ID="MyUpdatePanelHead" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text="名称:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="查询" CausesValidation="false" OnClick="btnSearch_Click"
                CssClass="buttonCss" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <table cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td align="left" valign="top">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" Text="增加" CssClass="buttonCss" 
                                CausesValidation="false"/>
                            <asp:Button ID="btnModify" runat="server" Text="修改" CssClass="buttonCss" CausesValidation="false"
                                OnClick="btnModify_Click" Enabled="false" />
                            <asp:Button ID="btnDelete" runat="server" Text="批量删除" OnClientClick="return Confirm()"
                                CssClass="buttonCss" CausesValidation="false" OnClick="btnDelete_Click" />
                            <ajaxToolkit:ModalPopupExtender ID="mpMstAdd" runat="server" TargetControlID="btnAdd"
                                PopupControlID="PanelBody" BackgroundCssClass="modalBackground" DropShadow="true"
                                PopupDragHandleControlID="PanelDrag" Drag="true">
                            </ajaxToolkit:ModalPopupExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:UpdatePanel ID="MyUpdatePanelBody" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:GridView ID="MstGridView" runat="server" AutoGenerateColumns="False" Width="98%"
                                        AllowPaging="false" DataKeyNames="AdId" OnRowCommand="MstGridView_RowCommand"
                                        HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="MstGridViewHeaderCss" OnRowDataBound="MstGridView_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                <HeaderTemplate>
                                                    <input id="btnSelectAll" style="cursor: hand" onclick="GetAllCheckBox(ctl00$ContentPlaceHolder1$MstGridView$ctl01$btnSelectAll)"
                                                        type="checkbox" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkItem" runat="server" onclick="changecolor(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="AdLogo" HeaderText="广告logo">
                                                <ItemStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdName" HeaderText=" 广告名称">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdCategoryId" HeaderText="广告分类">
                                                <ItemStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdBgCode" HeaderText="计费类型">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdUnitPrice" HeaderText="广告单价">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdUnit" HeaderText="广告单价">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdBillingCycle" HeaderText="广告单价">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdSource" HeaderText="广告单价">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdCode" HeaderText="广告单价">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdDesc" HeaderText="广告单价">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Status" HeaderText="状态">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CreateAt" HeaderText="创建日期">
                                                <ItemStyle Width="250px" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="CreateBy" HeaderText="创建人">
                                                <ItemStyle Width="80px" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="UpdateDT" HeaderText="更新日期">
                                                <ItemStyle Width="250px" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="UpdateBy" HeaderText="更新人">
                                                <ItemStyle Width="80px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>                                   
                                    当前页索引：<asp:Label ID="lblPageIndex0" runat="server" ForeColor="Red"></asp:Label>/
                                    总页数：<asp:Label ID="lblPageAll0" runat="server" ForeColor="Red"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp; 每页:
                                    <asp:Label ID="lblPageSize0" runat="server" ForeColor="Red"></asp:Label>条/ 共：<asp:Label
                                        ID="lblPageRecord0" runat="server" ForeColor="Red"></asp:Label>条&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnFirst0" runat="server" Text="第一页" CssClass="buttonCss" CausesValidation="false"
                                        OnClick="Button_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnPrev0" runat="server" Text="上一页" CssClass="buttonCss" CausesValidation="false"
                                        OnClick="Button_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnNext0" runat="server" Text="下一页" CssClass="buttonCss" CausesValidation="false"
                                        OnClick="Button_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnLast0" runat="server" Text="最后一页" CssClass="buttonCss" CausesValidation="false"
                                        OnClick="Button_Click" />&nbsp;&nbsp;&nbsp;&nbsp; 跳转到第：
                                    <asp:TextBox ID="txtPageIndex0" runat="server" Width="40px" Text="1"></asp:TextBox>页
                                    <asp:Button ID="btnGo0" runat="server" Text="GO" CssClass="buttonCss" CausesValidation="false"
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
            </td>
        </tr>
    </table>
    <%--新增弹出框--%>
    <asp:Panel ID="PanelBody" runat="server" Style="width: 400px; display: none;" CssClass="modalPopup">
        <asp:UpdatePanel ID="MyUpdatePanelPanelDrag" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="PanelDrag" runat="server" CssClass="modalDragPopup">
                    <asp:LinkButton ID="lbClose" runat="server" Text="关闭" OnClick="btnClose_Click" CausesValidation="false"></asp:LinkButton>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="MyUpdatePanelPanelBody" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnModify" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="MstGridView" EventName="RowCommand" />
            </Triggers>
            <ContentTemplate>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" align="right">
                            广告分类：
                        </td>
                        <td height="25" width="*" align="left">                            
                            <asp:DropDownList ID="ddlAdCategory" runat="server" DataValueField="AdId" DataTextField="AdName">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="20%" align="right">
                            广告logo：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox id="txtAdLogo" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right">
                            广告名：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox id="txtAdName" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right">
                            计费类型：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox id="txtAdBgCode" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td height="25" align="right">
                            广告单价： <asp:HiddenField ID="hfAdId" runat="server" Value="0"/>
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox id="txtAdUnitPrice" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right">
                            计价单位：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox id="txtAdUnit" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right">
                            结算周期：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox id="txtAdBillingCycle" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right">
                            广告源：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox id="txtAdSource" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right">
                            广告代码：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox id="txtAdCode" runat="server"  Width="300px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right">
                            广告描述：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox id="txtAdDesc" runat="server" Width="300px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right">
                            状态：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:RadioButtonList ID="rbStatus" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="A" Text="生效"></asp:ListItem>
                                <asp:ListItem Value="N" Text="不生效"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="text-align: right;">
            <asp:Button ID="btnSave" runat="server" Text="保存" Width="65px" OnClick="btnSave_Click"
                CssClass="buttonCss" OnClientClick="javascript:ClearZero()" />
            &nbsp;&nbsp;
            <asp:Button ID="btnClose" runat="server" Text="关闭" Width="65px" OnClick="btnClose_Click"
                CssClass="buttonCss" CausesValidation="false" />&nbsp;&nbsp;
        </div>
    </asp:Panel>
    </fieldset>
</asp:Content>
