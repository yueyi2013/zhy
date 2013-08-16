<script type="text/javascript">
  window.loadGadget = function () {
  var codeUrl = 'http://ext.weather.com.cn/41704.js'
  var containerID = 'gadgetContainer'
  var s = document.createElement('script')
  s.type = 'text/javascript'
  s.src = codeUrl + '?target=' + containerID
  document.body.appendChild(s)
  }
  window.onload = window.onload ? function () {
  window.onload()
  window.loadGadget()
  }:window.loadGadget
</script>