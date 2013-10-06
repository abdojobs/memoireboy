using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace MemoireBoy2013
{
    public static class Encrypt
    {

        internal static string GENERATEUR_DE_CLES()
        {
            trip = new TripleDESCryptoServiceProvider();
            trip.GenerateKey();

            return Convert.ToBase64String(trip.Key);

        }

        private static readonly string cle = "4IiBNTAKTAngbRkmQJssWbRgVlylkZJ1";
        private static readonly string cleIV = "UgYebfQv+N0=";
        static TripleDESCryptoServiceProvider trip;


        public static string EncryptString(string Value)
        {
            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;

            if (trip == null)
            {
                trip = new TripleDESCryptoServiceProvider();
                trip.Key = Convert.FromBase64String(cle);
                trip.IV = Convert.FromBase64String(cleIV);
            }


            ct = trip.CreateEncryptor(trip.Key, trip.IV);

            byt = Encoding.UTF8.GetBytes(Value);

            ms = new MemoryStream();
            cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
            cs.Write(byt, 0, byt.Length);
            cs.FlushFinalBlock();

            cs.Close();

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string DecryptString(string Value)
        {

            ICryptoTransform ct;
            MemoryStream ms;
            CryptoStream cs;
            byte[] byt;

            try
            {
                if (trip == null)
                {
                    trip = new TripleDESCryptoServiceProvider();
                    trip.Key = Convert.FromBase64String(cle);
                    trip.IV = Convert.FromBase64String(cleIV);
                }

                ct = trip.CreateDecryptor(trip.Key, trip.IV);

                byt = Convert.FromBase64String(Value);

                ms = new MemoryStream();
                cs = new CryptoStream(ms, ct, CryptoStreamMode.Write);
                cs.Write(byt, 0, byt.Length);
                cs.FlushFinalBlock();

                cs.Close();
                return Encoding.UTF8.GetString(ms.ToArray());
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return "";
            }

        }

    }
}
