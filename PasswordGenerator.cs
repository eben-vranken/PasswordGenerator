namespace PasswordGenerator;

public class PasswordGenerator
{    
    private static readonly Random _random = new Random();
    
    private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
    private const string NumberChars = "0123456789";
    private const string SymbolChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";
    
    public string Generate(int length, bool uppercase, bool lowercase, bool numbers, bool symbols)
    {
        string charPool = "";

        if (uppercase) charPool += UppercaseChars;
        if (lowercase) charPool += LowercaseChars;
        if (numbers) charPool += NumberChars;
        if (symbols) charPool += SymbolChars;

        if (charPool.Length == 0)
        {
            throw new ArgumentException("Must select at least one character type");
        }
        
        char[] password = new char[length];

        for (int i = 0; i < length; i++)
        {
            password[i] = charPool[_random.Next(charPool.Length)];
        }
        
        return new string(password);
    }
}