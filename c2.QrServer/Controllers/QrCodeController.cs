using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using System.Web.Security;
using log4net;

namespace c2.QrServer.Controllers
{
    public class QrCodeController : ApiController
    {
        private ILog _log = LogManager.GetLogger("QrCodeController");

        [HttpPost, HttpGet, ActionName("Create")]
        public HttpResponseMessage Create(PostModel data)
        {
            if (data == null || string.IsNullOrEmpty(data.Content))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "二维码内容不能为空。");
            }

            var bmp = QrHelper.ToBitmap(data.Content);

            var table = new Dictionary<string, Func<Bitmap, HttpResponseMessage>>
            {
                {"*/*",CreateBmpResponse},
                {"img/bmp",CreateBmpResponse},
                {"application/xml",CreateXmlResponse},
            };


            var accept = Request.Headers.Accept.Select(o => o.MediaType).FirstOrDefault() ?? "*/*";
            if (!table.ContainsKey(accept))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "不支请求的返回格式。" + accept);
            }

            var result = table[accept](bmp);
            result.Headers.Add("tag", Md5(data.Content));
            return result;
        }


        private HttpResponseMessage CreateXmlResponse(Bitmap bmp)
        {
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Bmp);
            ms.Position = 0;
            //var content = new ByteArrayContent(ms.ToArray());
            //content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
            var obj = new QrResult
            {
                Content = ms.ToArray()
            };
            var result = Request.CreateResponse(HttpStatusCode.OK, obj);

            return result;
        }

        private HttpResponseMessage CreateBmpResponse(Bitmap bmp)
        {
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Bmp);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(ms.ToArray())
            };
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/bmp");
            return result;

        }

        public class PostModel
        {
            public string Content { get; set; }
        }

        private string Md5(string str)
        {
            //作为密码方式加密   
            string s = FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
            return s;
        }
    }

    public class QrResult
    {
        public byte[] Content { get; set; }
    }

}
