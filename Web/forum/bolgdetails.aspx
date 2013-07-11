<%@ Page Title="" Language="C#" MasterPageFile="~/template/syihy_1/tmpl.Master" AutoEventWireup="true" CodeBehind="bolgdetails.aspx.cs" Inherits="Web.forum.bolgdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td style="width:200px; text-align:left; vertical-align:top">
            
        </td>
        <td>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <asp:Label ID="lblTitle" runat="server" Font-Size="X-Large" Font-Bold="true"></asp:Label>
                    </td>                    
                </tr>
                <tr>
                    <td>
                        <div id="divBlog" runat="server"/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />分享到腾讯微博：
                        <div id="divTXWB" runat="server">
                            
                        </div>
                        <br />
                        分享到新浪微博：
                        <div id="divXLWB" runat="server">
    
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                       <table>
                            <tr>
                                <td>用户名：</td>
                                <td>
                                    <asp:Label ID="lblUser" runat="server" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>评论：</td>
                                <td>
                                    <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Width="300px" Height="100px"></asp:TextBox>                                
                                </td>
                            </tr>
                       </table>
                    </td>
                </tr>
            </table>
                  
        </td>
    </tr>
</table>
</asp:Content>
