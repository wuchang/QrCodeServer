using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace c2.QrServer
{
    internal partial class Form1 : Form
    {
        ILog log = LogManager.GetLogger("Form1");
        C2QrServer server;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = new C2QrServer(Properties.Settings.Default.BaseAddress);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.cbxRunAsWindowService.Checked)
            {
                RunService();
            }
            else
            {
                Run();
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (this.cbxRunAsWindowService.Checked)
            {
                StopService();
            }
            else
            {
                Stop();
            }
        }


        private void Stop()
        {
            if (this.server.IsRuning)
            {
                this.server.Stop();
                this.btnStart.Enabled = true;
                this.btnStop.Enabled = false;
            }
            // NativeMethods.FreeConsole();
        }
        private void Run()
        {
            //NativeMethods.AllocConsole();
            Console.WriteLine("start...");
            try
            {
                server.Start();
                log.Info("服务运行中，按回车键结束。");
                //Console.ReadLine();
                //server.Stop();
                this.btnStart.Enabled = false;
                this.btnStop.Enabled = true;
                //NativeMethods.AllocConsole();
            }
            catch (Exception ex)
            {
                log.Error("启动服务失败。", ex);
            }
        }

        private void RunService()
        {
            try
            {
                var sc = new System.ServiceProcess.ServiceController(this.txtServerName.Text);
                var st = sc.Status;
                switch (st)
                {
                    case ServiceControllerStatus.StopPending:
                    case ServiceControllerStatus.Stopped:
                        sc.Start();
                        break;
                    default: break;
                }
                sc.WaitForStatus(ServiceControllerStatus.Running);
                st = sc.Status;//再次获取服务状态
                if (st == ServiceControllerStatus.Running)
                {
                    this.lblStatus.Text = "服务 已经启动！";
                }

                this.btnStart.Enabled = false;
                this.btnStop.Enabled = true;

                MessageBox.Show("启动服务成功");
            }
            catch (Exception ex)
            {
                log.Error("启动服务失败", ex);
                MessageBox.Show("启动服务失败.\n" + ex.Message);
            }
        }
        private void StopService()
        {
            try
            {
                ServiceController sc = new ServiceController(this.txtServerName.Text);
                ServiceControllerStatus st = sc.Status;
                switch (st)
                {
                    case ServiceControllerStatus.Running:
                    case ServiceControllerStatus.StartPending:
                    case ServiceControllerStatus.Paused:
                    case ServiceControllerStatus.PausePending:
                    case ServiceControllerStatus.ContinuePending:
                        sc.Stop();
                        sc.WaitForStatus(ServiceControllerStatus.Stopped);
                        break;
                }
                st = sc.Status;//再次获取服务状态
                if (st == ServiceControllerStatus.Stopped)
                {
                    this.lblStatus.Text = "服务已经停止！";
                }

                this.btnStart.Enabled = true;
                this.btnStop.Enabled = false;
            }
            catch (Exception ex)
            {
                log.Error("启动服务失败", ex);
                MessageBox.Show("启动服务失败.\n" + ex.Message);
            }

        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            Program.InstallService();
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            Program.UninstallService();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //加载时检测服务状态
            try
            {
                ServiceController sc = new ServiceController(this.txtServerName.Text);
                if (sc.Status == ServiceControllerStatus.Running)
                {
                    this.btnStart.Enabled = false;
                    this.btnStop.Enabled = true;
                }
                else
                {
                    this.btnStart.Enabled = true;
                    this.btnStop.Enabled = false;
                }
                this.cbxRunAsWindowService.Checked = true;

                this.btnInstall.Enabled = false;
                this.btnUninstall.Enabled = true;
            }
            catch (Exception ex)
            {
                log.Error("检测服务状态出错.", ex);
            }
        }

        private void cbxRunAsWindowService_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked)
            {
                this.Stop();

                try
                {
                    ServiceController sc = new ServiceController(this.txtServerName.Text);

                    if (sc.Status == ServiceControllerStatus.Running)
                    {
                        this.btnStart.Enabled = false;
                        this.btnStop.Enabled = true;
                    }
                    else
                    {
                        this.btnStart.Enabled = true;
                        this.btnStop.Enabled = false;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("服务不存在,请先安装服务.");
                }
            }
            else
            {
                try
                {
                    this.StopService();
                }
                catch (Exception)
                {
                }
            }
        }

        public static bool IsInAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            var f = new Form2();
            f.Show();
        }

    }
}
