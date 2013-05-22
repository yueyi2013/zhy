<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfCarInput.aspx.cs" Inherits="ZHY.Web.admin.wfCarInput" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <fieldset>
    <legend>参数录入</legend>
    <table>
        <tr>
            <td>
                <asp:Table ID="tabCarInput" runat="server" CellPadding="0" CellSpacing="0" Width="100%">
                </asp:Table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnSave" runat="server" Text="保存" Width="65px" CssClass="buttonCss" />
            </td>
        </tr>
    </table>
    </fieldset>
    <fieldset>
    <legend>图片上传</legend>
    <div>
    
        <iframe id="CarPicInput" name="lmGog" border="0" marginwidth="0" marginheight="0"
            src='<%=GetPamURL()%>' frameborder="0" width="700" scrolling="no" height="200"></iframe>
        <asp:HiddenField ID="hfProTypeID" runat="server" />
    </div>
     </fieldset>
    </form>
</body>
</html>
