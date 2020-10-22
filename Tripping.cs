using System;
using System.Web;
using System.Text;
using CryptSharp;

namespace Tripping
{
    class Tripping
    {
        public Tripping(){
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        private readonly char[] SALT_TABLE = ("................................" +
                                                ".............../0123456789ABCDEF" +
                                                "GABCDEFGHIJKLMNOPQRSTUVWXYZabcde" +
                                                "fabcdefghijklmnopqrstuvwxyz....." +
                                                "................................" +
                                                "................................" +
                                                "................................" +
                                                "................................").ToCharArray();

        private string Generate_Salt(string password)
        {
            string salt = "";
            // Append H. to the password and take the second and third character
            password = (password + "H.").Substring(1, 2);
            // Use those two characters to get the corresponding salt values
            foreach(char c in password)
                salt += SALT_TABLE[c % 256];
            return salt;
        }

        /// <summary>
        /// Prepares the password string to be converted
        /// </summary>
        /// <param name="password">The password string</param>
        private string ShiftJIS_Encode(string password)
        {
            // Convert the password to SHIFT_JIS encoding
            var textBytes = Encoding.Default.GetBytes(password);
            password = Encoding.GetEncoding("shift_jis").GetString(textBytes);
            // HTML Escape
            password = HttpUtility.HtmlEncode(password);
            return password;
        }

        public string Tripcode(string password)
        {
            // Convert the string to ShiftJIS
            var JIS = ShiftJIS_Encode(password);
            // Generate the salt using the newly encoded string
            var Salt = Generate_Salt(JIS);
            // Use Crypt with JIS and the Salt to generate the tripcode
            // I take the Substring the way I did
            return Crypter.TraditionalDes.Crypt(JIS, Salt).Substring(3,10);
        }
    }
}
