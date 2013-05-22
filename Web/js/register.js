$(document).ready(function(){
	
	$.formValidator.initConfig({formid:"aspnetForm",onerror:function(msg){alert(msg)},onsuccess:function(){alert('ddd');return false;}});
	$("#ctl00_cphCarInfo_txtMemAccount").formValidator({onshow:"�������û���",onfocus:"�û�������6���ַ�,���10���ַ�",oncorrect:"���û�������ע��"}).inputValidator({min:6,max:10,onerror:"��������û����Ƿ�,��ȷ��"}).regexValidator({regexp:"username",datatype:"enum",onerror:"�û�����ʽ����ȷ"})
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
		error: function(){alert("������û�з������ݣ����ܷ�����æ��������");},
		onerror : "���û��������ã�������û���",
		onwait : "���ڶ��û������кϷ���У�飬���Ժ�..."
	});
	$("#ctl00_cphCarInfo_txtMemPsw").formValidator({onshow:"����������",onfocus:"���벻��Ϊ��",oncorrect:"����Ϸ�"}).inputValidator({min:1,empty:{leftempty:false,rightempty:false,emptyerror:"�������߲����пշ���"},onerror:"���벻��Ϊ��,��ȷ��"});
	$("#ctl00_cphCarInfo_txtMemPsw1").formValidator({onshow:"�������ظ�����",onfocus:"�����������һ��Ŷ",oncorrect:"����һ��"}).inputValidator({min:1,empty:{leftempty:false,rightempty:false,emptyerror:"�ظ��������߲����пշ���"},onerror:"�ظ����벻��Ϊ��,��ȷ��"}).compareValidator({desid:"password1",operateor:"=",onerror:"2�����벻һ��,��ȷ��"});
    
	$("#ctl00_cphCarInfo_txtMemMobile").formValidator({empty:true,onshow:"����������ֻ����룬����Ϊ��Ŷ",onfocus:"��Ҫ�������ˣ�����������ȷ",oncorrect:"лл��ĺ���",onempty:"����Ĳ������ֻ����밡��"}).inputValidator({min:11,max:11,onerror:"�ֻ����������11λ��,��ȷ��"}).regexValidator({regexp:"mobile",datatype:"enum",onerror:"��������ֻ������ʽ����ȷ"});;

    $("#ctl00_cphCarInfo_txtMemRealName").formValidator({onshow:"��󽱺��������ݣ�Ϊȷ�������н����棬����ʵ��д������ʵ������ע��󲻿��޸ġ�",onfocus:"����д������ʵ����",oncorrect:"��ʵ��������д"})
		.inputValidator({min:1,max:8,empty:{leftempty:false,rightempty:false,emptyerror:"�������˿շ���"},onerror:"������ʵ���������������,��˶�"})
		.regexValidator({regexp:"^[a-zA-Z\u4e00-\u9fa5]+$",onerror:"������ʵ���������������,��˶�"});
});