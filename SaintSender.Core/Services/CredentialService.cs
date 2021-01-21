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
    public class CredentialService
    {
        private AesCryptoServiceProvider _myAes;

        public CredentialService()
        {
            _myAes = CreateAesCryptoServiceProvider();
        }

        private AesCryptoServiceProvider CreateAesCryptoServiceProvider()
        {
            AesCryptoServiceProvider aesCryptoServiceProvider = new AesCryptoServiceProvider();
            aesCryptoServiceProvider.Key = Encoding.UTF8.GetBytes("WnZr4u7w!z%C*F-J");
            aesCryptoServiceProvider.IV = Encoding.UTF8.GetBytes("*F-JaNdRgUkXp2s5");
            return aesCryptoServiceProvider;
        }

        public void SaveCredentials(string email, string password)
        {
            string original = $"{email}/{password}";
            byte[] encrypted;
            using (_myAes)
            {
                encrypted = EncryptStringToBytes_Aes(original, _myAes.Key, _myAes.IV);
            }
            IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            using (IsolatedStorageFileStream isolatedStream = new IsolatedStorageFileStream("login_cred.data", FileMode.Create, isolatedStorage))
            using (StreamWriter writer = new StreamWriter(isolatedStream))
            {
                writer.BaseStream.Write(encrypted, 0, encrypted.Length);
            }

        }

        public string[] GetSavedCredentials()
        {
            IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
            if (isolatedStorage.FileExists("login_cred.data"))
            {
                using (IsolatedStorageFileStream isolatedStream = new IsolatedStorageFileStream("login_cred.data", FileMode.Open, isolatedStorage))
                using (StreamReader reader = new StreamReader(isolatedStream))
                using (MemoryStream ms = new MemoryStream())
                {
                    reader.BaseStream.CopyTo(ms);
                    byte[] encrypted = ms.ToArray();
                    string decrypted = DecryptStringFromBytes_Aes(encrypted, _myAes.Key, _myAes.IV);
                    string[] cred = decrypted.Split('/');
                    return cred;
                }
            }
            else { return null;  }

        }

        private byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (_myAes)
            {
                _myAes.Key = Key;
                _myAes.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = _myAes.CreateEncryptor(_myAes.Key, _myAes.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        private string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AesCryptoServiceProvider object
            // with the specified key and IV.
            using (_myAes)
            {
                _myAes.Key = Key;
                _myAes.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = _myAes.CreateDecryptor(_myAes.Key, _myAes.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
