<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true"
    CodeBehind="wfRoleList.aspx.cs" Inherits="ZHY.Web.admin.wfRoleList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style="width: 585px">
    <legend>角色管理</legend>
    <table cellspacing="0" cellpadding="0" width="100%" >
        <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="增加" CssClass="buttonCss" CausesValidation="false"
                    OnClick="btnAdd_Click" />
                <asp:Button ID="btnModify" runat="server" Text="保存" CssClass="buttonCss" CausesValidation="false"
                    OnClick="btnSave_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="批量删除" OnClientClick="return Confirm()"
                    CssClass="buttonCss" CausesValidation="false" OnClick="btnDelete_Click" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td align="left" valign="top" width="350px">
                <asp:UpdatePanel ID="MyUpdatePanelBody" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnModify" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:GridView ID="MstGridView" runat="server" AutoGenerateColumns="False" 
                            AllowPaging="false" DataKeyNames="RoleID" OnRowCommand="MstGridView_RowCommand"
                            HeaderStyle-HorizontalAlign="Center">
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
                                <asp:BoundField DataField="RoleName" HeaderText="角色名称">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RoleDes" HeaderText="角色描述">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="hfFunID" runat="server" Value="0" />
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
                            ControlToValidate="txtPageIndex0" Display="none" ValidateEmptyText="true" ErrorMessage="<font size='2'>请填写大于0的数字！</font>"> </asp:CustomValidator>
                        <ajaxToolkit:ValidatorCalloutExtender ID="vceGo" runat="server" TargetControlID="cvGo"
                            HighlightCssClass="validatorCalloutHighlight">
                        </ajaxToolkit:ValidatorCalloutExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td align="left" valign="top">
                <asp:UpdatePanel ID="MyUpdatePanelRole" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnModify" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <table cellspacing="0" cellpadding="0" border="0">
                            <tr>
                                <td align="right">
                                    角色名称：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRoleName" runat="server" Width="150px"></asp:TextBox>
                                    <asp:TextBox ID="txtRoleID" runat="server" Width="150px" Visible="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    角色描述：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtRoleDes" runat="server" Width="150px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    </fieldset>
</asp:Content>
