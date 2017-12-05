using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.Controllers
{
    public class PasswordController
    {
        /// <summary>
        /// Generates the hash string for provided password
        /// </summary>
        /// <param name="password">Password to make an hash string from</param>
        /// <returns></returns>
        public static string GetPwdHash(string password)
        {
            string result = String.Empty;
            byte[] data = Encoding.UTF8.GetBytes(password);
            using (SHA512 shaM = new SHA512Managed())
            {
                var byteHash = shaM.ComputeHash(data);
                foreach (byte theByte in byteHash)
                {
                    result += String.Format("{0:x2}", theByte);
                }
            }
            return result;
        }
    }
}
