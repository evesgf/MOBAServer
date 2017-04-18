using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net;
using log4net.Config;
using MOBAServer.Cache;
using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOBAServer
{
    public class MobaApplication : ApplicationBase
    {
        /// <summary>
        /// 客户端连接
        /// </summary>
        /// <param name="initRequest"></param>
        /// <returns></returns>
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            LogInfo("上线："+initRequest.RemoteIP);
            return new MobaClient(initRequest);
        }

        /// <summary>
        /// 服务器初始化
        /// </summary>
        protected override void Setup()
        {
            InitLogging();
            new Caches();
        }

        /// <summary>
        /// 服务器断开
        /// </summary>
        protected override void TearDown()
        {
            LogInfo("Server Tear Down");
        }

        #region 日志功能
        //获取当前类里的log方法
        private static readonly ILogger log = ExitGames.Logging.LogManager.GetCurrentClassLogger();
        /// <summary>
        /// 初始化日志
        /// </summary>
        private void InitLogging()
        {
            ExitGames.Logging.LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
            GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");
            //设置日志名，不能以特殊符号开头
            GlobalContext.Properties["LogFileName"] = "EVESGF-" + this.ApplicationName;
            XmlConfigurator.ConfigureAndWatch(new FileInfo(Path.Combine(this.BinaryPath, "log4net.config")));
        }

        /// <summary>
        /// 输出日志
        /// </summary>
        /// <param name="info"></param>
        public static void LogInfo(string info)
        {
            log.Info(info);
        }
        #endregion
    }
}
