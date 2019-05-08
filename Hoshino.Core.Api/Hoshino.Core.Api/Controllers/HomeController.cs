using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hoshino.Core.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        public string HelloWorld()
        {
            return "Hello World1";
        }

      
    }
}
