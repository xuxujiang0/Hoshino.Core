using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hoshino.Core.Model.RequestModel
{
    public class registerUserIn
    {
        /// <summary>
        /// 手机号码或者邮箱
        /// </summary>
        [RegularExpression(@"^1[3|4|5|8][0-9]\d{4,8}$", ErrorMessage = "手机号码格式有误"), Required(ErrorMessage = "手机号码不能为空")]
        public string account { set; get; }
        /// <summary>
        /// 密码 md5
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        public string password { set; get; }
    }
}
