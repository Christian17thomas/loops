using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("1. Smart Checkout System");
            Console.WriteLine("2. Password Cracker");
            Console.WriteLine("3. Rocket Launch Pad");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    SmartCheckout();
                    break;
                case "2":
                    PasswordCracker();
                    break;
                case "3":
                    RocketLaunchPad();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose 1, 2, 3, or 4.");
                    break;
            }
        }
    }

    // ---------- 1. Smart Checkout System (while loop) ----------
    static void SmartCheckout()
    {
        int totalPrice = 0;
        int itemPrice;
        int managerPin;
        const int CORRECT_PIN = 1234;
        const int HIGH_VALUE_LIMIT = 100;

        Console.WriteLine("--- Smart Checkout System ---");
        Console.WriteLine("Please enter the item price (enter 0 to finish transaction).");

        // Read the first price, then loop until the sentinel value 0 is entered
        Console.Write("Scan item price: $");
        itemPrice = Convert.ToInt32(Console.ReadLine());

        while (itemPrice != 0)
        {
            if (itemPrice >= HIGH_VALUE_LIMIT)
            {
                Console.WriteLine("   ! Manager approval required for high-value item ($100+) !");
                Console.Write("   Manager, please enter override PIN: ");
                managerPin = Convert.ToInt32(Console.ReadLine());

                if (managerPin == CORRECT_PIN)
                {
                    Console.WriteLine("   Correct PIN. Item is approved and added.");
                    totalPrice += itemPrice;
                }
                else
                {
                    Console.WriteLine("   Incorrect PIN. Item is rejected and not added.");
                }
            }
            else
            {
                totalPrice += itemPrice;
            }

            // Ask for the next item (this keeps the loop going)
            Console.Write("Scan item price: $");
            itemPrice = Convert.ToInt32(Console.ReadLine());
        }

        Console.WriteLine("------------------------------");
        Console.WriteLine("Your Receipt Total: $" + totalPrice);
        Console.WriteLine("Thank you for shopping with us!");
    }

    // ---------- 2. Password Cracker (do-while loop) ----------
    static void PasswordCracker()
    {
        const string CORRECT_PASSWORD = "mis3013isgreat!";
        const int maxAttempts = 3;

        int attemptsUsed = 0;
        bool isAccessGranted = false;
        string guess;

        Console.WriteLine("--- Password Cracker ---");

        // do-while: the user is always asked for a password at least once
        do
        {
            Console.Write("Please enter the security password: ");
            guess = Console.ReadLine();
            attemptsUsed++;

            if (guess == CORRECT_PASSWORD)
            {
                isAccessGranted = true;
            }
            else
            {
                int attemptsLeft = maxAttempts - attemptsUsed;

                // No "remaining" message after the final failed attempt
                if (attemptsLeft > 0)
                {
                    Console.WriteLine("Incorrect. You have " + attemptsLeft + " attempts remaining.");
                }
            }
        } while (!isAccessGranted && attemptsUsed < maxAttempts);

        Console.WriteLine();
        if (isAccessGranted)
        {
            Console.WriteLine("Access Granted.");
        }
        else
        {
            Console.WriteLine("Security Lockdown Initiated!");
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey();
    }

    // ---------- 3. Rocket Launch Pad (for loops) ----------
    static void RocketLaunchPad()
    {
        Console.WriteLine("---  Launchpad ---");

        // Countdown: start at 10, go down by 1, stop before 0
        for (int i = 10; i > 0; i--)
        {
            Console.WriteLine(i + "...");

            // Status checks
            if (i == 7)
            {
                Console.WriteLine("[SYSTEM]: Checking fuel levels... OK.");
            }
            else if (i == 4)
            {
                Console.WriteLine("[SYSTEM]: Oxygen pressure... stabilized.");
            }
            else if (i == 1)
            {
                Console.WriteLine("[SYSTEM]: Ignition sequence... START.");
            }

            System.Threading.Thread.Sleep(500); // short pause so it feels like a countdown
        }

        // Blast off, then draw the rocket
        Console.WriteLine("0 - BLAST OFF!");
        Console.WriteLine(" | ");
        Console.WriteLine(" / \\ ");
        Console.WriteLine(" / _ \\");
        Console.WriteLine(" | |");
        Console.WriteLine(" | (R) |");
        Console.WriteLine(" |_____|");
        Console.WriteLine(" V V V ");

        // Animation: 20 empty lines push the rocket up and off the screen
        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine();
            System.Threading.Thread.Sleep(100); // 0.1 second pause
        }
    }
}