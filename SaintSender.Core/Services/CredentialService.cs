using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core.Services
{
    class CredentialService
    {
        private AesCryptoServiceProvider _myAes;

        public CredentialService(AesCryptoServiceProvider myAes)
        {
            this._myAes = CreateAesCryptoServiceProvider();
        }

        private AesCryptoServiceProvider CreateAesCryptoServiceProvider()
        {
            AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
            aesCryptoServiceProvider.Key = Encoding.UTF8.GetBytes("WnZr4u7w!z%C*F-J");
            aesCryptoServiceProvider.IV = Encoding.UTF8.GetBytes("*F-JaNdRgUkXp2s5");
            return aesCryptoServiceProvider;
        }
    }
}
