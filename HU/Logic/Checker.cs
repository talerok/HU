using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using HU.Models;

namespace HU.Logic
{
    public class Checker
    {
        private string Salt;
        private SHA256 sha = new SHA256Managed();
        public string Get(Person p)
        {
            byte[] data = new UTF8Encoding().GetBytes(p.Login + p.Password + Salt);
            
            return BitConverter.ToString(sha.ComputeHash(data));
        }

        public bool Check(Person p, string hash)
        {
            return Get(p) == hash;
        }

        public Checker(string slt)
        {
            Salt = slt;
        }
    }
}