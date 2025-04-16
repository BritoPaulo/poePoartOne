using System;
using System.Media;
using System.Threading;

class CybersecurityChatbot
{
    // Console color scheme used for different types of messages
    private static readonly ConsoleColor titleColor = ConsoleColor.DarkBlue;
    private static readonly ConsoleColor botColor = ConsoleColor.Green;
    private static readonly ConsoleColor userColor = ConsoleColor.White;
    private static readonly ConsoleColor warningColor = ConsoleColor.Red;
    private static readonly ConsoleColor infoColor = ConsoleColor.Cyan;
    private static readonly ConsoleColor accentColor = ConsoleColor.Yellow;
    private static readonly ConsoleColor borderColor = ConsoleColor.Magenta;

    static void Main(string[] args)
    {
        // Set up console properties and initial greeting
        InitializeChatbot();

        // Play welcome audio message
        PlayWelcomeMessage();

        // Display decorative welcome screen in console
        DisplayWelcomeScreen();

        // Ask for user's name
        string userName = GetUserName();

        // Start the chatbot conversation
        RunChatbot(userName);
    }

    static void InitializeChatbot()
    {
        // Set the console window title and prepare the interface
        Console.Title = " Cybersecurity Awareness Assistant";
        Console.Clear();
        Console.CursorVisible = false;
    }

    static void PlayWelcomeMessage()
    {
        // Path to welcome audio file
        string filePath = @"C:\Users\lab_services_student\Documents\Group2_Part1\poePoartOne\poePoartOne\audio\Hello welcome to the.wav ";
        try
        {
            SoundPlayer player = new SoundPlayer(filePath);
            player.PlaySync(); // Plays audio synchronously before continuing
        }
        catch (Exception ex)
        {
            // Display error message if audio fails
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Failed to play audio: " + ex.Message);
            Console.ResetColor();
        }
    }

    static void DisplayWelcomeScreen()
    {
        // Print stylized welcome banner to console
        Console.ForegroundColor = borderColor;
        Console.WriteLine("\n╔══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                                              ║");

        Console.ForegroundColor = titleColor;
        Console.WriteLine("║           █▀▀ █▀▀ █▀▄ █▀▀ █▀█ ▄▀█ █▀▀ █▀▀ ▀█▀ █▀█ █▀█         ║");
        Console.WriteLine("║           █▄█ ██▄ █▄▀ ██▄ █▀▄ █▀█ █▄▄ ██▄  █  █▄█ █▀▄         ║");

        Console.ForegroundColor = accentColor;
        Console.WriteLine("║                                                              ║");
        Console.WriteLine("║        Your Personal Guide to Online Safety in South Africa  ║");

        Console.ForegroundColor = borderColor;
        Console.WriteLine("║                                                              ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");

        Console.ResetColor();

        // Provide short description of assistant
        Console.ForegroundColor = infoColor;
        Console.WriteLine("\n  This assistant will help you identify and protect against");
        Console.WriteLine("  common cyber threats like phishing, malware, and scams.");
        Console.ResetColor();
    }

    static string GetUserName()
    {
        // Prompt user to enter their name for personalization
        Console.ForegroundColor = accentColor;
        Console.Write("\n  To personalize your experience, please tell me your name: ");
        Console.ForegroundColor = userColor;

        string name = Console.ReadLine()?.Trim() ?? "";

        // Keep asking if input is empty
        while (string.IsNullOrEmpty(name))
        {
            Console.ForegroundColor = warningColor;
            Console.Write("  Please enter your name to continue: ");
            Console.ForegroundColor = userColor;
            name = Console.ReadLine()?.Trim() ?? "";
        }

        // Greet user by name
        Console.ForegroundColor = botColor;
        Console.WriteLine($"\n  Welcome, {name}! Let's make your online experience safer.");
        Console.ResetColor();

        return name;
    }

    static void RunChatbot(string userName)
    {
        // Show list of available topics
        DisplayHelpMenu();

        while (true)
        {
            // Prompt user for input
            Console.ForegroundColor = userColor;
            Console.Write($"\n  {userName} » ");
            string input = Console.ReadLine()?.Trim().ToLower() ?? "";
            Console.ResetColor();

            // Handle empty input
            if (string.IsNullOrEmpty(input))
            {
                Console.ForegroundColor = warningColor;
                Console.WriteLine("  Please enter your question or type 'help' for options");
                Console.ResetColor();
                continue;
            }

            // Exit condition
            if (input.Contains("bye") || input.Contains("exit"))
            {
                Console.ForegroundColor = botColor;
                Console.WriteLine($"  Stay safe online, {userName}! Remember to always verify ");
                Console.WriteLine("  unexpected requests for personal information.");
                Console.ResetColor();
                Thread.Sleep(3000); // Pause before exiting
                break;
            }

            // Re-display help menu
            if (input.Contains("help"))
            {
                DisplayHelpMenu();
                continue;
            }

            // Generate and display chatbot's response
            string response = GenerateResponse(input, userName);
            TypewriterEffect(response, botColor);
        }
    }

    static void DisplayHelpMenu()
    {
        // Show menu with supported cybersecurity topics
        Console.ForegroundColor = accentColor;
        Console.WriteLine("\n  ┌──────────────────────────────────────────────────┐");
        Console.WriteLine("  │             CYBERSECURITY TOPICS MENU           │");
        Console.WriteLine("  ├──────────────────────────────────────────────────┤");
        Console.ForegroundColor = infoColor;
        Console.WriteLine("  │  • Passwords       - Secure password creation    │"); 
        Console.WriteLine("  │  • Phishing        - Spotting scam messages      │");
        Console.WriteLine("  │  • Browsing       - Safe internet practices     │");
        Console.WriteLine("  │  • Social Media    - Protecting your profiles    │");
        Console.WriteLine("  │  • Banking        - Online financial safety     │");
        Console.ForegroundColor = accentColor;
        Console.WriteLine("  ├──────────────────────────────────────────────────┤");
        Console.WriteLine("  │  Type 'help' to show this menu anytime          │");
        Console.WriteLine("  │  Type 'bye' to exit the conversation            │");
        Console.WriteLine("  └──────────────────────────────────────────────────┘");
        Console.ResetColor();
    }

    static string GenerateResponse(string input, string userName)
    {
        // Check user input for keywords and return relevant cybersecurity tip

        if (input.Contains("how are you"))
            return "I'm functioning optimally and ready to discuss cybersecurity!";

        if (input.Contains("purpose") || input.Contains("what do you do"))
            return "I educate South Africans about digital threats and protection methods.";

        if (input.Contains("password")) 
            return " Strong passwords should be:\n  - Minimum 12 characters\n  - Mix of upper/lower case, numbers, symbols\n  - Unique for each account\nConsider using a password manager like Bitwarden or LastPass.";

        if (input.Contains("phishing"))
            return " Phishing red flags:\n  - Urgent/threatening language\n  - Generic greetings ('Dear Customer')\n  - Suspicious sender addresses\n  - Requests for login credentials\nAlways verify through official channels.";

        if (input.Contains("browsing") || input.Contains("internet"))
            return " Safe browsing tips:\n  - Look for 🔒 and 'https://' in URLs\n  - Avoid public WiFi for banking\n  - Keep browsers/plugins updated\n  - Use uBlock Origin ad-blocker";

        if (input.Contains("bank"))
            return " Online banking safety:\n  - Never share OTPs or PINs\n  - Use official bank apps only\n  - Enable biometric authentication\n  - Monitor transactions weekly";

        if (input.Contains("social media"))
            return " Social media protection:\n  - Review privacy settings\n  - Be wary of 'too good to be true' offers\n  - Don't overshare personal info\n  - Enable two-factor authentication";

        if (input.Contains("hello") || input.Contains("hi"))
            return $"Hello {userName}! Which cybersecurity topic interests you today?";

        if (input.Contains("thank"))
            return $"You're welcome, {userName}! Cybersecurity awareness is the first line of defense.";

        // Default response if input doesn't match any known topic
        return "I specialize in South African cybersecurity concerns. Please ask about:\n- Passwords\n- Phishing\n- Safe browsing\n- Social media\n- Online banking\nOr type 'help' for the full menu.";
    }

    static void TypewriterEffect(string text, ConsoleColor color)
    {
        // Display chatbot's reply with a typewriter-like text effect
        Console.ForegroundColor = color;
        Console.Write("  Assistant » ");

        bool newLine = text.Contains("\n");
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(newLine ? 10 : 20); // Slower for multiline text
            if (Console.KeyAvailable) break; // Skip animation if key pressed
        }

        Console.WriteLine();
        Console.ResetColor();
    }
}
