using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hoshino.Core.Model.RequestModel
{
    public class generateVCodeIn
    {
        /// <summary>
        /// 手机号码或者邮箱
        /// </summary>
        [RegularExpression(@"^1[3|4|5|8][0-9]\d{4,8}$", ErrorMessage = "手机号码格式有误"), Required(ErrorMessage = "手机号码不能为空")]
        public string account { set; get; }

        /// <summary>
        /// 1:注册 2：找回密码
        /// </summary>
        //[EnumDataType(typeof(VCodeType), ErrorMessage = "VCodeType的枚举类型不对")]
        public int vCodeType { set; get; }
    }
}
