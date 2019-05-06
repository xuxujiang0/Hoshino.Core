using System;
using System.Collections.Generic;
using System.Text;

namespace Hoshino.Core.Model.DbModel
{
    public class log_info
    {
        public string id { set; get; }
        public string chain_id { set; get; }
        public string content { set; get; }
        public string interface_name { set; get; }
        public int call_type { set; get; }
        public DateTime creation_time { set; get; }
        public string ip { set; get; }
    }
}
