<%@ Page Title="" Language="C#" MasterPageFile="~/Index0.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ZHY.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphCarInfo" runat="server">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <fieldset>
                    <legend>查询条件</legend>
                <asp:Label ID="Label5" runat="server" Text="类别："></asp:Label>
                <asp:DropDownList ID="ddlTypeList" runat="server">
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label6" runat="server" Text="品牌："></asp:Label>
                <asp:TextBox ID="txtBrand" runat="server" Width="100px"> </asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label7" runat="server" Text="报价："></asp:Label>
                <asp:DropDownList ID="ddlPrice" runat="server">
                    <asp:ListItem Text="请选择" Value="0"></asp:ListItem>
                    <asp:ListItem Text="10万以下" Value="10"></asp:ListItem>
                    <asp:ListItem Text="10万至30万" Value="10,30"></asp:ListItem>
                    <asp:ListItem Text="30万至50万" Value="30,50"></asp:ListItem>
                    <asp:ListItem Text="50万至70万" Value="50,70"></asp:ListItem>
                    <asp:ListItem Text="70万至90万" Value="70,90"></asp:ListItem>
                    <asp:ListItem Text="90万以上" Value="90"></asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label8" runat="server" Text="年份："></asp:Label>
                <input type="text" id="txtYearF" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy年'})"
                    class="Wdate" style="width: 90px" />至
                <input type="text" id="txtYearT" onfocus="WdatePicker({skin:'whyGreen',dateFmt:'yyyy年'})"
                    class="Wdate" style="width: 90px" />
                &nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="查询" OnClick="btnSearch_Click" />
                </fieldset>
            </td>
        </tr>
        <tr>
            <td align="center" valign="top">
                <fieldset>
               <legend>汽车展示</legend>
                <asp:UpdatePanel ID="MyUpdatePanelHead" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:DataList ID="dlCarList" runat="server" RepeatColumns="6" RepeatDirection="Horizontal" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"
                            Width="100%">
                            <ItemTemplate>
                                <table align="left" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td align="center">
                                        <a href='/Member/CarDetails.aspx?proID = <%# Eval("ProID") %>' target="_blank">
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# GetPicURL(Eval("ProPicURL").ToString())%>' Height="100" Width="140"/>
                                            </a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                             <a href='/Member/CarDetails.aspx?proID = <%# Eval("ProID") %>' target="_blank" ><%# Eval("ProName") %></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="Label4" runat="server" Text="报价:" ForeColor="Red"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProPrice") %>'></asp:Label>
                                            <asp:Label ID="Label9" runat="server" Text="万元" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                            </ItemTemplate>
                        </asp:DataList>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>推荐车型</legend>
                    <asp:DataList ID="dlCarList0" runat="server" 
                        RepeatColumns="5" RepeatDirection="Horizontal" Width="100%" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                        <ItemTemplate>
                            <table align="left" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="center">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="upload/product/2010_02/12205836788721.jpg"/>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                          <a href='/Member/CarDetails.aspx?proID = <%# Eval("ProID") %>' ><%# Eval("ProName") %></a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Label ID="Label4" runat="server" Text="报价:" ForeColor="Red"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProPrice") %>'></asp:Label>
                                            <asp:Label ID="Label9" runat="server" Text="万元" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
