using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Hoshino.Core.Common
{
    public class SysEnum
    {
        public enum ResultCode
        {
            [Description("成功")]
            Success = 10000,
            [Description("失败")]
            Fail = 10001,
            [Description("参数异常")]
            ParamError = 10002,
            [Description("内部异常")]
            InnerException = 20000
        }

        public enum LogType
        {
            Info = 1,
            Error = 2
        }
        public enum VCodeType
        {
            [Description("注册")]
            Register = 1,
            [Description("找回密码")]
            GorgotPassword = 2
        }
    }
}
