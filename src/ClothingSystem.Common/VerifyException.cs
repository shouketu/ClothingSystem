using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Common
{
    public class VerifyException : Exception
    {
        public VerifyException(string code, string message) : base(message)
        {
            ErrorCode = code;
            ErrorMessage = message;
        }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }
    }
}
