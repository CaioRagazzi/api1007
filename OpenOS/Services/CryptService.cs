using Microsoft.Extensions.Configuration;
using OpenOS.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OpenOS.Services
{
    public class CryptService : ICrypt
    {
        private IConfiguration _configuration;

        public CryptService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Decrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            var md5Provider = new MD5CryptoServiceProvider();
            var chaveMD5Byte = md5Provider.ComputeHash(Encoding.UTF8.GetBytes(_configuration["CriptKey"]));
            var algoritmoDescriptografia = new TripleDESCryptoServiceProvider { Key = chaveMD5Byte, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };

            try
            {
                var dadosParaDescriptografar = Convert.FromBase64String(text);
                var descriptografador = algoritmoDescriptografia.CreateDecryptor();
                var resultado = descriptografador.TransformFinalBlock(dadosParaDescriptografar, 0, dadosParaDescriptografar.Length);
                return Encoding.UTF8.GetString(resultado);
            }
            finally
            {
                algoritmoDescriptografia.Clear();
                md5Provider.Clear();
            }
        }

        public string Encrypt(string text)
        {

            if (string.IsNullOrEmpty(text))
                return string.Empty;

            var md5Provider = new MD5CryptoServiceProvider();
            var chaveMD5Byte = md5Provider.ComputeHash(Encoding.UTF8.GetBytes(_configuration["CriptKey"]));
            var algoritmoDescriptografia = new TripleDESCryptoServiceProvider { Key = chaveMD5Byte, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 };

            try
            {
                var dadosParaCriptografar = Encoding.UTF8.GetBytes(text);
                var criptografador = algoritmoDescriptografia.CreateEncryptor();
                var resultado = criptografador.TransformFinalBlock(dadosParaCriptografar, 0, dadosParaCriptografar.Length);
                return Convert.ToBase64String(resultado);
            }

            finally
            {
                algoritmoDescriptografia.Clear();
                md5Provider.Clear();
            }

        }
    }
}
