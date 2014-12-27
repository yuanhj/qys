using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Web
{
    public static class Des
    {
        private static readonly string sKey = "q7hxEh6hsfZDfJsCnJdGOxzaiN7NLQMa";//密钥
        private static readonly string sIV = "fg+fY6dXzLd=";//矢量,矢量可以为空
        private static SymmetricAlgorithm mCSP = new TripleDESCryptoServiceProvider();//构造一个对称算法
        public static string EncryptDes(string source)
        {
            return EncryptDes(source, sKey);
        }
        public static string EncryptDes(string source, string key)
        {
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            string str = null;
            try
            {
                mCSP.Key = Convert.FromBase64String(key);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " key:" + key);
            }
            mCSP.IV = Convert.FromBase64String(sIV);
            mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
            mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ct = mCSP.CreateEncryptor(mCSP.Key, mCSP.IV);
            byt = Encoding.UTF8.GetBytes(source);
            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            str = Convert.ToBase64String(ms.ToArray());
            return str;
        }

        public static string DecryptDes(string source)
        {
            return DecryptDes(source, sKey);
        }

        public static string DecryptDes(string source, string key)
        {
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;
            string str = null;
            mCSP.Key = Convert.FromBase64String(key);
            mCSP.IV = Convert.FromBase64String(sIV);
            mCSP.Mode = System.Security.Cryptography.CipherMode.ECB;
            mCSP.Padding = System.Security.Cryptography.PaddingMode.PKCS7;
            ct = mCSP.CreateDecryptor(mCSP.Key, mCSP.IV);
            byt = Convert.FromBase64String(source);
            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();
            cs.Close();
            str = Encoding.UTF8.GetString(ms.ToArray());
            return str;
        }
    }
}