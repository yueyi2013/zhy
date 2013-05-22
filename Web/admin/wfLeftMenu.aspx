<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfLeftMenu.aspx.cs" Inherits="ZHY.Web.admin.wfLeftMenu" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <%--<link href="../css/manage.css" rel="stylesheet" type="text/css" />--%>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-left: 0px; margin-top: 0px; background-image:url('../images/bg_02.gif'); background-repeat:repeat-y">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="upMenu" runat="server">
            <ContentTemplate>
                <asp:Accordion ID="adMenu" runat="server" Height="500px" AutoSize="fill" HeaderCssClass="headerBg" ContentCssClass="contentBg">
                </asp:Accordion>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
