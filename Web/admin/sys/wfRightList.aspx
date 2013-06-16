<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main0.Master" AutoEventWireup="true" CodeBehind="wfRightList.aspx.cs" Inherits="Web.admin.sys.wfRightList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<fieldset style="width: 800px">
    <legend>权限列表</legend>
    <table>
    <tr>
    <td>
    角色列表：
    <div id="divRoleList">
        <asp:RadioButtonList ID="rbRoleList" runat="server" DataValueField="RoleID" 
            DataTextField="RoleName" RepeatColumns="10" RepeatDirection="Horizontal" 
            onselectedindexchanged="rbRoleList_SelectedIndexChanged" 
            AutoPostBack="True">
        </asp:RadioButtonList>        
    </div>
    <hr />
    </td>
    </tr>
    <tr>
    <td>
    功能列表：<input id="btnSelectAll" style="cursor: hand" onclick="GetAllCheckBox0(ctl00_ContentPlaceHolder1_btnSelectAll)" type="checkbox" runat="server" />全选
    <div id="divFunList">
        <asp:UpdatePanel ID="MyUpdatePanelBody" runat="server" UpdateMode="Conditional">
            <Triggers>                  
                <asp:AsyncPostBackTrigger ControlID="rbRoleList" EventName="SelectedIndexChanged" />
            </Triggers>
            <ContentTemplate>
                <asp:CheckBoxList ID="chkFunlist" runat="server" DataValueField="FunID" DataTextField="FunName" RepeatColumns="10" RepeatDirection="Horizontal">
                </asp:CheckBoxList>
                <asp:HiddenField ID="hfRoleId" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <hr />
    <asp:Button ID="btnSave" runat="server" Text="保存" Width="65px" OnClick="btnSave_Click"
                CssClass="buttonCss"/>
    </td>
    </tr>
    </table>
</fieldset>




</asp:Content>
