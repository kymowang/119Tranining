using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Security;
using System.IO;

namespace Training119Helper
{
    /// <summary>
    /// 多重混合哈希工具类
    /// </summary>
    public sealed class HashHelper
    {
        private static readonly String hashKey = "0z/ogga#&^0982CB@sdQ!@#we4";
        /// <summary>
        /// 对敏感数据进行多重混合哈希
        /// </summary>
        /// <param name="source">待处理明文</param>
        /// <returns>Hasn后的数据</returns>
        public static String Hash(String source)
        {
            String hashCode = FormsAuthentication.HashPasswordForStoringInConfigFile(source, "MD5") +
                              FormsAuthentication.HashPasswordForStoringInConfigFile(hashKey, "MD5");
            return FormsAuthentication.HashPasswordForStoringInConfigFile(hashCode, "SHA1");
        }

        public static String GetConfigSerialNo()
        {
            using (FileStream fs1 = new FileStream("bin\\A_Rom.bin", FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fs1);

                byte[] rBytes = new byte[40];
                for (int i = 0; i < rBytes.Length; i++)
                {
                    rBytes[i] = (byte)(br.ReadInt32() / 10);
                }
                br.Close();
                
                return  Encoding.ASCII.GetString(rBytes);
            }
        }
    }
}
