using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hoshino.Core.Api.Controllers.Base;
using Hoshino.Core.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Hoshino.Core.Api.Controllers
{
    [Produces("application/json")]
    [Route("v1/[controller]")]
    public class HomeController : BaseController
    {

        private ILogInfoService LogInfoService = null;

        public HomeController(ILogInfoService logInfoService)
        {
            LogInfoService = logInfoService;
        }
        public string HelloWorld()
        {
            //registerUserIn model_in = getRequestParam<registerUserIn>();

            //Dictionary<string, object> dic = new Dictionary<string, object>();
            //dic["id"] = Guid.NewGuid().ToString("N");
            //dic["account"] = model_in.account;
            //dic["password"] = model_in.password;
            //dic["creation_user"] = model_in.account;

            string chain_id = Guid.NewGuid().ToString("N");

            bool result = LogInfoService.insertLogInfo(chain_id);

            return "Hello World" + result;
        }


    }
}
