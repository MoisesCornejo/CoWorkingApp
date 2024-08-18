using System.Security.Cryptography;
using System.Text;

namespace CoWorkingApp.Data.Utils;

public static class EncryptData
{
    // creamos metodo para encriptar texto
    public static string EncryptText(string text)
    {
        // creamos variable de tipo SHA256 metodo de encriptacion con algoritmo SHA256
        // con el metodo create que nos permitira crear un objeto para realizar la transformacion
        using (var sha256 = SHA256.Create())
        {
            // guardamos la informacion en bytes utilizando el metodo ComputeHash
            // y transformamos la informacion en bytes utilizando el metodo GetBytes de Encoding.UTF8
            var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
            
            // convertimos los bytes a string, remplazamos - por nada y lo pasamos a minusculas
            var has = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return has;
        }
    }
}