<script type="text/javascript">
(function(){
var p = {
url:location.href,
showcount:'1',/*是否显示分享总数,显示：'1'，不显示：'0' */
desc:'{0}',/*默认分享理由(可选)*/
summary:'{1}',/*分享摘要(可选)*/
title:'{2}',/*分享标题(可选)*/
site:'{3}',/*分享来源 如：腾讯网(可选)*/
pics:'{4}', /*分享图片的路径(可选)*/
style:'101',
width:199,
height:30
};
var s = [];
for(var i in p){
s.push(i + '=' + encodeURIComponent(p[i]||''));
}
document.write(['<a version="1.0" class="qzOpenerDiv" href="http://sns.qzone.qq.com/cgi-bin/qzshare/cgi_qzshare_onekey?',s.join('&'),'" target="_blank">分享</a>'].join(''));
})();
</script>
<script src="http://qzonestyle.gtimg.cn/qzone/app/qzlike/qzopensl.js#jsdate=20111201" charset="utf-8"></script>

StringBuilder sbQZone = new StringBuilder();
sbQZone.Append("<script type=\"text/javascript\">
  ");
  sbQZone.Append("(function(){");
  sbQZone.Append("var p = {");
  sbQZone.Append("url:location.href,");
  sbQZone.Append("showcount:'1',");/*是否显示分享总数,显示：'1'，不显示：'0' */
  sbQZone.AppendFormat("desc:'{0}',","值得分享");/*默认分享理由(可选)*/
  sbQZone.AppendFormat("summary:'{0}',","");/*分享摘要(可选)*/
  sbQZone.AppendFormat("title:'{0}',", model.RCItemTitle);/*分享标题(可选)*/
  sbQZone.AppendFormat("site:'{0}',","SYIHY");/*分享来源 如：腾讯网(可选)*/
  sbQZone.AppendFormat("pics:'{0}',",""); /*分享图片的路径(可选)*/
  sbQZone.Append("style:'101',");
  sbQZone.Append("width:199,");
  sbQZone.Append("height:30");
  sbQZone.Append("};");
  sbQZone.Append("var s = [];");
  sbQZone.Append("for(var i in p){");
  sbQZone.Append("s.push(i + '=' + encodeURIComponent(p[i]||''));");
  sbQZone.Append("}");
  sbQZone.Append("document.write(['<a version=\"1.0\" class=\"qzOpenerDiv\" href=\"http://sns.qzone.qq.com/cgi-bin/qzshare/cgi_qzshare_onekey?',s.join('&'),'\" target=\"_blank\">分享</a>'].join(''));");
  sbQZone.Append("})();");
  sbQZone.Append("
</script>");
this.divQzone.InnerHtml = sbQZone.ToString();