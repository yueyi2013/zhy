<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="membercenter.aspx.cs" Inherits="Web.forum.membercenter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="left" valign="top" style="width:200px">
            <h5>全部分类</h5>
            <asp:BulletedList ID="blNav" runat="server" DataTextField="MMName" 
                DataValueField="MMId" DisplayMode="LinkButton" onclick="blNav_Click">
            </asp:BulletedList>
        </td>
        <td align="left" valign="top">
            <asp:UpdatePanel ID="MyUpdatePanelBody" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="blNav" EventName="Click" />
                </Triggers>
                <ContentTemplate>
                   <div id="divPsnInfo">
                       <table>
                            <tr>
                                <td>当前头像：</td>
                                <td> <asp:Image ID="imgPsnPhoto" runat="server"/></td>
                            </tr>
                            <tr>
                                <td>账号：</td>
                                <td><asp:Label ID="lblAccount" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>昵称：</td>
                                <td><asp:TextBox ID="txtPsnNickName" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>等级：</td>
                                <td><asp:Label ID="lblLevel" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>验证邮箱：</td>                                
                                <td><asp:Label ID="lblMemMail" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>状态：</td>
                                <td><asp:Label ID="lblMemStatus" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:LinkButton ID="lbSave" runat="server" Text="保存"></asp:LinkButton></td>
                            </tr>                            
                        </table>
                   </div>

                   
                </ContentTemplate>                
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
</asp:Content>
