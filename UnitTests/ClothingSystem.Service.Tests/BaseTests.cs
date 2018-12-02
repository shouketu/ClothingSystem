using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace ClothingSystem.Service.Tests
{
    public class BaseTests
    {
        protected ITestOutputHelper _output;
        public BaseTests(ITestOutputHelper output)
        {
            _output = output;
        }
    }
}
