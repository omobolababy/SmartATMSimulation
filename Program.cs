Console.WriteLine("Welcome to smart ATM");

int acctnumber = 1429823414;
int pin = 1445;
string acctname = "Barakah";
double balance = 5000.00;
double totaldeposits = 0;
int withdrawalcount = 0;


// LOGIN
Console.WriteLine("please enter your acctnumber: ");
int acctnumberEntry = int.Parse(Console.ReadLine());
if (acctnumberEntry != acctnumber)
{
    Console.WriteLine("Invalid account number.");
    return;
}

// PIN ENTRY, ALLOWING MAX 3 ATTEMPTS
int attempts = 0;
while (attempts < 3)
{
    Console.WriteLine("Enter PIN: ");
    int pinEntry = int.Parse(Console.ReadLine());

    if (pinEntry == pin)
    {
        Console.WriteLine("\nLogin successful! Welcome.\n");
        break;
    }

    attempts++;
    int remaining = 3 - attempts;
    if (remaining > 0)
        Console.WriteLine($"Incorrect PIN. {remaining} attempt remaining.");
}

if (attempts >= 3)
{
    Console.WriteLine("\nToo many incorrect attempts. Account locked.\n");
    return;
}

// menu option

    Console.WriteLine("\n--- Bank Menu ---\n1. Deposit\n2. Withdraw\n3. Check Balance\n4. Exit");
    Console.WriteLine("select option: ");
    int menuoption = int.Parse(Console.ReadLine());

    switch (menuoption)
    {
        case 1:  /// Deposits
            Console.WriteLine("Enter deposit amount: ");
            int depInput = int.Parse(Console.ReadLine());
            if ( depInput <= 0)
            {
                Console.WriteLine("Invalid amount. Must be a number greater than 0.");
                break;
            }

            balance += depInput;
            Console.WriteLine($"Successfully deposited {depInput}. New balance: {balance}");
            break;
        
        case 2:  /// Withdarawal

            while (withdrawalcount < 3)
            {
                Console.WriteLine("Enter withdrawal amount: ");
                int witInput = int.Parse(Console.ReadLine());

                if (witInput <= 0)
                {
                    Console.WriteLine("Invalid amount.");
                    continue; 
                }

                if (witInput > balance)
                {
                    Console.WriteLine($"Insufficient balance. Your balance is {balance}.");
                    continue; 
                }
                
                withdrawalcount++;
                balance -= witInput;

                Console.WriteLine($"Successfully withdrew {witInput}. New balance: {balance}");

                int witremaining = 3 - withdrawalcount;
                if (witremaining > 0)
                {
                    Console.WriteLine($"{witremaining} withdrawal(s) remaining this session.");
                }
            }

            Console.WriteLine("Withdrawal limit reached (3 per session).");
            break;
        
        
        case 3: ///// Check balance
            Console.WriteLine($"\n Hi {acctname} Your current balance is: {balance}.");
            break;
        
        
        case 4: /// Exit 
            Console.WriteLine("\nThank you for banking with us. Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }