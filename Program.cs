using System;

namespace PasswordGenerator;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var generator = new PasswordGenerator();
        #nullable enable
        string? checkPassword = null;
        
        // Basic options
        int length = 16;
        bool uppercase = false;
        bool lowercase = false;
        bool numbers = false;
        bool symbols  = false;

        // Argument check
        for (int i = 0; i < args.Length; i++)
        {
            string arg = args[i];
            
            // Length
            if (arg == "--length" || arg == "-L")
            {
                length = Convert.ToInt32(args[i + 1]);
                i++;
            }
            
            // Boolean flags
            else if (arg == "--uppercase" || arg == "-u")
            {
                uppercase = true;
            } else if (arg == "--lowercase" || arg == "-l")
            {
                lowercase = true;
            } else if  (arg == "--numbers" || arg == "-n")
            {
                numbers = true;
            } else if (arg == "--symbols" || arg == "-s")
            {
                symbols = true;
            } else if (arg == "--all")
            {
                uppercase = lowercase = numbers = symbols = true;
            }
            
            
            // Password strength check
            else if (arg == "--check")
            {
                if (i + 1 < args.Length)
                {
                    checkPassword = args[i + 1];
                    i++;
                }
            }
            
            else if (arg == "--help" || arg == "-h")
            {
                Console.WriteLine("Usage: PasswordGenerator [options]");
                Console.WriteLine("Options:");
                Console.WriteLine("  -L, --length <n>    Password length (default: 16)");
                Console.WriteLine("  -u, --uppercase     Include uppercase letters");
                Console.WriteLine("  -l, --lowercase     Include lowercase letters");
                Console.WriteLine("  -n, --numbers       Include numbers");
                Console.WriteLine("  -s, --symbols       Include symbols");
                Console.WriteLine("  --all               Include all character types");
                Console.WriteLine("  --check <password>  Check password strength");
                return;
            }
        }
        if (!string.IsNullOrEmpty(checkPassword))
        {
            string result = generator.TestPassword(checkPassword);
            Console.WriteLine(result);
            return;
        }
        
        try
        {
            string password = generator.Generate(length, uppercase, lowercase, numbers, symbols);
            Console.WriteLine(password);
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error: {ex.Message}");
            Console.ResetColor();
            return;
        }
    }
}