using Core.DBHelper.SQLHelper;
using Hoshino.Core.Interface;
using Hoshino.Core.Interface.IService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hoshino.Core.Service
{
    public class LogInfoService : ILogInfoService, IDependency
    {
        public bool insertLogInfo(string chain_id)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();

            dic["chain_id"] = chain_id;

            dic["creation_time"] = DateTime.Now;




            return SQLHelperFactory.Instance.ExecuteNonQuery("LogInfo_InsertLogInfo", dic) > 0;
        }
    }
}
