using System.Security.Cryptography;
using System.Text;

namespace Identity.CrossCutting.Helpers;

public static class Crypt
{
    public static string Encrypt(string key)
    {
        using MD5 hash = MD5.Create();
        return Encrypt(hash, key);
    }

    private static string Encrypt(MD5 hash, string key)
    {
        byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(key));

        StringBuilder sBuilder = new StringBuilder();

        foreach (var t in data)
        {
            sBuilder.Append(t.ToString("x2"));
        }

        return sBuilder.ToString();
    }

    public static bool Comparer(string keyOrinal, string key)
    {
        using MD5 hash = MD5.Create();
        string keyToVerify = Encrypt(hash, key);

        if (ComparerKeys(keyOrinal, keyToVerify))
            return true;
        else
            return false;
    }

    private static bool ComparerKeys(string keyOrinal, string keyToVerify)
    {
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        return 0 == comparer.Compare(keyOrinal, keyToVerify);
    }
}