using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Hoshino.Core.Common
{
    public class Enum
    {
        public enum LogCallType
        {
            [Description("请求")]
            Request = 1,
            [Description("响应")]
            Response = 2
        }
    }
}
