using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

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
        List<char> requiredChars = new List<char>();
        string charPool = "";
        
        if (uppercase) { charPool += UppercaseChars; requiredChars.Add(UppercaseChars[_random.Next(UppercaseChars.Length)]); }
        if (lowercase) { charPool += LowercaseChars; requiredChars.Add(LowercaseChars[_random.Next(LowercaseChars.Length)]); }
        if (numbers) { charPool += NumberChars; requiredChars.Add(NumberChars[_random.Next(NumberChars.Length)]); }
        if (symbols) { charPool += SymbolChars; requiredChars.Add(SymbolChars[_random.Next(SymbolChars.Length)]); }

        if (charPool.Length == 0)
        {
            throw new ArgumentException("Must select at least one character type");
        }
        
        char[] password = new char[length];

        for (int i = requiredChars.Count; i < length ;i++)
        {
            password[i] = charPool[_random.Next(charPool.Length)];
        }
        
        return new string(password.OrderBy(x => _random.Next()).ToArray());
    }

    public string TestPassword(string password)
    {
        int score = 0;
        List<string> feedback = new List<string>();
        
        // Length check
        if (password.Length < 8)
        {
            feedback.Add("❌ Password must be at least 8 characters long");    
        } 
        else if (password.Length >= 8)
        {
            score++;
            if (password.Length >= 12) score++;
            if (password.Length >= 16) score++;
        }
        
        // Lowercase check
        if (Regex.IsMatch(password, @"[a-z]"))
        {
            score++;
            feedback.Add("✅ Contains lowercase letters");
        }
        else
        {
            feedback.Add("❌ Missing lowercase letters");
        }
        
        // Uppercase check
        if (Regex.IsMatch(password, @"[A-Z]"))
        {
            score++;
            feedback.Add("✅ Contains uppercase letters");
        }
        else
        {
            feedback.Add("❌ Missing uppercase letters");
        }
        
        // Number check
        if (Regex.IsMatch(password, @"\d"))
        {
            score++;
            feedback.Add("✅ Contains numbers");
        }
        else
        {
            feedback.Add("❌ Missing numbers");
        }
        
        // Symbol check
        if (Regex.IsMatch(password, @"[!@#$%^&*()_+\-=\[\]{}|;:,.<>?]"))
        {
            score++;
            feedback.Add("✅ Contains symbols");
        }
        else
        {
            feedback.Add("❌ Missing symbols");
        }
        
        // Check for patterns
        if (Regex.IsMatch(password, @"(.)\1{2,}"))
        {
            score--;
            feedback.Add("❌ Contains repeated characters");
        }
        
        // Sequential numbers
        if (Regex.IsMatch(password, @"(012|123|234|345|456|567|678|789|890)"))
        {
            score--;
            feedback.Add("❌ Contains sequential numbers");
        }

        string strength = score switch
        {
            <= 2 => "[!!] Very Weak",
            3 => "[!] Weak",
            4 => "[-] Moderate",
            5 => "[+] Strong",
            >= 6 => "[++] Very Strong",
        };
        
        return $"{strength}\n{string.Join("\n", feedback)}";
    }
}