<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true"
    CodeBehind="wfMenuList.aspx.cs" Inherits="ZHY.Web.admin.wfMenuList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="MyUpdatePanelHead" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text="名称:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server" Width="300px"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="查询" CausesValidation="false" OnClick="btnSearch_Click"
                CssClass="buttonCss" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <table cellspacing="0" cellpadding="0" border="0">
        <tr align="left" valign="top">
            <td style="width: 290px">
                <fieldset>
                        <legend>父菜单</legend>
                <asp:UpdatePanel ID="upParantMenuList" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlParantMenu" runat="server" DataTextField="MenuName" 
                            DataValueField="MenuID" 
                            onselectedindexchanged="ddlParantMenu_SelectedIndexChanged"></asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="MstGridView" EventName="SelectedIndexChanged" />
                    </Triggers>
                    <ContentTemplate>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td width="80" align="right">
                                    父菜单名称：<asp:HiddenField ID="hfMenuID" runat="server" Value="0" />
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMenuName" runat="server" Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style2">
                                    排序：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtOrder0" runat="server" Width="40px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    菜单描述：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMenuDes0" runat="server" Width="200px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="left">
                                    <asp:Button ID="btnSave" runat="server" Text="保存父菜单" Width="65px" OnClick="btnSave_Click"
                                        CssClass="buttonCss" />
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </fieldset>
            </td>
            <td align="left" valign="top">
                <fieldset>
                <legend>子菜单</legend>
                <table cellspacing="0" cellpadding="0"  border="0" >
                <tr>
                <td align="left" valign="top"><asp:UpdatePanel ID="upChildMenuList" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSaveChild" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="ddlParantMenu" EventName="SelectedIndexChanged" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:GridView ID="ItemGridView" runat="server" AutoGenerateColumns="False" Width="500px"
                            AllowPaging="false" DataKeyNames="MenuID" OnRowCommand="MstGridView_RowCommand"
                            HeaderStyle-HorizontalAlign="Center">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderStyle Width="30px" HorizontalAlign="Center" />
                                    <ItemStyle Width="30px" HorizontalAlign="Center" />
                                    <HeaderTemplate>
                                        <input id="btnSelectAll" style="cursor: hand" onclick="GetAllCheckBox(ctl00_ContentPlaceHolder1_MstGridView_ctl01_btnSelectAll)"
                                            type="checkbox" runat="server" /></HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkItem" runat="server" onclick="changecolor(this)" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="MenuOrder" HeaderText="序号">
                                    <ItemStyle Width="30px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MenuName" HeaderText="菜单名称">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MenuPicPath" HeaderText="功能名">
                                    <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MenuDes" HeaderText="菜单描述">
                                    <ItemStyle Width="200px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
                <td><asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="MstGridView" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ItemGridView" EventName="SelectedIndexChanged" />
                    </Triggers>
                    <ContentTemplate>
                        <table cellspacing="0" cellpadding="0" border="0">
                            <tr>
                                <td align="right" style="width: 80px">
                                    子菜单名称：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtChildMenu" runat="server"  Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr>
                                <td align="right">
                                    父菜单：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtParantID" runat="server" Width="100px"></asp:TextBox>
                                </td>
                            </tr>--%>
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
                                    图标：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtMenuPicPath" runat="server" Width="100px"></asp:TextBox>
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
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnSaveChild" runat="server" Text="保存子菜单" Width="65px" OnClick="btnChildSave_Click"
                                        CssClass="buttonCss"/>&nbsp;&nbsp;
                                        <asp:Button ID="btnDelete" runat="server" Text="批量删除" OnClientClick="return Confirm()"
                                CssClass="buttonCss" CausesValidation="false"/>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel></td>
                </tr>
                </table>
                </fieldset>
            </td>
        </tr>
    </table>    
</asp:Content>
