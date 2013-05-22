<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true" CodeBehind="wfNavigation.aspx.cs" Inherits="Web.admin.site.homepage.wfNavigation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <fieldset style="width: 585px">
    <legend>首页导航栏</legend>
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
                                    栏目类型：
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlMenuType" runat="server">
                                        <asp:ListItem Text="一级菜单" Value="0" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="二级菜单" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                             <tr>
                                <td align="right" style="width: 80px">
                                    栏目名称：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMenuName" runat="server" Width="200px"></asp:TextBox>
                                    <asp:TextBox ID="txtMenuID" runat="server" Width="200px" Visible="false"></asp:TextBox>
                                    <asp:TextBox ID="txtParantID" runat="server" Width="200px" Visible="false" Text="0"></asp:TextBox>
                                </td>
                            </tr>                          
                            <tr>
                                <td align="right">
                                    排序：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMenuOrder" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    链接：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMenuPicPath" runat="server" Width="200px" Text="Menu023.gif"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    栏目描述：
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
                                        CausesValidation="false" onclick="btnAdd_Click"
                                     />&nbsp;&nbsp;
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
