using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using log4net;

namespace c2.QrServer
{
    partial class QrService : ServiceBase
    {
        private readonly ILog _log = LogManager.GetLogger("ETaxServer");
        private readonly C2QrServer _server;
        public QrService()
        {
            InitializeComponent();
            this._server = new C2QrServer(Properties.Settings.Default.BaseAddress);
        }

        protected override void OnStart(string[] args)
        {
            _log.Info("----service start----");

            this._server.Start();
        }

        protected override void OnStop()
        {
            _log.Info("----service end----");
            // this.server.Stop();
        }
    }
}
