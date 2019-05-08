using Hoshino.Core.Api.Model;
using Hoshino.Core.Common;
using Hoshino.Core.Common.Exception;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using static Hoshino.Core.Common.SysEnum;

namespace Hoshino.Core.Api.Filter
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ApiResult result = new ApiResult((int)ResultCode.InnerException, context.Exception.Message);
            if (context.Exception is ICoreException)
            {
                ICoreException exception = context.Exception as ICoreException;
                result = new ApiResult(exception.getCode(), exception.getMessage());
            }
            else
            {
                result = new ApiResult(ResultCode.Fail);
            }
            Log4NetHelper.ErrorLog(context.Exception);

            string resultStr = JsonHelper.JsonSerializer(result);
            context.HttpContext.Response.ContentType = "application/json;charset=utf-8";


            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            context.HttpContext.Response.WriteAsync(resultStr);
            context.ExceptionHandled = true;
        }
    }
}
