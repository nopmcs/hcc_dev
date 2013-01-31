using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Nop.Web.Models.Security
{
    public class Encryption
    {
        //Security key for Encryption
        private const string Security_Key = "79MLSF45GE8S6J20AK45Q9KF5O6DDFK5";
        private const string vec = "F5502320F8429037";

        public string PerformEncryption(string input)
        {
            string output = "";

            Aes aes = new AesCryptoServiceProvider();
            //DES des = new DESCryptoServiceProvider(); 
            aes.Mode = CipherMode.CBC;

            try
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] key = Encoding.ASCII.GetBytes(Security_Key);
                //byte[] plaintext = Encoding.ASCII.GetBytes(input);
                byte[] plaintext = utf8.GetBytes(input);

                byte[] IV = Encoding.ASCII.GetBytes(vec);

                aes.Key = key;
                aes.IV = IV;

                ICryptoTransform transform = aes.CreateEncryptor(aes.Key, aes.IV);

                MemoryStream memStreamEncryptedData = new MemoryStream();

                memStreamEncryptedData.Write(plaintext, 0, plaintext.Length);
                CryptoStream encStream = new CryptoStream(memStreamEncryptedData, transform, CryptoStreamMode.Write);

                byte[] ciphertext = memStreamEncryptedData.ToArray();
                output = Convert.ToBase64String(ciphertext);
                encStream.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            return output;
        }

        public string PerformDecryption(string input)
        {
            string output = "";
            Aes aes = new AesCryptoServiceProvider();
            //DES des = new DESCryptoServiceProvider();
            aes.Mode = CipherMode.CBC;
            try
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] ciphertext = Convert.FromBase64String(input);
                byte[] key = Encoding.ASCII.GetBytes(Security_Key);
                byte[] IV = Encoding.ASCII.GetBytes(vec);

                aes.Key = key;
                aes.IV = IV;
                ICryptoTransform transform = aes.CreateDecryptor(aes.Key, aes.IV);
                MemoryStream memDecryptStream = new MemoryStream();
                memDecryptStream.Write(ciphertext, 0, ciphertext.Length);
                CryptoStream cs_decrypt = new CryptoStream(memDecryptStream, transform, CryptoStreamMode.Write);

                byte[] plaintext = memDecryptStream.ToArray();
                //output = Encoding.ASCII.GetString(plaintext);
                output = utf8.GetString(plaintext);

            }
            catch (Exception e)
            {
                throw e;
            }
            return output;
        }

    }
}