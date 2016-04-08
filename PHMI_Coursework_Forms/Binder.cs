using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using System.Resources;

namespace FileBinder
{
    public static class Binder
        {
            private const string SPLITTER = @"[SPLITTER]";
        private static byte[] Secure(byte[] data)
        {
            using (var coder = new RijndaelManaged())
            {
                coder.IV = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7 };
                coder.Key = new byte[] { 7, 6, 5, 4, 3, 2, 1, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
                return coder.CreateEncryptor().TransformFinalBlock(data, 0, data.Length);
            }
        }

        private static byte[] UnSecure(byte[] data)
        {
            using (var coder = new RijndaelManaged())
            {
                coder.IV = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5, 6, 7 };
                coder.Key = new byte[] { 7, 6, 5, 4, 3, 2, 1, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
                return coder.CreateDecryptor().TransformFinalBlock(data, 0, data.Length);
            }
        }

        public static void BindFiles(string[] fileNames, string finalPath)
        {

            byte[] buffer = PHMI_Coursework_Forms.Properties.Resources.FileOpener;
            using (var file = File.Create(finalPath))
            {
                file.Write(buffer, 0, buffer.Length);
            }
            for(int i = 0; i < fileNames.Length; i++)
            {
                byte[] fileToWrite = Secure(File.ReadAllBytes(fileNames[i]));
                File.AppendAllText(finalPath, SPLITTER + fileNames[i].Split('\\').Last() + SPLITTER + Convert.ToBase64String(fileToWrite));  
            }
        }
    }
}
