<%@ Page Title="" Language="C#" MasterPageFile="~/Index0.Master" AutoEventWireup="true"
    CodeBehind="ProPublish.aspx.cs" Inherits="ZHY.Web.ProPublish" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphCarInfo" runat="server">
                 <fieldset>
                    <legend>发布信息</legend>                    
                   <iframe id="CarInfoInput" name="lmGog" border="0" marginwidth="0" marginheight="0" src='<%=GetURL()%>'
                                        frameborder="0" width="900" scrolling="no" height="500"></iframe>
                </fieldset>
</asp:Content>
