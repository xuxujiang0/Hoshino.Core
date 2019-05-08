using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hoshino.Core.Common;
using Hoshino.Core.Common.Exception;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using static Hoshino.Core.Common.SysEnum;

namespace Hoshino.Core.Api.Controllers.Base
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 把Request里面的请求json反序列成对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <returns></returns>
        protected T getRequestParam<T>() where T : class
        {
            if (HttpContext.Items != null && HttpContext.Items.Count > 0 && HttpContext.Items.Keys.Contains("RequestJson"))
            {
                string requestJson = HttpContext.Items["RequestJson"].ToString();
                if (!string.IsNullOrEmpty(requestJson))
                {
                    T resultModel = JsonHelper.JsonDeserialize<T>(requestJson);
                    #region 数据校验
                    if (!TryValidateModel(resultModel))
                    {
                        List<ModelStateEntry> modelList = ModelState.Values.ToList();
                        if (modelList != null && modelList.Count > 0)
                        {
                            string errorMessage = modelList[0].Errors[0].ErrorMessage;

                            throw new ParamException((int)ResultCode.ParamError, errorMessage);

                        }
                    }
                    #endregion
                    return JsonHelper.JsonDeserialize<T>(requestJson);
                }
            }
            return default(T);
        }
    }
}