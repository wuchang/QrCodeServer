using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using log4net;

namespace c2.QrServer
{
    public class Program
    {
        private static ILog log = LogManager.GetLogger("Program");
        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
            log4net.Config.XmlConfigurator.Configure();
            if (Environment.UserInteractive)
            {
                RunAsConsole(args);
            }
            else
            {
                RunAsWindowsService();
            }
        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            log.Error("ThreadException", e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            log.Fatal("UnhandledException", e.ExceptionObject as Exception);
        }

        private static void RunAsConsole(string[] args)
        {
            log.Info("----RunAsConsole----");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            bool bCreatedNew;
            var mutex = new Mutex(false, "ETaxServerController", out bCreatedNew);
            if (!bCreatedNew)
            {
                MessageBox.Show("管理程序已经在运行中,不能重复启动.");
                Environment.Exit(0);
                return;
            }


            Application.Run(new Form1());

        }

        private static void RunAsWindowsService()
        {
            log.Info("----RunAsWindowsService----");

            ServiceBase[] servicesToRun = new ServiceBase[] 
            { 
                new QrService() 
            };
            ServiceBase.Run(servicesToRun);
        }


        internal static void UninstallService()
        {
            log.Info("----uninstall service----");

            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { 
                            "/u", Assembly.GetExecutingAssembly().Location });

                MessageBox.Show("移除服务成功");
            }
            catch (Exception ex)
            {
                log.Error("移除服务失败", ex);
                MessageBox.Show("移除服务失败。\n" + ex.Message);
            }
        }

        internal static void InstallService()
        {
            log.Info("----install service----");
            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { 
                            Assembly.GetExecutingAssembly().Location });
                MessageBox.Show("安装服务成功");
            }
            catch (Exception ex)
            {
                log.Error("安装服务失败", ex);
                MessageBox.Show("安装服务失败。\n" + ex.Message);
            }
        }

    }
}