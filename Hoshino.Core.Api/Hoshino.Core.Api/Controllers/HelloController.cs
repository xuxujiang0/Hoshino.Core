using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hoshino.Core.Api.Controllers
{
    [Produces("application/json")]
    public class HelloController : Controller
    {

        [Route("v1/Hello/helloWorld")]
        public string helloWorld()
        {

            return "Hello world";
        }
    }
}