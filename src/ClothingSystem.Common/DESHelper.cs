using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClothingSystem.Common
{
    public class DESHelper
    {
        //默认密钥向量
        private static byte[] IVBytes = Encoding.UTF8.GetBytes(Constant.IVKey);

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey);
                byte[] rgbIV = IVBytes;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                using (DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider())
                {
                    using (MemoryStream mStream = new MemoryStream())
                    {
                        using (CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                        {
                            cStream.Write(inputByteArray, 0, inputByteArray.Length);
                            cStream.FlushFinalBlock();
                            return Convert.ToBase64String(mStream.ToArray());
                        }

                    }
                }
            }
            catch(Exception ex)
            {
                // throw;
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = IVBytes;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                using (DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider())
                {
                    using (MemoryStream mStream = new MemoryStream())
                    {
                        using (CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write))
                        {
                            cStream.Write(inputByteArray, 0, inputByteArray.Length);
                            cStream.FlushFinalBlock();
                            return Encoding.UTF8.GetString(mStream.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // throw;
                return decryptString;
            }
        }
    }
}
