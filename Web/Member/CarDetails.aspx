<%@ Page Title="" Language="C#" MasterPageFile="~/Index0.Master" AutoEventWireup="true"
    CodeBehind="CarDetails.aspx.cs" Inherits="Web.Member.CarDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../js/jquery.min.js" type="text/javascript"></script>

    <script language="javascript">

        $(document).ready(function() {
            $("#gallery_output img").not(":first").hide();
            $("#word_output table").not(":first").hide();
            $("#gallery a").click(function() {
                if ($("#" + this.rel).is(":hidden")) {
                    $("#gallery_output img").slideUp();
                    $("#" + this.rel).slideDown();
                }

                //                if ($("#" + this.rel0).is(":hidden")) {
                //                    $("#word_output table").slideUp();
                //                    $("#" + this.rel0).slideDown();
                //                }
            });
        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphCarInfo" runat="server">
    <div id="content">
        <div id="gallery">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <div id="gallery_output">
                            <%--<img id="img1" src="../upload/product/iphone_1b.jpg" />
                            <img id="img2" src="../upload/product/iphone_2b.jpg" />
                            <img id="img3" src="../upload/product/iphone_3b.jpg" />
                            <img id="img4" src="../upload/product/iphone_4b.jpg" />--%>
                            <%=sbBig.ToString()%>
                        </div>
                        <div id="word_output">
                            <asp:DataList ID="dlPam" runat="server">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("DtName") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" Text='<%#Eval("ProDtValue") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="gallery_nav">
                            <table>
                                <tr>
                                   <%-- <td>
                                        <a rel="img1" href="javascript:;">
                                            <img src="../upload/product/iphone_1.jpg" /></a>
                                    </td>
                                    <td>
                                        <a rel="img2" href="javascript:;">
                                            <img src="../upload/product/iphone_2.jpg" /></a>
                                    </td>
                                    <td>
                                        <a rel="img3" href="javascript:;">
                                            <img src="../upload/product/iphone_3.jpg" /></a>
                                    </td>
                                    <td>
                                        <a rel="img4" href="javascript:;">
                                            <img src="../upload/product/iphone_4.jpg" /></a>
                                    </td>--%>
                                    <%=sbSml.ToString()%>
                                </tr>
                            </table>
                            
                        </div>
                    </td>
                </tr>
            </table>
            <div class="clear">
            </div>
        </div>
    </div>
</asp:Content>
