using System.Security.Cryptography;
using System.Text;

namespace PracticeTracker.Services.Tools;

public static class PasswordTools
{
    public static string GetPasswordHash(string password)
    {
        Byte[] bytes = Encoding.Unicode.GetBytes(password);
        MD5CryptoServiceProvider cryptoService = new MD5CryptoServiceProvider();
        Byte[] byteHash = cryptoService.ComputeHash(bytes);
        String hash = String.Empty;

        foreach (Byte b in byteHash)
            hash += String.Format("{0:x2}", b);

        return hash;
    }
}