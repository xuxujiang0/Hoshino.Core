using Hoshino.Core.Model.DbModel;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Hoshino.Core.Common.SysEnum;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", ConfigFileExtension = "config", Watch = true)]
namespace Hoshino.Core.Common
{
    public class Log4NetHelper
    {
        private static log4net.ILog logError = null;// log4net.LogManager.GetLogger("LogError");
        private static log4net.ILog logInfo = null;// log4net.LogManager.GetLogger("LogInfo");
        private static log4net.ILog logDB = null;

        static Log4NetHelper()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new System.IO.FileInfo("log4net.config"));
            logDB = log4net.LogManager.GetLogger(logRepository.Name, "LogDB");
            logError = log4net.LogManager.GetLogger(logRepository.Name, "LogError");
            logInfo = log4net.LogManager.GetLogger(logRepository.Name, "LogInfo");
        }

        #region  ErrorLog

        public static void ErrorLog(object msg)
        {
            if (ConfigHelper.WriteTextLog == "0") return;
            if (msg != null)
            {
                msg = GetChainId() + "\r\n" + msg;
            }
            Task.Run(() => logError.Error(msg));
        }

        public static void ErrorLog(System.Exception ex)
        {
            if (ConfigHelper.WriteTextLog == "0") return;
            Task.Run(() => logError.Error(GetChainId() + "\r\n" + ex.Message.ToString() + "\r\n" + ex.Source.ToString() + "\r\n" + ex.TargetSite.ToString() + "\r\n" + ex.StackTrace.ToString()));
        }


        public static void ErrorLog(object msg, System.Exception ex)
        {
            if (ConfigHelper.WriteTextLog == "0") return;
            if (ex != null)
            {
                Task.Run(() => logError.Error(msg, ex));
            }
            else
            {
                Task.Run(() => logError.Error(msg));
            }
        }
        #endregion

        #region InfoLog
        public static void InfoLog(object msg)
        {
            if (ConfigHelper.WriteTextLog == "0") return;
            if (msg != null)
            {
                msg = GetChainId() + "\r\n" + msg;
            }
            Task.Run(() => logInfo.Info(msg));
        }
        public static void InfoLog(System.Exception ex)
        {
            if (ConfigHelper.WriteTextLog == "0") return;
            Task.Run(() => logInfo.Info(GetChainId() + "\r\n" + ex.Message.ToString() + "\r\n" + ex.Source.ToString() + "\r\n" + ex.TargetSite.ToString() + "\r\n" + ex.StackTrace.ToString()));
        }
        public static void InfoLog(object msg, System.Exception ex)
        {
            if (ConfigHelper.WriteTextLog == "0") return;
            if (ex != null)
            {
                Task.Run(() => logInfo.Info(msg, ex));
            }
            else
            {
                Task.Run(() => logInfo.Info(msg));
            }
        }
        #endregion

        #region DbLog
        public static void DBLog(object msg)
        {
            Task.Run(() => logDB.Info(msg));
        }

        public static void DBLog(string json, string instertaceName, LogType callType)
        {
            if (string.IsNullOrWhiteSpace(json)) return;

            var context = HttpContextHelper.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;


            log_info log = new log_info();
            //log.id = Guid.NewGuid().ToString("N");
            log.chain_id = GetChainId();
            log.content = json;
            log.interface_name = instertaceName;
            log.type = (int)callType;
            log.creation_time = DateTime.Now;
            log.ip = context.Request.Host.ToString();
            DBLog(log);
        }

        #endregion

        private static string GetChainId()
        {
            var context = HttpContextHelper.ServiceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext;

            return context.Items["LogId"].ToString();
        }
    }
}
