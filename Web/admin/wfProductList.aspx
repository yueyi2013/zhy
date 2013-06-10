<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true"
    CodeBehind="wfProductList.aspx.cs" Inherits="ZHY.Web.admin.wfProductList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../js/My97DatePicker4.0/WdatePicker.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<fieldset>
    <legend>��Ʒ�б�</legend>--%>
    <asp:UpdatePanel ID="MyUpdatePanelHead" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
        </Triggers>
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text="����:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="��ѯ" CausesValidation="false" OnClick="btnSearch_Click"
                CssClass="buttonCss" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <table cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td align="left" valign="top">
                <table cellspacing="0" cellpadding="0" width="100%">
                    <tr>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="buttonCss" CausesValidation="false" />
                            <asp:Button ID="btnModify" runat="server" Text="�޸�" CssClass="buttonCss" CausesValidation="false"
                                OnClick="btnModify_Click" Enabled="false" />
                            <asp:Button ID="btnDelete" runat="server" Text="����ɾ��" OnClientClick="return Confirm()"
                                CssClass="buttonCss" CausesValidation="false" OnClick="btnDelete_Click" />
                            <ajaxToolkit:ModalPopupExtender ID="mpMstAdd" runat="server" TargetControlID="btnAdd"
                                PopupControlID="PanelBody" BackgroundCssClass="modalBackground" DropShadow="true"
                                PopupDragHandleControlID="PanelDrag" Drag="true">
                            </ajaxToolkit:ModalPopupExtender>
                            <%--<asp:Button ID="Button1" runat="server" Text="�༭����" CssClass="buttonCss" CausesValidation="false" />
                            <ajaxToolkit:ModalPopupExtender ID="mpMstPam" runat="server" TargetControlID="Button1"
                                PopupControlID="PanelItemBody" BackgroundCssClass="modalBackground" DropShadow="true"
                                PopupDragHandleControlID="PanelItemHead" Drag="true">
                            </ajaxToolkit:ModalPopupExtender>--%>
                            <asp:Button ID="btnEditPic" runat="server" Text="�༭ͼƬ" CssClass="buttonCss" CausesValidation="false"
                                OnClick="btnEditPic_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:UpdatePanel ID="MyUpdatePanelBody" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnEditPic" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:GridView ID="MstGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="ProID"
                                        OnRowCommand="MstGridView_RowCommand" HeaderStyle-CssClass="MstGridViewHeaderCss" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="MstGridView_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderStyle Width="30px" HorizontalAlign="Center" />
                                                <ItemStyle Width="30px" HorizontalAlign="Center" />
                                                <HeaderTemplate>
                                                    <input id="btnSelectAll" style="cursor: hand" onclick="GetAllCheckBox(ctl00_ContentPlaceHolder1_MstGridView_ctl01_btnSelectAll)"
                                                        type="checkbox" runat="server" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkItem" runat="server" onclick="changecolor(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ProCode" HeaderText="����">
                                                <ItemStyle Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ProName" HeaderText="����">
                                                <ItemStyle Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ProPrice" HeaderText="�۸���Ԫ��">
                                                <ItemStyle Width="80px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ProInputDate" HeaderText="¼��ʱ��">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ProPublish" HeaderText="����ʱ��">
                                                <ItemStyle Width="100px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ProStatusName" HeaderText="״̬">
                                                <ItemStyle Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ProRecommendName" HeaderText="�Ƿ��Ƽ�">
                                                <ItemStyle Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ProIsNewName" HeaderText="�Ƿ���Ʒ">
                                                <ItemStyle Width="60px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ProIsHotName" HeaderText="�Ƿ�����">
                                                <ItemStyle Width="60px" />
                                            </asp:BoundField>
                                        </Columns>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:GridView>
                                    <asp:HiddenField ID="hfProID" runat="server" Value="0" />
                                    ��ǰҳ������<asp:Label ID="lblPageIndex0" runat="server" ForeColor="Red"></asp:Label>/
                                    ��ҳ����<asp:Label ID="lblPageAll0" runat="server" ForeColor="Red"></asp:Label>
                                    &nbsp;&nbsp;&nbsp;&nbsp; ÿҳ:
                                    <asp:Label ID="lblPageSize0" runat="server" ForeColor="Red"></asp:Label>��/ ����<asp:Label
                                        ID="lblPageRecord0" runat="server" ForeColor="Red"></asp:Label>��&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnFirst0" runat="server" Text="��һҳ" CssClass="buttonCss" CausesValidation="false"
                                        OnClick="Button_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnPrev0" runat="server" Text="��һҳ" CssClass="buttonCss" CausesValidation="false"
                                        OnClick="Button_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnNext0" runat="server" Text="��һҳ" CssClass="buttonCss" CausesValidation="false"
                                        OnClick="Button_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnLast0" runat="server" Text="���һҳ" CssClass="buttonCss" CausesValidation="false"
                                        OnClick="Button_Click" />&nbsp;&nbsp;&nbsp;&nbsp; ��ת���ڣ�
                                    <asp:TextBox ID="txtPageIndex0" runat="server" Width="40px" Text="1"></asp:TextBox>ҳ
                                    <asp:Button ID="btnGo0" runat="server" Text="GO" CssClass="buttonCss" CausesValidation="false"
                                        OnClick="Button_Click" />
                                    <asp:CustomValidator ID="cvGo" runat="server" ClientValidationFunction="validateNumber"
                                        ControlToValidate="txtPageIndex0" Display="none" ValidateEmptyText="true" ErrorMessage="<font size='2'>����д����0�����֣�</font>"> </asp:CustomValidator>
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
    <%--����������--%>
    <asp:Panel ID="PanelBody" runat="server" Style="width: 500px; display: none;" CssClass="modalPopup">
        <asp:UpdatePanel ID="MyUpdatePanelPanelDrag" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="PanelDrag" runat="server" CssClass="modalDragPopup">
                    <asp:LinkButton ID="lbClose" runat="server" Text="�ر�" OnClick="btnClose_Click" CausesValidation="false"></asp:LinkButton>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="MyUpdatePanelPanelBody" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnEditPic" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="30%" align="right">
                            ���� ��
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtProCode" runat="server" Width="200px"></asp:TextBox>
                            <asp:TextBox ID="txtProID" runat="server" Width="200px" Visible="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rvProCode" runat="server" ErrorMessage="���벻��Ϊ�գ�"
                                ControlToValidate="txtProCode"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            ���� ��
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:DropDownList ID="ddlProType" runat="server" DataTextField="ProTypeName" DataValueField="ProTypeID">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            ���� ��
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtProName" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvProName" runat="server" ErrorMessage="���Ʋ���Ϊ�գ�"
                                ControlToValidate="txtProName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            �ϴ�ͼƬ ��
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:Button ID="btnUploadPic" runat="server" Text="�ϴ�Сͼ" CssClass="buttonCss" CausesValidation="false" />
                            <ajaxToolkit:ModalPopupExtender ID="mpeUploadPic" runat="server" TargetControlID="btnUploadPic"
                                PopupControlID="PanelPicBody" BackgroundCssClass="modalBackground" DropShadow="true"
                                PopupDragHandleControlID="PanelPicDrag" Drag="true" CancelControlID="lbSClose">
                            </ajaxToolkit:ModalPopupExtender>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            ���� ��
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtProDes" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            �۸� ��
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtProPrice" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <%--<tr>
                        <td height="25" width="30%" align="right">
                            ¼������ ��
                        </td>
                        <td height="25" width="*" align="left">
                            <input type="text" id="txtProInputDate" runat="server" class="Wdate" style=" width:200px" onfocus="WdatePicker({startDate:'%y-%M-01 00:00:00',dateFmt:'yyyy-MM-dd HH:mm:ss',alwaysUseStartDate:true})" />
                        </td>
                    </tr>--%>
                    <tr>
                        <td height="25" width="30%" align="right">
                            �Ƿ��������� ��
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:RadioButtonList ID="rblPublish" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="��" Selected="True" Value="1"></asp:ListItem>
                                <asp:ListItem Text="��" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:CustomValidator ID="cvPublish" runat="server" ControlToValidate="rblPublish"
                                ClientValidationFunction="validateInput"></asp:CustomValidator>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            �������� ��
                        </td>
                        <td height="25" width="*" align="left">
                            <input type="text" id="txtProPublish" runat="server" class="Wdate" disabled="disabled"
                                style="width: 200px" onfocus="WdatePicker({minDate:'%y-%M-#{%d}'})" />
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            �Ƿ��Ƽ� ��
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:RadioButtonList ID="rblProRecommend" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="��" Value="1"></asp:ListItem>
                                <asp:ListItem Text="��" Value="2" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            �Ƿ����� ��
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:RadioButtonList ID="rblProIsNew" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="��" Selected="True" Value="1"></asp:ListItem>
                                <asp:ListItem Text="��" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" width="30%" align="right">
                            �Ƿ����� ��
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:RadioButtonList ID="rblProIsHot" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="��" Value="1"></asp:ListItem>
                                <asp:ListItem Text="��" Value="2" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnModify" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="MstGridView" EventName="RowCommand" />
            </Triggers>
        </asp:UpdatePanel>
        <div style="text-align: right;">
            <asp:Button ID="btnAddDetail" runat="server" Text="�����Ʒ��ϸ����" Width="150px" CssClass="buttonCss"
                CausesValidation="false" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnAddDetail"
                PopupControlID="PanelItemBody" BackgroundCssClass="modalBackground" DropShadow="true"
                PopupDragHandleControlID="PanelItemHead" Drag="true" CancelControlID="lbItemClose">
            </ajaxToolkit:ModalPopupExtender>
            &nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" Text="����" Width="65px" OnClick="btnSave_Click"
                CssClass="buttonCss" />
            &nbsp;&nbsp;
            <asp:Button ID="btnClose" runat="server" Text="�ر�" Width="65px" OnClick="btnClose_Click"
                CssClass="buttonCss" CausesValidation="false" />&nbsp;&nbsp;
        </div>
    </asp:Panel>
    <%--�����ϸ����--%>
    <asp:Panel ID="PanelItemBody" runat="server" Style="width: 700px; display: none;"
        CssClass="modalPopup">
        <asp:UpdatePanel ID="MyUpdatePanelItemDrag" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="PanelItemHead" runat="server" CssClass="modalDragPopup">
                    <asp:LinkButton ID="lbItemClose" runat="server" Text="�ر�" OnClick="btnClose_Click"
                        CausesValidation="false"></asp:LinkButton>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <iframe id="CarInfoInput" name="lmGog" border="0" marginwidth="0" marginheight="0"
                    src="<%=GetPamURL()%>" frameborder="0" width="700" scrolling="no" height="450"></iframe>
                <asp:HiddenField ID="hfPam" runat="server"></asp:HiddenField>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <%--�ϴ�Сͼ--%>
    <asp:Panel ID="PanelPicBody" runat="server" Style="width: 400px; display: none;"
        CssClass="modalPopup">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="PanelPicDrag" runat="server" CssClass="modalDragPopup">
                    <asp:LinkButton ID="lbSClose" runat="server" Text="�ر�" CausesValidation="false"></asp:LinkButton>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnEditPic" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <iframe id="CarPicInput" name="lmGog" border="0" marginwidth="0" marginheight="0"
                    src="<%=GetPamURL0()%>" frameborder="0" width="400" scrolling="no" height="50"></iframe>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <%--�༭ͼƬ--%>
    <%--<asp:Panel ID="PanelItemImageBody" runat="server" Style="width: 700px; display: none;"
        CssClass="modalPopup">
        <asp:UpdatePanel ID="MyUpdatePanelItemImageDrag" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="PanelItemImageHead" runat="server" CssClass="modalDragPopup">
                    <asp:LinkButton ID="lbItemImageClose" runat="server" Text="�ر�" OnClick="btnClose_Click"
                        CausesValidation="false"></asp:LinkButton>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="MstGridView" EventName="RowCommand" />
            </Triggers>
            <ContentTemplate>
                <iframe id="CarImageInput" name="lmGog" border="0" marginwidth="0" marginheight="0"
                    src='<%=GetImgURL()%>' frameborder="0" width="700" scrolling="no" height="350"></iframe>
                    <asp:HiddenField ID="hfImg" runat="server"></asp:HiddenField>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>--%>
    </fieldset>
</asp:Content>
