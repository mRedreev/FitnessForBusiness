using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FitnessForBusiness.Core.Security
{
    public class GetHashPassword
    {
        public static string GetHash(string password)
        {
            var md5Password = MD5.Create();

            var hashPassword = md5Password.ComputeHash(Encoding.UTF8.GetBytes(password));

            return Convert.ToBase64String(hashPassword);
        }
    }
}
