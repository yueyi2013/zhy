<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="membercenter.aspx.cs" Inherits="Web.forum.membercenter" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
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
                   <div id="divPsnInfo" runat="server">
                       <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="25" width="100px" align="left">账号：</td>
                                <td><asp:Label ID="lblAccount" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left">等级：</td>
                                <td><asp:Label ID="lblLevel" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left">验证邮箱：</td>                                
                                <td><asp:Label ID="lblMemMail" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left">状态：</td>
                                <td><asp:Label ID="lblMemStatus" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td><asp:LinkButton ID="lbSaveMem" runat="server" Text="保存"></asp:LinkButton></td>
                            </tr>                            
                        </table>
                   </div>

                   <div id="divArtical" runat="server" >
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>标题：</td>
                                <td>
                                    <asp:DropDownList ID="ddlType" runat="server"/>
                                <asp:TextBox ID="txtArticalTitle" runat="server" Width="500"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>分类：</td>
                                <td>
                                <asp:DropDownList ID="ddlCategory" runat="server">
                                </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>内容：</td>
                                <td align="left" valign="top">
                                   
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Button ID="btnSaveArtical" runat="server" Text="保存" /></td>
                            </tr>
                        </table>
                   </div>

                   <div id="divArticalCat" runat="server">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr><td>
                            <asp:GridView ID="gvArticalCat" runat="server" AutoGenerateColumns="False"  AllowPaging="false" DataKeyNames="ACId">
                            <Columns>
                                <asp:BoundField DataField="MMName" HeaderText="分类名">
                                    <ItemStyle Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MMName" HeaderText="描述">
                                    <ItemStyle Width="200px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="删除">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnDelete" runat="server" CommandName="branchDelete" ImageUrl="~/images/delete.gif"
                                        Width="15px" Height="11px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            </asp:GridView>
                            </td></tr>
                            <tr><td><asp:TextBox ID="txtArCat" runat="server"></asp:TextBox></td></tr>
                            <tr><td><asp:TextBox ID="txtArCatDesc" runat="server" TextMode="MultiLine"></asp:TextBox></td></tr>
                            <tr><td> <asp:Button ID="btnSaveCat" runat="server" Text="保存" /></td></tr>
                        </table>
                   </div>

                   <div id="divComment">
                        
                   </div>


                </ContentTemplate>                
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
</asp:Content>
