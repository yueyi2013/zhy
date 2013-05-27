<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main0.Master" AutoEventWireup="true" CodeBehind="wfCollectNews.aspx.cs" Inherits="Web.admin.site.news.wfCollectNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


<div>
        <div>
            请输入新闻链接:<asp:TextBox ID="txtUrl" runat="server" Height="22px" Width="272px"></asp:TextBox>
            <asp:Button ID="btnCollectNews" runat="server" CssClass="buttonCss"   
                Text="采集新闻" onclick="btnCollectNews_Click" />  &nbsp;&nbsp;&nbsp;
        </div>
        <div><h1><asp:Label ID="txtTitle" runat="server" Text=""></asp:Label></h1></div>
        <div>
            <table>
                <tr>
                    <td style="width:33%; text-align:center"><asp:Label ID="txtDate" runat="server" Text=""></asp:Label></td>
                    <td style="width:33%; text-align:center"><asp:Label ID="txtSource" runat="server" Text=""></asp:Label></td>
                    <td style="width:33%; text-align:center"><asp:Label ID="txtAuthor" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
        </div>
        <div><asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="100%">
            </asp:Panel>
        </div>
    </div>
</asp:Content>
