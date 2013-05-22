<%@ Page Title="" Language="C#" MasterPageFile="~/Index0.Master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="Web.Member.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!--加载jQuery类库-->

    <script src="../js/jquery_last.js" type="text/javascript"></script>

    <!--加载插件的样式库，如果你是自动构建提示层，请加载validatorAuto.css-->
    <link type="text/css" rel="stylesheet" href="../css/validator.css" />
    <!--加载插件-->

    <script src="../js/formValidator.js" type="text/javascript"></script>

    <!--加载扩展库-->

    <script src="../js/formValidatorRegex.js" type="text/javascript"></script>

    <%--<!--表单验证-->
<script src="../js/register.js" type="text/javascript"></script>
--%>

    <script type="text/javascript">
$(document).ready(function(){
	
	$.formValidator.initConfig({formid:"aspnetForm",onerror:function(msg){alert(msg)},onsuccess:function(){alert('ddd');return false;}});
	$("#ctl00_cphCarInfo_txtMemAccount").formValidator({onshow:"请输入用户名",onfocus:"用户名至少6个字符,最多10个字符",oncorrect:"该用户名可以注册"}).inputValidator({min:6,max:10,onerror:"你输入的用户名非法,请确认"}).regexValidator({regexp:"username",datatype:"enum",onerror:"用户名格式不正确"})
	    .ajaxValidator({
	    type : "get",
		url : "Register.aspx",
		datatype : "json",
		success : function(data){	
            if( data == "1" )
			{
                return true;
			}
            else
			{
                return false;
			}
		},
		buttons: $("#button"),
		error: function(){alert("服务器没有返回数据，可能服务器忙，请重试");},
		onerror : "该用户名不可用，请更换用户名",
		onwait : "正在对用户名进行合法性校验，请稍候..."
	});
	
	$("#ctl00_cphCarInfo_txtMemPsw").formValidator({onshow:"请输入密码",onfocus:"密码不能为空",oncorrect:"密码合法"}).inputValidator({min:1,empty:{leftempty:false,rightempty:false,emptyerror:"密码两边不能有空符号"},onerror:"密码不能为空,请确认"});
	
	$("#ctl00_cphCarInfo_txtMemPsw1").formValidator({onshow:"请输入重复密码",onfocus:"两次密码必须一致哦",oncorrect:"密码一致"}).inputValidator({min:1,empty:{leftempty:false,rightempty:false,emptyerror:"重复密码两边不能有空符号"},onerror:"重复密码不能为空,请确认"}).compareValidator({desid:"password1",operateor:"=",onerror:"2次密码不一致,请确认"});
    
    $("#ctl00_cphCarInfo_txtMemMedium").formValidator({empty:true,onshow:"这里需要输入中介名称",onfocus:"请填写中介名称",oncorrect:"中介名称已填写",onempty:"中介名称为空"});
    
	$("#ctl00_cphCarInfo_txtMemMobile").formValidator({empty:true,onshow:"请输入你的手机号码，可以为空哦",onfocus:"你要是输入了，必须输入正确",oncorrect:"谢谢你的合作",onempty:"你真的不想留手机号码啊？"}).inputValidator({min:11,max:11,onerror:"手机号码必须是11位的,请确认"}).regexValidator({regexp:"mobile",datatype:"enum",onerror:"你输入的手机号码格式不正确"});;

    $("#ctl00_cphCarInfo_txtMemRealName").formValidator({onshow:"为确保您的中奖利益，请如实填写您的真实姓名，注册后不可修改。",onfocus:"请填写您的真实姓名",oncorrect:"真实姓名已填写"})
		.inputValidator({min:1,max:8,empty:{leftempty:false,rightempty:false,emptyerror:"您填入了空符号"},onerror:"您的真实姓名可能输入错误,请核对"})
		.regexValidator({regexp:"^[a-zA-Z\u4e00-\u9fa5]+$",onerror:"您的真实姓名可能输入错误,请核对"});
	
    $("#ctl00_cphCarInfo_txtMemShotNum").formValidator({empty:true,onshow:"请输入工作虚拟号，可以为空哦",onfocus:"你要是输入了，必须输入正确",oncorrect:"谢谢你的合作",onempty:"没有输入工作虚拟号？"}).inputValidator({min:11,max:11,onerror:"手机号码必须是11位的,请确认"});

	
	$("#ctl00_cphCarInfo_txtMemUnitTelArea").formValidator({onshow:"请输入地区区号",onfocus:"地区区号3位或4位数字",oncorrect:"恭喜你,你输对了"}).regexValidator({regexp:"^\\d{3,4}$",onerror:"地区区号不正确"});
	
	$("#ctl00_cphCarInfo_txtMemUnitTel").formValidator({onshow:"请输入电话号码",onfocus:"电话号码7到8位数字",oncorrect:"恭喜你,你输对了"}).regexValidator({regexp:"^\\d{7,8}$",onerror:"电话号码不正确"});
	
});
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphCarInfo" runat="server">
    <asp:UpdatePanel ID="upRegister" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <fieldset>
                <legend>会员注册</legend>
                <table align="center" cellpadding="5" cellspacing="5" width="100%">
                    <thead>
                        <tr>
                            <td align="right">
                                <img alt="会员注册" src="../images/Member/member_reg.gif" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td align="right">
                                会员帐号：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemAccount" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <div id="ctl00_cphCarInfo_txtMemAccountTip" style="width: 400px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                密码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemPsw" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <div id="ctl00_cphCarInfo_txtMemPswTip" style="width: 400px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                重复密码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemPsw1" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <div id="ctl00_cphCarInfo_txtMemPsw1Tip" style="width: 400px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                中介名称：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemMedium" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <div id="ctl00_cphCarInfo_txtMemMediumTip" style="width: 400px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                地区区号：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemUnitTelArea" runat="server" Width="50px"></asp:TextBox>
                            </td>
                            <td>
                                <div id="ctl00_cphCarInfo_txtMemUnitTelAreaTip" style="width: 200px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                电话号码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemUnitTel" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td>
                                <div id="ctl00_cphCarInfo_txtMemUnitTelTip" style="width: 200px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                工作虚拟号：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemShotNum" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <div id="ctl00_cphCarInfo_txtMemShotNumTip" style="width: 400px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                手机号码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemMobile" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <div id="ctl00_cphCarInfo_txtMemMobileTip" style="width: 400px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                真实姓名：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMemRealName" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <div id="ctl00_cphCarInfo_txtMemRealNameTip" style="width: 400px">
                                </div>
                            </td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/Member/login_button_reg.gif" />
                            </td>
                            <td>
                            </td>
                        </tr>
                    </tfoot>
                </table>
            </fieldset>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
