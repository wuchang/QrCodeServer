QrCodeServer
============


使用asp.net webapi寄宿的生成二维码服务


客户端调用: 

```cs

 var httpClient = new HttpClient()
 {
     BaseAddress = "http://localhost:1227",

 };
 var url =  "qrcode/create" ;

 var data=new { content = "二维码数据，github.com/wuchang"};
 var param = Newtonsoft.Json.JsonConvert.SerializeObject( data );
 HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
 var httpResult = httpClient.PostAsync(url, contentPost).Result;


 httpResult.EnsureSuccessStatusCode();
 var stream = httpResult.Content.ReadAsStreamAsync().Result;

 var img = Image.FromStream(stream);
 this.pictureBox1.Image = img;
 this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

```
