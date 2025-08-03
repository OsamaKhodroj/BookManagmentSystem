namespace LibrarySystem.Infrastctures;

public class Encryption
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string Hash(string password)
    {
        if (string.IsNullOrEmpty(password)) 
            throw new ArgumentNullException("password is required");

        var result = BCrypt.Net.BCrypt.HashPassword(password);
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="password"></param>
    /// <param name="hashedPassword"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool Verify(string password, string hashedPassword)
    {
        if (string.IsNullOrEmpty(password)) 
            throw new ArgumentNullException("password is required");

        if (string.IsNullOrEmpty(hashedPassword))
            throw new ArgumentNullException("hashedPassword is required");

        var result = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        return result;
    }
}
