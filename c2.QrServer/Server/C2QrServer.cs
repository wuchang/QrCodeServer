using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web.Http.SelfHost;
using log4net;

namespace c2.QrServer
{
    public class C2QrServer
    {
        private ILog log = LogManager.GetLogger("C2QrServer");
        private readonly string _baseAddress;
        private HttpSelfHostServer _httpServer;

        Mutex _mutex;

        public bool IsRuning { get; private set; }
        public C2QrServer(string baseUrl)
        {
            this._baseAddress = baseUrl;
        }

        public void Start()
        {
            bool bCreatedNew;
            this._mutex = new Mutex(false, "C2QrServer", out bCreatedNew);
            if (!bCreatedNew)
            {
                throw new ApplicationException("服务已经在运行中,不能重复启动.");
            }

            this.log.InfoFormat("----Server Starting...----");
            this.log.InfoFormat("Assembly at: {0}", Assembly.GetExecutingAssembly().Location);

            if (this._httpServer == null)
            {
                var config = new MyHttpHostConfiguration(_baseAddress);
                this._httpServer = new HttpSelfHostServer(config);

                this.log.InfoFormat("----web api Server Starting...----");
                this._httpServer.OpenAsync().Wait();
                this.log.InfoFormat("----Server Start  OK----");
                this.log.InfoFormat("server url: {0}", this._baseAddress);

                this.IsRuning = true;
            }
            else
            {
                log.Error("服务已经在运行中，不能重复启动。");
            }
        }

        public void Stop()
        {
            if (this.IsRuning)
            {
                this.log.InfoFormat("----Server Stoping...----");
                this._httpServer.CloseAsync().Wait();
                this.log.InfoFormat("----Server Stop OK...----");
                this._httpServer = null;

                this.IsRuning = false;

                this._mutex.Dispose();
            }
        }
    }
}
