<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main.Master" AutoEventWireup="true"
    CodeBehind="wfImageEdit.aspx.cs" Inherits="ZHY.Web.admin.wfImageEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="" language="javascript">

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" width="700px">
        <tr>
            <td colspan="2" align=center>
            小图
            </td>
            <td colspan="2" align=center>
            大图
            </td>
        </tr>
        <tr>
            <td align="right">
                图片一：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <%--<asp:Image ID="Image1" runat="server" /><asp:LinkButton ID="LinkButton1" runat="server"
                    Text="删除"></asp:LinkButton>--%>
            </td>
            <td align="right">
                图片一：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <%-- <asp:Image ID="Image2" runat="server" /><asp:LinkButton ID="LinkButton2" runat="server"
                    Text="删除"></asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td align="right">
                图片二：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload3" runat="server" /><%--
                <asp:Image ID="Image3" runat="server" /><asp:LinkButton ID="LinkButton3" runat="server"
                    Text="删除"></asp:LinkButton>--%>
            </td>
            <td align="right">
                图片二：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload4" runat="server" />
                <%--<asp:Image ID="Image4" runat="server" /><asp:LinkButton ID="LinkButton4" runat="server"
                    Text="删除"></asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td align="right">
                图片三：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload5" runat="server" />
                <%--<asp:Image ID="Image5" runat="server" /><asp:LinkButton ID="LinkButton5" runat="server"
                    Text="删除"></asp:LinkButton>--%>
            </td>
            <td align="right">
                图片三：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload6" runat="server" />
                <%--<asp:Image ID="Image6" runat="server" /><asp:LinkButton ID="LinkButton6" runat="server"
                    Text="删除"></asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td align="right">
                图片四：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload7" runat="server" />
                <%--<asp:Image ID="Image7" runat="server" /><asp:LinkButton ID="LinkButton7" runat="server"
                    Text="删除"></asp:LinkButton>--%>
            </td>
            <td align="right">
                图片四：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload8" runat="server" />
                <%--<asp:Image ID="Image8" runat="server" /><asp:LinkButton ID="LinkButton8" runat="server"
                    Text="删除"></asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td align="right">
                图片五：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload9" runat="server" />
                <%--<asp:Image ID="Image9" runat="server" /><asp:LinkButton ID="LinkButton9" runat="server"
                    Text="删除"></asp:LinkButton>--%>
            </td>
            <td align="right">
                图片五：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload10" runat="server" />
                <%--<asp:Image ID="Image10" runat="server" /><asp:LinkButton ID="LinkButton10" runat="server"
                    Text="删除"></asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td align="right">
                图片六：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload11" runat="server" />
                <%--<asp:Image ID="Image11" runat="server" /><asp:LinkButton ID="LinkButton11" runat="server"
                    Text="删除"></asp:LinkButton>--%>
            </td>
            <td align="right">
                图片六：
            </td>
            <td>
                <asp:FileUpload ID="FileUpload12" runat="server" />
                <%--<asp:Image ID="Image12" runat="server" /><asp:LinkButton ID="LinkButton12" runat="server"
                    Text="删除"></asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td align="right">
                <asp:Button ID="btnSave" runat="server" Text="开始批量上传图片" Width="150px" OnClick="btnSave_Click"
                    CssClass="buttonCss" Height="24px" />
                &nbsp;&nbsp;
            </td>
            <td>
                <asp:HiddenField ID="HiddenField1" runat="server" Value=""></asp:HiddenField>
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
