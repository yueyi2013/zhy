<%@ Page Title="" Language="C#" MasterPageFile="~/Index0.Master" AutoEventWireup="true"
    CodeBehind="CarPublish.aspx.cs" Inherits="ZHY.Web.Member.CarPublish" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphCarInfo" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style="width: 150px" align="left" valign="top">
                &nbsp;
                <asp:Menu ID="MenuLeft" runat="server" BackColor="#FFFBD6" DynamicHorizontalOffset="2"
                    Font-Names="Verdana" Font-Size="Larger" ForeColor="#990000" Height="107px" StaticSubMenuIndent="10px"
                    Width="146px" Font-Bold="True">
                    <StaticSelectedStyle BackColor="#FFCC66" />
                    <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <DynamicHoverStyle BackColor="#990000" ForeColor="White" />
                    <DynamicMenuStyle BackColor="#FFFBD6" />
                    <DynamicSelectedStyle BackColor="#FFCC66" />
                    <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                    <StaticHoverStyle BackColor="#990000" ForeColor="White" />
                    <Items>
                        <asp:MenuItem Text="发布信息" Value="发布信息"></asp:MenuItem>
                        <asp:MenuItem Text="信息查询" Value="信息查询"></asp:MenuItem>
                        <asp:MenuItem Text="修改密码" Value="修改密码"></asp:MenuItem>
                        <asp:MenuItem Text="个人信息" Value="个人信息"></asp:MenuItem>
                    </Items>
                </asp:Menu>
            </td>
            <td align="left" valign="top">
                <fieldset>
                    <legend>发布信息</legend>                    
                    <iframe id="CarInfoInput" name="lmGog" border="0" marginwidth="0" marginheight="0" src='<%=GetURL()%>'
                        frameborder="0" width="600" scrolling="no" height="400"></iframe>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
