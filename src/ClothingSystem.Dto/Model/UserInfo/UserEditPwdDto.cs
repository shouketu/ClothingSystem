﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 用户修改密码模型
    /// </summary>
    public class UserEditPwdDto
    {
        /// <summary>
        /// 旧密码
        /// </summary>
        public string OldPwd { get; set; }

        /// <summary>
        /// 新密码
        /// </summary>
        public string NewPwd { get; set; }

        /// <summary>
        /// 确认密码
        /// </summary>
        public string ReNewPwd { get; set; }
    }
}
