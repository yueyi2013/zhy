<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Main0.Master" AutoEventWireup="true" CodeBehind="wfBlog.aspx.cs" Inherits="Web.admin.site.blog.wfBlog" ValidateRequest="false"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <asp:UpdatePanel ID="MyUpdatePanelPanelBody" runat="server" UpdateMode="Conditional">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            </Triggers>
            <ContentTemplate>
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="25" width="60px" align="right">
                            文章标题：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtNewsTitle" runat="server" Width="98%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right">
                            作者：
                        </td>
                        <td height="25" width="*" align="left">
                            <asp:TextBox ID="txtNewsAuthor" runat="server" Width="100" Text="syihy.com"></asp:TextBox>
                            &nbsp;&nbsp;发布日期：<input type="text" id="txtPublishDate" runat="server" class="Wdate"
                                style="width: 100px" onfocus="WdatePicker({minDate:'%y-%M-#{%d}'})"/>
                            &nbsp;&nbsp;种类：<asp:DropDownList ID="ddlArticalCategory" runat="server" Width="120px" DataTextField="ACName" DataValueField="ACId">
                            </asp:DropDownList>
                            &nbsp;&nbsp;类型：<asp:DropDownList ID="ddlArticalType" runat="server" Width="60px" DataTextField="ATName" DataValueField="ATId">
                            </asp:DropDownList>
                            &nbsp;&nbsp;状态：<asp:RadioButtonList ID="rbStatus" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Text="生效" Value="A"></asp:ListItem>
                                <asp:ListItem Text="失效" Value="I"></asp:ListItem>
                            </asp:RadioButtonList>
                            
                        </td>
                    </tr>                    
                    <tr>
                        <td height="25" align="right">
                            内容： <asp:HiddenField ID="hfArId" runat="server" Value="0"/>
                        </td>
                        <td height="25" width="*" align="left">
                            <FTB:FreeTextBox id="ftContent" OnSaveClick="btnSave_Click" 
			                    Focus="true"
                                Language="zh-CN"
			                    SupportFolder="~/aspnet_client/FreeTextBox/"
			                    JavaScriptLocation="ExternalFile" 
			                    ButtonImagesLocation="ExternalFile"
			                    ToolbarImagesLocation="ExternalFile"
			                    ToolbarStyleConfiguration="Office2000"			
			                    toolbarlayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|SymbolsMenu,StylesMenu,InsertHtmlMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|InsertForm,InsertTextBox,InsertTextArea,InsertRadioButton,InsertCheckBox,InsertDropDownList,InsertButton|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell"
			                    runat="Server"
                                Width="99%"
			                    GutterBackColor="red"
			                    DesignModeCss="designmode.css"	
                                ImageGalleryPath="~/images/upload"
                                ImageGalleryUrl="../../../ftb.imagegallery.aspx?rif={0}&cif={0}"	 
			                />
                            <script type="text/javascript" src="../../../aspnet_client/FreeTextBox/FTB-Pro.js"></script>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div style="text-align: right;">
        <br />
            <asp:Button ID="btnSave" runat="server" Text="保存" Width="65px" OnClick="btnSave_Click"
                                    CssClass="buttonCss" OnClientClick="javascript:ClearZero()" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </div>
</asp:Content>
