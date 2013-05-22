<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true"
    CodeBehind="wfLanMuList.aspx.cs" Inherits="ZHY.Web.admin.wfLanMuList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="server">
    <asp:UpdatePanel ID="MyUpdatePanelHead" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text="栏目名称:"></asp:Label>
            <asp:TextBox ID="txtLanMuName" runat="server" Width="300px"></asp:TextBox>
            <asp:Button ID="btnLanMuName" runat="server" Text="查询" CausesValidation="false" OnClick="btnLanMuName_Click"
                CssClass="buttonCss" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <table cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td align="left" style="width: 180px;" valign="top">
                <asp:UpdatePanel ID="MyUpdatePanelTreeView" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="MstGridView" EventName="RowCommand" />
                    </Triggers>
                    <ContentTemplate>
                        <div style="height: 500px; overflow: auto">
                            <asp:TreeView ID="tvLanMu" runat="server" OnSelectedNodeChanged="tvLanMu_SelectedNodeChanged"
                                ExpandDepth="2">
                            </asp:TreeView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left" valign="top">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td align="left">
                            栏目列表
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:UpdatePanel ID="MyUpdatePanelBody" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnLanMuName" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                                    <%--<asp:AsyncPostBackTrigger ControlID="btnBack" EventName="Click" />--%>
                                    <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="tvLanMu" EventName="SelectedNodeChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:GridView ID="MstGridView" runat="server" AutoGenerateColumns="False" Width="98%"
                                        AllowPaging="false" DataKeyNames="LMID" OnRowCommand="MstGridView_RowCommand"
                                        HeaderStyle-HorizontalAlign="Center">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                <HeaderTemplate>
                                                    <input id="btnSelectAll" style="cursor: hand" onclick="GetAllCheckBox(ctl00_cphMain_MstGridView_ctl01_btnSelectAll)"
                                                        type="checkbox" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkItem" runat="server" onclick="changecolor(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="LMID" HeaderText="栏目编号">
                                                <ItemStyle Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LMCode" HeaderText="栏目编码">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LMName" HeaderText="栏目名称">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="栏目描述" DataField="LMDescribe">
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="LMParantName" HeaderText="父栏目名称">
                                                <ItemStyle Width="150px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="显示位置">
                                                <ItemStyle Width="70px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#GetLocation(Eval("LMLocation").ToString()) %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="LMSeq" HeaderText="排序">
                                                <ItemStyle Width="40px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="操作" ShowHeader="False">
                                                <ItemStyle Width="120px" />
                                                <ItemTemplate>
                                                    &nbsp;
                                                    <%-- <asp:LinkButton ID="lbViewChild" runat="server" CausesValidation="False" CommandName='<%#Eval("LMParantID") %>'
                                                        Text="查看子栏目" CommandArgument='<%#Eval("LMID") %>'></asp:LinkButton>--%>
                                                    &nbsp;&nbsp;
                                                    <asp:LinkButton ID="lbAdd" runat="server" CommandArgument='<%#Eval("LMID") %>' Text="添加子栏目"
                                                        CommandName="add" CausesValidation="false"></asp:LinkButton>
                                                    &nbsp;&nbsp;
                                                    <asp:LinkButton ID="lbDelete" runat="server" CommandArgument='<%#Eval("LMID") %>'
                                                        Text="删除" CommandName="del" CausesValidation="false" OnClientClick="return Confirm()"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:HiddenField ID="hfLMID" runat="server" Value="0" />
                                    <asp:HiddenField ID="hfLMID0" runat="server" />
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
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="MyUpdatePanelFoot" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnLanMuName" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="MstGridView" EventName="RowCommand" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:Button ID="btnAdd" runat="server" Text="增加栏目" CssClass="buttonCss" CausesValidation="false" />
                                    <asp:Button ID="btnModify" runat="server" Text="修改" CssClass="buttonCss" CausesValidation="false"
                                        OnClick="btnModify_Click" Enabled="false" />
                                    <asp:Button ID="btnDelete" runat="server" Text="批量删除" OnClientClick="return Confirm()"
                                        CssClass="buttonCss" CausesValidation="false" OnClick="btnDelete_Click" />
                                    <ajaxToolkit:ModalPopupExtender ID="mpMstAdd" runat="server" TargetControlID="btnAdd"
                                        PopupControlID="PanelBody" BackgroundCssClass="modalBackground" DropShadow="true"
                                        PopupDragHandleControlID="PanelDrag" Drag="true">
                                    </ajaxToolkit:ModalPopupExtender>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%--新增栏目弹出框--%>
    <asp:Panel ID="PanelBody" runat="server" Style="width: 450px; display: none;" CssClass="modalPopup">
        <asp:UpdatePanel ID="MyUpdatePanelPanelDrag" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="PanelDrag" runat="server" CssClass="modalDragPopup">
                    <asp:LinkButton ID="lbClose" runat="server" Text="关闭" OnClick="btnClose_Click" CausesValidation="false"></asp:LinkButton><br />
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
                        <td height="25" width="30%" align="right">
                            LMCode ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtLMCode" runat="server" Width="200px"></asp:TextBox>
                            <asp:TextBox ID="txtLMID" runat="server" Width="200px" Visible="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            ParantID ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtParantID" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            LMName ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtLMName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            LMOrder ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtLMOrder" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            LMStyleID ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtLMStyleID" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            LMPage ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtLMPage" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            LMStatus ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtLMStatus" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            LMDes ：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtLMDes" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
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
</asp:Content>
