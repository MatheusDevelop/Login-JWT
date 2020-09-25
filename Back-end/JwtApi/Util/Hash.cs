using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtApi.Util
{
    public class Hash
    {
        public string GenerateHash(string pass, string nameForSalt)
        {

            var strArr = nameForSalt.ToCharArray();

            //Pega os 3 primeiros digitos do nome pro salt
            string str = strArr[0].ToString() + strArr[1].ToString() + strArr[2].ToString();


            byte[] salt = Encoding.UTF8.GetBytes(str);


            string hash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
               password: pass,
               salt: salt,
               prf: KeyDerivationPrf.HMACSHA256,
               iterationCount: 10000,
               numBytesRequested: 256 / 8
            ));

            return hash;
        }
    }
}
