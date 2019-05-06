using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Hoshino.Core.Common
{
    public class ConfigHelper
    {
        /// <summary>
        /// 0:不写文本log  1:写文本log
        /// </summary>
        public static string WriteTextLog { set; get; } = "0";

        public static void loadConfig()
        {
            WriteTextLog = ConfigurationManager.AppSettings["WriteTextLog"] ?? "0";
        }
    }
}
