using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TripleDes
{
    public static  class Des
    {

      
        private const string mysecurityKey = "15EA4CA20131C2FDDF2C13102AC4AE51";

        // first encription
      

        public static string Encrypt(string toEncrypt)
        {
            byte[] keyArray;
          
            byte[] toEncryptArray = StringToByteArray(toEncrypt);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();


            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
           
            keyArray = StringToByteArray(mysecurityKey);
            //Always release the resources and flush data
            // of the Cryptographic service provide. Best Practice

            hashmd5.Clear();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.None;
            

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format

           var hexString = ByteArrayToHexString(resultArray);

           return  ConvertToBase64String(hexString.ToUpper());
        }


        public static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        // convert to string 
        public static string ByteArrayToHexString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }


        // convert to base64 string 

        public static string ConvertToBase64String(string text)
        {
            var byteString = Encoding.UTF8.GetBytes(text);
          return   Convert.ToBase64String(byteString);
        }
    }
}
