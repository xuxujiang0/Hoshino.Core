using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hoshino.Core.Common
{
    public class JsonHelper
    {
        /// <summary>  
        /// Json序列化   
        /// </summary>  
        /// <typeparam name="T">对象类型</typeparam>  
        /// <param name="obj">对象实例</param>  
        /// <returns>json字符串</returns>  
        public static string JsonSerializer(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>  
        /// Json反序列化  
        /// </summary>  
        /// <typeparam name="T">对象类型</typeparam>  
        /// <param name="jsonString">json字符串</param>  
        /// <returns>对象实例</returns>  
        public static T JsonDeserialize<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);//反序列化
        }
    }
}
