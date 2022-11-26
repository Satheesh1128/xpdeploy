using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;



/// <summary>
/// Summary description for CommonClass
/// </summary>
public class CommonClass
{

    public class CommonOutput
    {

    }

    public class SQLConnectionName
    {
        public static string conStr = ConfigurationManager.ConnectionStrings["_ConnectionString"].ConnectionString;

    }

    public class EnyDecrypt
    {
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "SATH1128KATTAMPATTI";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "SATH1128KATTAMPATTI";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }



    }

    public class RoleAction
    {
        public static string SP = "RolePermission_Select";
        public static string Edit = "Edit";
        public static string Add = "Add";
        public static string Delete = "Delete";
        public static string Save = "Save";
    }

    public class RolePermission
    {
        public static string RoleAction(string RoleAction)
        {
            return RoleAction;
        }

    }

}