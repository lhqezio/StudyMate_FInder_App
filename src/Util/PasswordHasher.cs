using System.Security.Cryptography;
namespace StudyMate;
public static class PasswordHasher
{
    private const int SaltSize = 16;
    private const int HashSize = 32;
    private const int Iterations = 1000;

    public static string HashPassword(string password)
    {
        // Generate a random salt
        byte[] salt = new byte[SaltSize];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Compute the hash using PBKDF2 with HMAC-SHA256
        byte[] hash = PBKDF2(password, salt, Iterations, HashSize);

        // Combine the salt and hash into a single string
        return $"{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        System.Console.WriteLine($"Password: {password}");
        System.Console.WriteLine($"Hashed Password: {hashedPassword}");
        // Extract the salt and hash from the hashed password string
        string[] parts = hashedPassword.Split('.');
        if (parts.Length != 2)
        {
            return false;
        }
        byte[] salt = Convert.FromBase64String(parts[0]);
        byte[] hash = Convert.FromBase64String(parts[1]);

        // Compute the hash of the supplied password using the same salt and iterations
        byte[] computedHash = PBKDF2(password, salt, Iterations, HashSize);
        System.Console.WriteLine($"Computed Hash: {Convert.ToBase64String(computedHash)}");
        System.Console.WriteLine($"Stored Hash: {Convert.ToBase64String(hash)}");

        // Compare the computed hash with the stored hash
        return SlowEquals(hash, computedHash);
    }

    private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputSize)
    {
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
        {
            return pbkdf2.GetBytes(outputSize);
        }
    }

    private static bool SlowEquals(byte[] a, byte[] b)
    {
        uint diff = (uint)a.Length ^ (uint)b.Length;
        for (int i = 0; i < a.Length && i < b.Length; i++)
        {
            diff |= (uint)(a[i] ^ b[i]);
        }
        return diff == 0;
    }
}

