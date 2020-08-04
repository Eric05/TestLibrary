using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class Admin
    {
        public static bool IsAdmin { get; set; } = false;
        public const string Password = "Xr4ilOzQ4PCOq3aQ0qbuaQ==";
        public const string Name = "admin";

        public static bool CheckAdmin()
        {
            if (IsAdmin)
            {
                return true;
            }
            return false;
        }

        public static bool CheckCredentials(string name, string pass)
        {
            if (name == Admin.Name && Hash(pass) == Admin.Password)
            {
                Admin.IsAdmin = true;
                return true;
            }
            return false;
        }

        internal static string Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            var hashBytes = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
