using System;
using Auth;
using Logger;
using Operation;
using RabbitMQConnect;

namespace ChatApplication
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ILogger logger;
            String loggerType = "FileLogger";
            bool properData = true;
            bool loggedIn = true;
            int startInfo = 0;
            int operation = 0;
            string userName = "";
            string password;

            switch (loggerType)
            {
                case "FileLogger":
                    logger = new FileLogger(); 
                    break;
                case "Console":
                    logger = new TextLogger();
                    break;
                default:
                    logger = new TextLogger();
                    break;
            }
            LogManager logManager = new LogManager(logger);
            

            Console.WriteLine("To Log In Press 1");
            Console.WriteLine("To Sign Up Press 2");

            while (loggedIn)
            {
                while (properData)
                {
                    try
                    {
                        startInfo = Convert.ToInt32(Console.ReadLine());
                        properData = false;
                    }
                    catch (FormatException e)
                    {
                        logManager.Log(e.Message);
                        Console.WriteLine("Please Provide Proper Number In Input.");
                    }
                }
                switch (startInfo)
                {
                    case 1:
                        LogIn l = new LogIn();
                        Console.Write("User Name : ");
                        userName = Console.ReadLine();
                        Console.Write("Password : ");
                        password = Console.ReadLine();
                        if(l.findUser(userName, password))
                        {
                            loggedIn = false;
                        }
                        break;
                    case 2:
                        SignUp s = new SignUp();
                        Console.Write("User Name : ");
                        userName = Console.ReadLine();
                        Console.Write("Password : ");
                        password = Console.ReadLine();
                        s.createUser(userName, password);
                        break;
                    default:
                        Console.WriteLine("Please Press Between 1 Or 2");
                        break;
                }
                
            }
            Console.WriteLine("For showing all User press 1");
            operation = Convert.ToInt32(Console.ReadLine());
            switch (operation)
            {
                case 1:
                    Query q = new Query();
                    q.ShowActiveUser();
                    break;
            }

            //Console.Read();
            //Console.WriteLine(startInfo);
            logManager.Log("Successfully got info");
            Rabbit rb = new Rabbit();
            string p ="Hello";
            string[] stringArray = new string[2]{"saif", "sharif"};
            System.Console.WriteLine("Reciever");
            int reciver= 0;
            reciver= Convert.ToInt32(Console.ReadLine());
            while(p!="Quit"){
                p=Console.ReadLine();
                rb.Send(stringArray[reciver], p);
                //System.Console.WriteLine("Recieving Data");
                rb.Receive(userName);
            }
            
    //         Send("IDG","Hello World!");
    //  Receive("IDG");
    //  Console.ReadLine();


            Console.Read();

        }

    }
}
