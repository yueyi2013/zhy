

//Ext.onReady(function()
//{Ext.get("btnAlert").on("click",function(){
// Ext.MessageBox.alert("请注意","这是ExtJS的提示框");});
//});


//var win=new Ext.Window({title:"hello",width:300,height:200,html:'<h1>Hello,easyjf open source</h1>'});
//win.show();
//});


//Ext.onReady(function(){
//Ext.get("btn").on("click",function(){
//Ext.MessageBox.confirm("请确认","是否真的要删除指定的内容",
//function(button,text){
//alert(button);
//alert(text);});});});

//Ext.onReady(function(){
//Ext.get("btn").on("click",function(){
//Ext.MessageBox.prompt("输入提示框","请输入你的新年愿望:",function(button,text){
//if(button=="ok"){
//alert("你的新年愿望是:"+text);
//}else alert("你放弃了录入!");
//});});});




function save(button){
if(button=="yes")
{
	//执行数据保存操作
}else if(button=="no")
{	
	//不保存数据	
}else{			
	//取消当前操作
}}Ext.onReady(function(){
Ext.get("btn").on("click",function(){
Ext.Msg.show({
title:'保存数据',
msg: '你已经作了一些数据操作，是否要保存当前内容的修改？',	
buttons: Ext.Msg.YESNOCANCEL,
fn: save,
icon: Ext.MessageBox.QUESTION});
});
});



Ext.onReady(function(){	
	new Ext.Panel({
		renderTo:"hello",
		width:400,
		height:200,
		layout:"column",
		items:[{columnWidth:.5,title:"面板1"},{columnWidth:.5,title:"面板2"}]
});
});


//在实际的应用中，表格中的数据一般都是直接存放在数据库表或服务器的文件中。
//因此，在使用表格控件的时候经常需要与服务器进行交互。
//ExtJS使用Ajax方式提供了一套与服务器交互的机制，
//也就是可以不用刷新页面，就可以访问服务器的程序进行数据读取或数据保存等操作。
//比如前面在表格中显示xml文档中数据的例子中，
//就是一个非常简单的从服务器端读取数据的例子，再回顾一下代码：

var store=new Ext.data.Store({

url:"hello.xml", 

reader:new Ext.data.XmlReader({

record:"row"},

["id","name","organization","homepage"])

});



//在实际的应用中，表格中的数据一般都是直接存放在数据库表或服务器的文件中。
//因此，在使用表格控件的时候经常需要与服务器进行交互。
//ExtJS使用Ajax方式提供了一套与服务器交互的机制，
//也就是可以不用刷新页面，就可以访问服务器的程序进行数据读取或数据保存等操作。
//比如前面在表格中显示xml文档中数据的例子中，
//就是一个非常简单的从服务器端读取数据的例子，再回顾一下代码：

var store=new Ext.data.Store({

url:"hello.xml", 

reader:new Ext.data.XmlReader({

record:"row"},

["id","name","organization","homepage"])

});

//因为Sote组件接受一个参数url，如果设置url，
//则ExtJS会创建一个与服务器交互的Ext.data.HttpProxy对象，
//该对象通过指定的Connection或Ext.Ajax.request来向服务端发送请求，
//从而可以读取到服务器端的数据。
//经验表明，服务器端产生JSon数据是一种非常不错的选择，
//也就是说假如服务器的url“student.ejf?cmd=list”产生下面的JSON数据输出：

{results:[{id:1,

name:'小王',

email:'xiaowang@easyjf.com',

sex:'男',

bornDate:'1991-4-4'},

{id:1,

name:'小李',

email:'xiaoli@easyjf.com',

sex:'男',

bornDate:'1992-5-6'},

{id:1,

name:'小兰',

email:'xiaoxiao@easyjf.com',

sex:'女',

bornDate:'1993-3-7'} 
]
}

//则前面显示学习信息编辑表格的store可以创建成下面的形式：

var store=new Ext.data.Store({

url:"student.ejf?cmd=list", 

reader:new Ext.data.JsonReader({

root:"result"},

["id","name","organization","homepage"])

}); 



//或者：
var store=new Ext.data.JsonStore({
url:"student.ejf?cmd=list", 
root:"result",
fields:["id","name","organization","homepage"]});


//其中root表示包含记录集数据的属性。
//如果在运行程序中需要给服务器端发送数据的时候，
//此时可以直接使用ExtJS中提供的Ext.Ajax对象的request方法。
//比如下面的代码实现放服务器的student.ejf?cmd=save这个url发起一个请求，
//并在params中指定发送的Student对象
function sFn()
{
    alert('保存成功');
}
function fFn()
{
    alert('保存失败');
}
Ext.Ajax.request({
   url: "student.ejf?cmd=save",
   success: sFn,
   failure: fFn,
   params: {
            name: "小李",
            email: "xiaoli@easyjf.com",
            bornDate:' 1992-5-6',
            sex: '男'
            }
});
