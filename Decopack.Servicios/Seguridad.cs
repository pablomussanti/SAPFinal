using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Decopack.Servicios
{

    public class Seguridad
    {
        public static string GenerarSHA(string sCadena)
        {
            System.Text.UnicodeEncoding ueCodigo = new System.Text.UnicodeEncoding();

            byte[] ByteSourceText = ueCodigo.GetBytes(sCadena);

            SHA1CryptoServiceProvider SHA = new SHA1CryptoServiceProvider();

            byte[] ByteHash = SHA.ComputeHash(ueCodigo.GetBytes(sCadena));

            return Convert.ToBase64String(ByteHash);
        }

        //public static string Encripta(string Pass, string user)
        //{
        //    string Clave;
        //    int i;
        //    string Pass2;
        //    string CAR;
        //    string Codigo;
        //    Clave = user;
        //    Pass2 = "";
        //    for (i = 1; i <= Pass.Length; i++)
        //    {
        //        CAR = Pass.Substring( i, 1);
        //        Codigo = Strings.Mid(Clave, ((i - 1) % Strings.Len(Clave)) + 1, 1);
        //        Pass2 = Pass2 + Strings.Right("0" + Conversion.Hex(Strings.Asc(Codigo) ^ Strings.Asc(CAR)), 2);
        //    }
            
        //    return Pass2;
        //}

        //public static string DesEncripta(string Pass, string user)
        //{
        //    string Clave;
        //    int i;
        //    string Pass2;
        //    string CAR;
        //    string Codigo;
        //    int j;

        //    Clave = user;
        //    Pass2 = "";
        //    j = 1;
        //    for (i = 1; i <= Pass.Length; i += 2)
        //    {
        //        CAR = Pass.Substring( i, 2);
        //        Codigo = Substring(Clave, ((j - 1) % Clave.Length) + 1, 1);
        //        Pass2 = Pass2 + Strings.Chr(Strings.Asc(Codigo) ^ Conversion.Val("&h" + CAR));
        //        j = j + 1;
        //    }
        //    return Pass2;
        //}
    }

}
