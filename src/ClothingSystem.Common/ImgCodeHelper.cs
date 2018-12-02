using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace ClothingSystem.Common
{
    public class ImgCodeHelper
    {
        private static string getCheckCode(Random rnd, int codeLength)
        {
            string chkCode = string.Empty;
            char[] character = { '2', '3', '4', '5', '6', '8', '9', 'a', 'b', 'd', 'e', 'f', 'h', 'k', 'm', 'n', 'r', 'x', 'y', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'R', 'S', 'T', 'W', 'X', 'Y' };
            //生成验证码字符串 
            for (int i = 0; i < codeLength; i++)
            {
                chkCode += character[rnd.Next(character.Length)];
            }
            return chkCode;
        }

        public static ImgCodeResult Generate(int codeLength = 4, int codeW = 80, int codeH = 22)
        {
            string chkCode = getCheckCode(new Random(), codeLength);
            var buffer = Generate(chkCode, codeW, codeH);
            var base64 = Convert.ToBase64String(buffer);
            return new ImgCodeResult() { ImgCode = chkCode, ImgBase64 = base64 };
        }

        public static byte[] Generate(string chkCode, int codeW = 80, int codeH = 22)
        {
            //颜色列表，用于验证码、噪线、噪点 
            Color[] color = { Color.Red, Color.Blue, Color.Green, Color.DarkGoldenrod, Color.Chocolate };
            //字体列表，用于验证码 
            string[] font = { "Times New Roman", "Verdana", "Arial" };
            //验证码的字符集，去掉了一些容易混淆的字符 
            Random rnd = new Random();

            //创建画布
            Bitmap bmp = new Bitmap(codeW, codeH);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            //画噪线 
            for (int i = 0; i < 5; i++)
            {
                int x1 = rnd.Next(codeW);
                int y1 = rnd.Next(codeH);
                int x2 = rnd.Next(codeW);
                int y2 = rnd.Next(codeH);
                Color clr = color[rnd.Next(color.Length)];
                g.DrawLine(new Pen(clr), x1, y1, x2, y2);
            }

            int fontSize = 16;
            int yPianyi = 0;

            //画验证码字符串 
            for (int i = 0; i < chkCode.Length; i++)
            {
                string fnt = font[rnd.Next(font.Length)];
                Font ft = new Font(fnt, fontSize);
                Color clr = color[rnd.Next(color.Length)];
                g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clr), (float)i * (codeW / 4 - 2) + 1, (float)yPianyi);
                g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clr), (float)i * (codeW / 4 - 2) + 3, (float)yPianyi);
                g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clr), (float)i * (codeW / 4 - 2) + 2, (float)(yPianyi + 1));
                g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clr), (float)i * (codeW / 4 - 2) + 2, (float)(yPianyi - 1));
                g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(Color.White), (float)i * (codeW / 4 - 2) + 2, (float)yPianyi);
            }

            //画噪点 
            for (int i = 0; i < 50; i++)
            {
                int x = rnd.Next(bmp.Width);
                int y = rnd.Next(bmp.Height);
                Color clr = color[rnd.Next(color.Length)];
                bmp.SetPixel(x, y, clr);
            }

            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            finally
            {
                //显式释放资源 
                bmp.Dispose();
                g.Dispose();
            }
        }
    }

    /// <summary>
    /// 图形验证码返回模型
    /// </summary>
    public class ImgCodeResult
    {
        /// <summary>
        /// 图形验证码
        /// </summary>
        public string ImgCode { get; set; }

        /// <summary>
        /// 图片Base64
        /// </summary>
        public string ImgBase64 { get; set; }

        /// <summary>
        /// 完整图片Base64
        /// </summary>
        public string FullImgBase64 => $"data:image/png;base64,{ImgBase64}";
    }
}