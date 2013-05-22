<%@ Page Title="" Language="C#" MasterPageFile="~/Index0.Master" AutoEventWireup="true"
    CodeBehind="CarInfoList.aspx.cs" Inherits="ZHY.Web.Member.CarInfoList" %>

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
                    <legend>信息查询</legend>
                    <table cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="汽车名称："></asp:Label>
                                <asp:TextBox ID="txtCarName" runat="server" Width="200px"></asp:TextBox>
                                <asp:Button
                                    ID="btnSearch" runat="server" Text="查询" onclick="btnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="MstGridView" runat="server" AutoGenerateColumns="False" Width="99%">
                                    <Columns>
                                        <asp:BoundField DataField="ProStatus" HeaderText="信息状态" />
                                        <asp:BoundField DataField="ProName" HeaderText="汽车名称" />
                                        <asp:BoundField DataField="ProCode" HeaderText="编号" />
                                        <asp:BoundField HeaderText="品牌型号" />
                                        <asp:BoundField HeaderText="上牌时间" />
                                        <asp:BoundField HeaderText="交易报价" />
                                        <asp:BoundField HeaderText="车体颜色" />
                                        <asp:BoundField HeaderText="车籍地区" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
