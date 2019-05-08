using System;
using System.Collections.Generic;
using System.Text;

namespace Hoshino.Core.Common.Exception
{
    /// <summary>
    /// 数据校验异常类
    /// </summary>
    public class ParamException : SystemException, ICoreException
    {
        public ParamException(int code, string msg)
        {
            this.code = code;
            this.msg = msg;
        }

        private int code { set; get; }
        private string msg { set; get; }

        public int getCode()
        {
            return code;
        }

        public string getMessage()
        {
            return msg;
        }
    }
}
