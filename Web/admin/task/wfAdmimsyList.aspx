<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main0.Master" AutoEventWireup="true" CodeBehind="wfAdmimsyList.aspx.cs" Inherits="Web.admin.task.wfAdmimsyList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<fieldset style="width: 950px">
    <legend>ADmimsy</legend>
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
                            <asp:Button ID="btnTask" runat="server" Text="开始任务" CssClass="buttonCss" CausesValidation="false"
                                OnClick="btnTask_Click" OnClientClick="return ConfirmTask()" />
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
                                    <asp:AsyncPostBackTrigger ControlID="btnAutoReg" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnTask" EventName="Click" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:GridView ID="MstGridView" runat="server" AutoGenerateColumns="False" Width="98%"
                                        AllowPaging="false" DataKeyNames="AdmyId" OnRowCommand="MstGridView_RowCommand"
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
                                            <asp:BoundField DataField="AdmyCode" HeaderText="网站编码">
                                                <ItemStyle Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdmyUserName" HeaderText="用户名">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdmyPassword" HeaderText="密码">
                                                <ItemStyle Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdmyEmail" HeaderText="邮箱">
                                                <ItemStyle Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdmyCountry" HeaderText="国家">
                                                <ItemStyle Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ProxyAddress" HeaderText="代理地址">
                                                <ItemStyle Width="110px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IsEnableProxy" HeaderText="启用代理">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdmyViews" HeaderText="次数">
                                                <ItemStyle Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdmyReferrals" HeaderText="推荐人">
                                                <ItemStyle Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdmyIsReferrals" HeaderText="是推荐人">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdmyStatus" HeaderText="状态">
                                                <ItemStyle Width="50px" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="UpdateDT" HeaderText="更新日期">
                                                <ItemStyle Width="160px" />
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
    <asp:Panel ID="PanelBody" runat="server" Style="width: 300px; display: none;" CssClass="modalPopup">
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
                <asp:AsyncPostBackTrigger ControlID="btnAutoReg" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                        <td height="25" width="30%" align="right">
                            网站编码：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox id="txtAdmyCode" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            用户名： <asp:HiddenField ID="hfAdmyId" runat="server" Value="0"/>
                        </td>
                        <td height="25" width="*" align="left">
                           <asp:TextBox id="txtAdmyUserName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            密码：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox id="txtAdmyPassword" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            代理地址：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox id="txtProxyAddress" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            国家：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox id="txtAdmyCountry" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            启用代理：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:RadioButtonList ID="rblIsEnableProxy" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="启用" Value="Y" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="不启用" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            状态：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:RadioButtonList ID="rblAdmyStatus" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="有效" Value="A" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="失效" Value="I"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="text-align: right;">
            <asp:Button ID="btnAutoReg" runat="server" Text="自动注册" Width="65px" OnClick="btnAutoReg_Click"
                CssClass="buttonCss"/>
            &nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" Text="保存" Width="65px" OnClick="btnSave_Click"
                CssClass="buttonCss" OnClientClick="javascript:ClearZero()" />
            &nbsp;&nbsp;
            <asp:Button ID="btnClose" runat="server" Text="关闭" Width="65px" OnClick="btnClose_Click"
                CssClass="buttonCss" CausesValidation="false"/>&nbsp;&nbsp;
        </div>
    </asp:Panel>
    </fieldset>
</asp:Content>
