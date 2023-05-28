using System.Security.Cryptography;
using System.Text;

namespace ENT.Framework
{
    public static class Criptografia
    {
        public static string Encrypt(string input, string pass)
        {
            var AES = new RijndaelManaged();
            var Hash_AES = new MD5CryptoServiceProvider();
            var hash = new byte[32];
            byte[] temp = Hash_AES.ComputeHash(Encoding.ASCII.GetBytes(pass));
            Array.Copy(temp, 0, hash, 0, 16);
            Array.Copy(temp, 0, hash, 15, 16);
            AES.Key = hash;
            AES.Mode = CipherMode.ECB;
            ICryptoTransform DESEncrypter = AES.CreateEncryptor();
            byte[] Buffer = Encoding.ASCII.GetBytes(input);
            return Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));

        }

        public static string Decrypt(string input, string pass)
        {
            var AES = new RijndaelManaged();
            var Hash_AES = new MD5CryptoServiceProvider();

            var hash = new byte[32];
            byte[] temp = Hash_AES.ComputeHash(Encoding.ASCII.GetBytes(pass));
            Array.Copy(temp, 0, hash, 0, 16);
            Array.Copy(temp, 0, hash, 15, 16);
            AES.Key = hash;
            AES.Mode = CipherMode.ECB;
            ICryptoTransform DESDecrypter = AES.CreateDecryptor();
            byte[] Buffer = Convert.FromBase64String(input);
            return Encoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length));

        }
        public static string GerarMD5(string texto)
        {
            byte[] bytHash;
            using (var provider = new MD5CryptoServiceProvider())
            {
                bytHash = provider.ComputeHash(Encoding.UTF8.GetBytes(texto));
                provider.Clear();
            }
            return BitConverter.ToString(bytHash).Replace("-", String.Empty);

        }

        public static string EncryptBase64(string str)
        {
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(str));
        }

        public static string DecryptBase64(string str)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(str));
        }

    }
}
