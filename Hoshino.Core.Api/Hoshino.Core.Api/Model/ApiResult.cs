using Hoshino.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Hoshino.Core.Common.SysEnum;

namespace Hoshino.Core.Api.Model
{
    public class ApiResult
    {
        public ApiResult() { }
        public ApiResult(object obj)
        {
            this.data = obj;
        }
        public ApiResult(int result, string msg = "")
        {
            setResultCode((ResultCode)result, msg);
        }

        public int code { set; get; } = (int)ResultCode.Success;
        public string msg { set; get; } = EnumHelper.GetEnumDescription(ResultCode.Success);

        public object data { set; get; }


        public void setResultCode(ResultCode result, string msg = "")
        {
            this.code = (int)result;
            if (string.IsNullOrWhiteSpace(msg))
            {
                this.msg = EnumHelper.GetEnumDescription(result);
            }
            else
            {
                this.msg = msg;
            }

        }
    }
}
