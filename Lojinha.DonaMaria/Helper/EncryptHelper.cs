﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Lojinha.DonaMaria.Helper
{
    public class EncryptHelper
    {
        public static string EncryptPassword(string senha)
        {
            var data = Encoding.ASCII.GetBytes(senha);
            data = new SHA256Managed().ComputeHash(data);
            return Convert.ToBase64String(data);
        }
    }
}
