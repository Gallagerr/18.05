using DevOne.Security.Cryptography.BCrypt;

namespace Services
{
  public class DataEncryptor
  {
    public static string HashPassword(string password)
    {
      return BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt());
    }

    public static bool IsValidPassword(string candidatePassword, string hashedPassword)
    {
      return BCryptHelper.CheckPassword(candidatePassword, hashedPassword);
    }
  }
}
