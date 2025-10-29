namespace PasswordGenerator;

class Program
{
    static void Main(string[] args)
    {
        var generator = new PasswordGenerator();
        
        // Basic options
        int length = 16;
        bool uppercase = false;
        bool lowercase = false;
        bool numbers = false;
        bool symbols  = false;
        
        // Advanced options
        // char[] excludeList = new[] {};

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
        }
        
        string password = generator.Generate(length, uppercase, lowercase, numbers, symbols);

        Console.WriteLine(password);
    }
}