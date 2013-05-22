<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarInput.aspx.cs" Inherits="Web.Member.CarInput" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset>
    <legend>参数录入</legend>
        <asp:Table ID="tabCarInput" runat="server" CellPadding="0" CellSpacing="0" Width="100%">
        </asp:Table>
    </fieldset>
    <fieldset>
    <legend>图片上传</legend>
        <table cellpadding="0" cellspacing="0" width="100%" >
            <tr>
                <td align="right">
                    图片一：
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td align="right">
                    图片二：
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    图片三：
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload3" runat="server" />
                </td>
                <td align="right">
                    图片四：
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload4" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right">
                    图片五：
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload5" runat="server" />
                </td>
                <td align="right">
                    图片六：
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload6" runat="server" />
                </td>
            </tr>
           
            <tr>
                <td height="50px">
                </td>
                <td align="right">
                    <asp:Button ID="btnSave" runat="server" Text="保存" Width="65px" OnClick="btnSave_Click"
                        CssClass="buttonCss" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnClose" runat="server" Text="关闭" Width="65px" OnClick="btnClose_Click"
                        CssClass="buttonCss" CausesValidation="false" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        </fieldset>
    </form>
</body>
</html>
