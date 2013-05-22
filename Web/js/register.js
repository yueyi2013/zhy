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
    
	$("#ctl00_cphCarInfo_txtMemMobile").formValidator({empty:true,onshow:"请输入你的手机号码，可以为空哦",onfocus:"你要是输入了，必须输入正确",oncorrect:"谢谢你的合作",onempty:"你真的不想留手机号码啊？"}).inputValidator({min:11,max:11,onerror:"手机号码必须是11位的,请确认"}).regexValidator({regexp:"mobile",datatype:"enum",onerror:"你输入的手机号码格式不正确"});;

    $("#ctl00_cphCarInfo_txtMemRealName").formValidator({onshow:"领大奖和提款的依据，为确保您的中奖利益，请如实填写您的真实姓名，注册后不可修改。",onfocus:"请填写您的真实姓名",oncorrect:"真实姓名已填写"})
		.inputValidator({min:1,max:8,empty:{leftempty:false,rightempty:false,emptyerror:"您填入了空符号"},onerror:"您的真实姓名可能输入错误,请核对"})
		.regexValidator({regexp:"^[a-zA-Z\u4e00-\u9fa5]+$",onerror:"您的真实姓名可能输入错误,请核对"});
});