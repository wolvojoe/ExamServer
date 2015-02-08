using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Data;
using System.Text;

/// <summary>
/// Summary description for Hash
/// </summary>
public class Hash
{
	public Hash()
	{

	}

    public string HashString(string input)
    {
        string hash = null;
        string source = input.Trim();
        using (MD5 md5Hash = MD5.Create())
        {
            hash = GetMd5Hash(md5Hash, source);
        }

        return hash;
    }

    private string GetMd5Hash(MD5 md5Hash, string input)
    {

        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        StringBuilder sBuilder = new StringBuilder();

        int i = 0;
        for (i = 0; i <= data.Length - 1; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        return sBuilder.ToString();

    }


}