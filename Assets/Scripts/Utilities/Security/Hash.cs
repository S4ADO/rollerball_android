using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System;

public class Hash : MonoBehaviour
{
	public static string hashString(string strToHash)
	{
		string secretKey = GameObject.Find("LoginButton").GetComponent<Login>().secretKey;
		StringBuilder final = new StringBuilder();
		MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

		byte[] bytes = ASCIIEncoding.Default.GetBytes(strToHash + secretKey);
		byte[] strHash = md5.ComputeHash(bytes);
		for (int i = 0; i < strHash.Length; i++)
		{
			final.Append(strHash[i].ToString("x2"));
		}

		return final.ToString();
	}

	public static string ShaHash(string _password)
	{
		SHA512 sha512 = new System.Security.Cryptography.SHA512Managed();
		byte[] sha512Bytes = System.Text.Encoding.Default.GetBytes(_password);
		byte[] cryString = sha512.ComputeHash(sha512Bytes);
		string hashedPwd = string.Empty;
		for (int i = 0; i < cryString.Length; i++)
		{
			hashedPwd += cryString[i].ToString("X2");
		}
		return hashedPwd.ToLower();
	}
}