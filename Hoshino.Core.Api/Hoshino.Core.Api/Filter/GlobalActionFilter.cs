using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoshino.Core.Api.Filter
{
    public class GlobalActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //生成请求过来的调用链日志id
            context.HttpContext.Items["LogId"] = Guid.NewGuid().ToString("N");

            string requestJson = string.Empty;
            try
            {
                using (var buffer = new MemoryStream())
                {
                    context.HttpContext.Request.Body.CopyTo(buffer);
                    buffer.Position = 0;

                    if (buffer != null)
                    {
                        buffer.Seek(0, SeekOrigin.Begin);
                        int len = (int)buffer.Length;
                        byte[] inputByts = new byte[len];
                        buffer.Read(inputByts, 0, len);
                        buffer.Close();
                        requestJson = Encoding.UTF8.GetString(inputByts);
                    }
                }
                if (!string.IsNullOrWhiteSpace(requestJson))
                {
                    //解密
                    context.HttpContext.Items["RequestJson"] = requestJson;
                    //Log4NetHelper.InfoLog(requestJson);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
