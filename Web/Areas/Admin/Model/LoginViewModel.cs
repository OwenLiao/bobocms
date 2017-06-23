using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Admin.Model
{
    /// <summary>
    /// 登陆模型
    /// <remarks>
    /// 创建：2015.5.30
    /// </remarks>
    /// </summary>
    public class LoginViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0}长度{2}-{1}个字符")]

        [Display(Name = "账号")]
        public string user_name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "{0}长度{2}-{1}个字符")]
        [Display(Name = "密码")]
        public string user_pwd { get; set; }
    }
}