using System;
using System.IO;
using System.Security.Cryptography;
namespace Hackerrank
{
    class CryptoEx
    {
        public static void C1(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("FileName Not Entered. Specify a filename to encrypt.");
                return;
            }
            string file = args[0];
            string tempfile = Path.GetTempFileName();
            // Open the file to read
            FileStream fsIn = File.Open(file, FileMode.Open, FileAccess.Read);
            FileStream fsOut = File.Open(tempfile, FileMode.Open, FileAccess.Write);
            SymmetricAlgorithm symm = new RijndaelManaged(); //creating an instance
            ICryptoTransform transform = symm.CreateEncryptor(); //and calling the CreateEncryptor method which //creates a symmetric encryptor object.
            CryptoStream cstream = new CryptoStream(fsOut, transform, CryptoStreamMode.Write);
            BinaryReader br = new BinaryReader(fsIn);
            cstream.Write(br.ReadBytes((int)fsIn.Length), 0, (int)fsIn.Length);
            cstream.FlushFinalBlock();
            cstream.Close();
            fsIn.Close();
            fsOut.Close();
            Console.WriteLine("Created Encrypted File {0}", tempfile);
            fsIn = File.Open(tempfile, FileMode.Open, FileAccess.Read);
            transform = symm.CreateDecryptor();
            cstream = new CryptoStream(fsIn, transform, CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cstream);
            Console.WriteLine("Decrypted the File: " + sr.ReadToEnd());
            fsIn.Close();
        }
    }
}