<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true"
    CodeBehind="wfMenu0List.aspx.cs" Inherits="ZHY.Web.admin.wfMenu0List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <fieldset style="width: 585px">
    <legend>菜单管理</legend>
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
        <tr align="left" valign="top">
            <td align="left" valign="top" width="150px">
                <asp:TreeView ID="tvMenu" runat="server" OnSelectedNodeChanged="tvMenu_OnSelectedNodeChanged">
                </asp:TreeView>
            </td>
            <td align="left" valign="top">
                <asp:UpdatePanel ID="upMenu" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="tvMenu" EventName="SelectedNodeChanged" />
                    </Triggers>
                    <ContentTemplate>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td align="right" style="width: 80px">
                                    菜单类型：
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlMenuType" runat="server">
                                        <asp:ListItem Text="一级菜单" Value="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="二级菜单" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                             <%--<tr>
                                <td align="right">
                                    一级菜单：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtParantID" runat="server" Width="200px" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="txtParantName" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 80px">
                                    二级菜单：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtChildMenu" runat="server" Width="200px" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="txtChildMenuID" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>--%>
                             <tr>
                                <td align="right" style="width: 80px">
                                    菜单名称：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMenuName" runat="server" Width="200px"></asp:TextBox>
                                    <asp:TextBox ID="txtMenuID" runat="server" Width="200px" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="txtParantID" runat="server" Width="200px" Visible="false" Text="0"></asp:TextBox>
                                </td>
                            </tr>                          
                            <tr>
                                <td align="right">
                                    菜单排序：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMenuOrder" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    图标路径：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMenuPicPath" runat="server" Width="200px" Text="Menu023.gif"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    功能列表：
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlFun" runat="server" DataTextField="FunName" DataValueField="FunID">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    菜单描述：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMenuDes" runat="server" Width="200px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hfOp" runat="server" Value="0" />
                                    <asp:Button ID="btnAdd" runat="server" Text="新增" CssClass="buttonCss" 
                                        CausesValidation="false" onclick="btnAdd_Click"/>&nbsp;&nbsp;
                                    <asp:Button ID="btnModify" runat="server" Text="保存" CssClass="buttonCss" CausesValidation="false"
                                        OnClick="btnModify_Click" />&nbsp;&nbsp;
                                    <asp:Button ID="btnDelete" runat="server" Text="删除" OnClientClick="return Confirm()"
                                        CssClass="buttonCss" CausesValidation="false" OnClick="btnDelete_Click" />
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
