using ClothingSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ClothingSystem.Service.Tests
{
    [Trait("用户信息", "")]
    public class UserInfoServiceTests : BaseTests
    {
        public UserInfoServiceTests(ITestOutputHelper output) : base(output)
        {

        }

        [Fact(DisplayName = "登录")]
        public void LoginTests()
        {
            var pwd = "@123@456";
            _output.WriteLine(pwd);
            var userPwd = Tools.EncryptDESByUserPwd(pwd);
            _output.WriteLine(userPwd);
            pwd = Tools.DecryptDESByUserPwd(userPwd);
            _output.WriteLine(pwd);
        }
    }
}
