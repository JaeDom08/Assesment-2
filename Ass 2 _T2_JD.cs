using System;
using System.Collections.Generic; //for list

class Program
{
    static List<User> users = new List<User>(); //Create a list to store users
    //other thing is that this code does not store user in a database so all data will be lost when it is closed
    static void TryOutUser() //Try out user 
    {
        users.Add(new User 
        { 
            username = "Joe.Doe", 
            password = "Password123", 
            email = "joe.doe@example.com", 
            age = 30, 
            phone = 1234567890 
        });
    }

    public static void Main(string[] args)
    {
        TryOutUser(); //Calling the method to add user and call the list as well
        MainScreen(); //Main screen
    }

    public static void MainScreen()
    {
        bool mainScreen = true; // Keep true until User want to close the software

        while (mainScreen)
        {
            Console.Clear();
            Console.WriteLine("====== MAIN SCREEN ======");
            Console.WriteLine("\nWelcome to the main screen\n");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Signup");
            Console.WriteLine("3. Exit");
            Console.WriteLine("==========================\n");
            Console.Write("Select an option: ");

            if (!int.TryParse(Console.ReadLine(), out int choice)) continue; 
            /*if input is valid and it will be stored if not ask it goes back to start to ask for input again as not to crash the console.
            it does work with int choice = Conole.readline() method but it will need condition like if and while so better to use this method 
            with switch statement */

            switch (choice) //switch is better than a while loop it is more efficient and easier to read from W3Schools
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Signup();
                    break;
                case 3:
                    Console.WriteLine("Exciting... Thank you for using the software");
                    mainScreen = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    continue; 
            }
        }
    }

    public static void Login() //Login
    {
        Console.Clear(); 
        Console.WriteLine("=== LOGIN SCREEN ===\n");
        Console.Write("Enter username: ");
        string usernameInput = Console.ReadLine();

        //check to find username in the list
        User foundUser = users.Find(u => u.username == usernameInput);

        if (foundUser != null) //condition if user is found
        {
            int verify = 0;
            int finalAttempt = 5;
            while (verify < 3 && finalAttempt > 0) //if attempts is less than 3 continue but once it final attempts reach 5 it breaks
            {
                Console.Write($"Enter password ({3 - verify} left to verify): "); //to display how more times to verify
                string passwordInput = Console.ReadLine();

                if (foundUser.password == passwordInput)
                {
                    Console.WriteLine("Correct password!");
                    verify++; //increases attempt by 1
                }
                else
                {
                    verify = 0; //reset verification
                    finalAttempt--;
                    Console.WriteLine("Incorrect password.");
                }
            }

            if (finalAttempt == 0)
                Console.WriteLine("Too many failed attempts. Returning to menu.\n");

            else if (verify == 3)
            {
                Console.WriteLine("Login successful!");
                DisplayUserInfo(foundUser); //display user info if login successful
            }
        }
        else
        {
            Console.WriteLine("Username not found.");
            //just go back to main menu if username not found
        }
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static void Signup()
    {
        User newUser = new User(); //Create a new user object to store the new user's information
        Console.Clear();
        Console.WriteLine("\n=== SIGNUP SCREEN ===");

        while (true) //keeping the user here until enter valid
        {
            Console.Write("\n\nEnter username: ");
            string IUsername = Console.ReadLine();

            if (isEmpty(IUsername)) //if empty 
            {
                Console.WriteLine("Username cannot be empty. Please try again.");
                
            }
            else if (users.Exists(u => u.username == IUsername))
            {
                Console.WriteLine("Username already exists. Please choose a different username.");
            }
            else
            {
                newUser.username = IUsername;
                break;
            }
        }

        while (true)
        {
            Console.Write("Enter password: ");
            string IPassword = Console.ReadLine();

            if (isEmpty(IPassword))
            {
                Console.WriteLine("Password cannot be empty. Please try again.\n");
            }
            else
            {
                newUser.password = IPassword;
                break;
            }
        }

        while (true)
        {
            Console.Write("Enter email: ");
            string IEmail = Console.ReadLine();

            if (isEmpty(IEmail) || !IEmail.Contains("@") || !IEmail.Contains("."))
            {
                Console.WriteLine("Email cannot be empty and must contain '@' and '.'. Please try again.\n");
            }
            else
            {
                newUser.email = IEmail;
                break;
            }
        }

        while (true)
        {
            Console.Write("Enter age: ");
            string IAge = Console.ReadLine();

            if (!int.TryParse(IAge, out int age) || isEmpty(age))
            {
                Console.WriteLine("Age must be a valid number greater than 0. Please try again.\n");
            }
            else
            {
                newUser.age = age;
                break;
            }
        }

        while (true)
        {
            Console.Write("Enter phone number: ");
            string IPhone = Console.ReadLine();

            if (!long.TryParse(IPhone, out long phone) || isEmpty(phone) || IPhone.Length < 10)
            {
                Console.WriteLine("Phone number must be a valid number with at least 10 digits. Please try again.\n");
            }
            else 
            {
                newUser.phone = phone;
                break;
            }
        }

        users.Add(newUser); //Add the new user to the list of users
        Console.WriteLine("\nSignup successful! You can now log in with your new credentials.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
        //then back to main menu
        
    }  

    public static void DisplayUserInfo(User u)
    {
        Console.WriteLine("\n--- USER INFO ---");
        Console.WriteLine($"Username: {u.username}");
        Console.WriteLine($"Email:    {u.email}");
        Console.WriteLine($"Age:      {u.age}");
        Console.WriteLine($"Phone:    {u.phone}");
        Console.WriteLine("-----------------");
    }

    public static bool isEmpty(string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }

    public static bool isEmpty(long num)
    {
        return num <= 0; // For phone number, we can consider 0 or negative as invalid input
    }

    public static bool isEmpty(int num)
    {
        return num <= 0; // For age, we can consider 0 as invalid input
    }
}

class User 
{
    public string username;
    public string password;
    public string email;
    public int age;
    public long phone; // long is safer for 10+ digit numbers
}