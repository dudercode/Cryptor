using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Cryptor
{
	class MD5Utilities
	{
		public static string Encrypt(string value, string key)
		{
			byte[] data = UTF32Encoding.UTF8.GetBytes(value);

			using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
			{
				byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

				using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider()
				{
					Key = keys,
					Mode = CipherMode.ECB,
					Padding = PaddingMode.PKCS7
				})
				{
					ICryptoTransform transform = tripleDES.CreateEncryptor();
					byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
					string encryptedValue = Convert.ToBase64String(results, 0, results.Length);
					return encryptedValue;
				}
			}
		}

		public static string Decrypt(string encryptedValue, string key)
		{
			byte[] data = Convert.FromBase64String(encryptedValue);

			using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
			{
				byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

				using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider()
				{
					Key = keys,
					Mode = CipherMode.ECB,
					Padding = PaddingMode.PKCS7
				})
				{
					ICryptoTransform transform = tripleDES.CreateDecryptor();
					byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
					string decodedValue = UTF32Encoding.UTF8.GetString(results);
					return decodedValue;
				}
			}
		}
	}
}
