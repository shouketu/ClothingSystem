using ClothingSystem.Dto.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Dto.Model
{
    /// <summary>
    /// 登录响应模型
    /// </summary>
    public class LoginResponseDto
    {
        public LoginResponseDto(LoginResultEnum result, string auth = null)
        {
            Result = result;
            Auth = auth;
        }

        public string Auth { get; set; }

        public LoginResultEnum Result { get; set; }
    }
}
