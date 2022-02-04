List<DZ1.Hall> halls = new List<DZ1.Hall>();
List<DZ1.User> users = new List<DZ1.User>();
bool userIsSigned = false;
string loggedUsername = String.Empty;

Start:

Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (DZ1.Constants.welcomeMessage.Length / 2)) + "}", 
    DZ1.Constants.welcomeMessage));
Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (DZ1.Constants.remindOnExitMessage.Length / 2)) + "}",
    DZ1.Constants.remindOnExitMessage));

bool checker = true;


Console.WriteLine("- Для того, чтобы перейти в режим администратора - нажмите на клавишу 'a'");
Console.WriteLine("- Для того, чтобы зайти как пользователь - нажмите на клавишу 'u'\n");

while (checker)
{
    var enteredKey = Console.ReadKey(true);
    if (enteredKey.Key == ConsoleKey.A)
    {
        Console.Clear();
        DZ1.Constants.AdminPassPage();
        bool passChecker = true;
        while (passChecker) {
            //// пароль - "admin"
            var pressedKey = Console.ReadKey(true);
            switch (pressedKey.Key)
            {
                //// ввод пароля
                case ConsoleKey.I:
                    Console.Write("Введите пароль - ");
                    string inputPassword = Console.ReadLine();
                    if (DZ1.Admin.AdminLogin(inputPassword))
                    {
                        passChecker = false;
                        Console.WriteLine("Вы успешно авторизированы!");
                        Console.WriteLine("Переходим к панели администратора...");
                        Thread.Sleep(1500);
                        Console.Clear();
                        DZ1.Constants.AdminWelcome();
                        bool buttonChecker = true;
                        while (buttonChecker)
                        {
                            var pressedButton = Console.ReadKey(true);
                            if (pressedButton.Key == ConsoleKey.E)
                            {

                                Console.Write("Введите команду - ");
                                bool commandChecker = true;
                                var commandInput = Console.ReadLine();
                                while (commandChecker)
                                {
                                    switch (commandInput)
                                    {
                                        case "add":
                                            commandChecker = false;
                                            object[] hallData = DZ1.Hall.AddingNewHall(halls);
                                            DZ1.Hall newHall = new((int)hallData[0], (int[,])hallData[1], (int[])hallData[2]);
                                            halls.Add(newHall);
                                            ////
                                            break;

                                        case "exit":
                                            Console.WriteLine(DZ1.Constants.exitLine);
                                            Thread.Sleep(1500);
                                            break;

                                        case "change":
                                            Thread.Sleep(1500);
                                            commandChecker = false;
                                            DZ1.Hall.ChangePrices(halls);
                                            ////
                                            break;

                                        case "count":
                                            Console.Write("Вы ввели команду count.");
                                            ////
                                            break;

                                        default:
                                            Console.WriteLine(DZ1.Constants.wrongData+"\n");
                                            Console.WriteLine("    ~ Для того, чтобы вернуться к вводу команд - нажмите E.");
                                            Console.WriteLine("    ~ Чтобы выйти из программы, нажмите ESC.");
                                            Console.WriteLine("    ~ Чтобы вернуться на главную страницу выбора пользователя - нажмите Backspace.");
                                            commandChecker = false;
                                            break;
                                    }
                                }
                            }
                            else if (pressedButton.Key == ConsoleKey.Escape)
                            {
                                Console.WriteLine(DZ1.Constants.exitLine);
                                Thread.Sleep(1500);
                                break;
                            }
                            else if (pressedButton.Key == ConsoleKey.Backspace)
                            {
                                Console.Clear();
                                goto Start;
                            }
                            else
                            {
                                Console.WriteLine(DZ1.Constants.wrongButton);
                            }
                        }
                    }
                    break;

                //// выход из программы
                case ConsoleKey.Escape:
                    Console.WriteLine(DZ1.Constants.exitLine);
                    Thread.Sleep(1500);
                    Environment.Exit(0);
                    break;

                //// возврат на главный экран
                case ConsoleKey.Backspace:
                    Console.Clear();
                    goto Start;
                    
                default:
                    Console.WriteLine(DZ1.Constants.wrongButton);
                    break;
            }
        }
        checker = false;
    }
    else if (enteredKey.Key == ConsoleKey.U)
    {
        
        bool userReg = true;
        checker = false;

        Console.Clear();

        DZ1.Constants.UserWelcomePage();
        while (userReg)
        {
            var pressedKey = Console.ReadKey(true);
            switch (pressedKey.Key)
            {
                case ConsoleKey.R:
                    if (!userIsSigned)
                    {
                        object[] userData = DZ1.User.UserReg(users);
                        if (!(bool)userData[2])
                        {
                            Console.WriteLine("Что-то пошло не так, повторите регистрацию.");
                        }
                        else
                        {
                            Thread.Sleep(1500);
                            //// создание нового юзера
                            Console.Clear();
                            DZ1.User newUser = new((string)userData[0], 0, (string)userData[1]);
                            loggedUsername = (string)userData[0];
                            users.Add(newUser);
                            userIsSigned = true;
                            userReg = false;
                            //// 

                            bool userMainChecker = true;
                            DZ1.Constants.UserMainPage((string)userData[0]);
                            while (userMainChecker)
                            {

                                var userKey = Console.ReadKey(true);
                                switch (userKey.Key)
                                {
                                    case ConsoleKey.E:
                                        bool userCommandChecker = true;
                                        while (userCommandChecker)
                                        {
                                            Console.Write("Введите команду - ");
                                            string inputCom = Console.ReadLine();
                                            if (inputCom != null)
                                            {
                                                if (inputCom.ToLower() == "showbalance")
                                                {
                                                    userCommandChecker = false;
                                                    Console.WriteLine($"Ваш баланс на данный момент - {newUser.balance} руб.");
                                                    Console.WriteLine("Ожидание ввода команды...\n");
                                                    ///
                                                }
                                                else if (inputCom.ToLower() == "topupbalance")
                                                {
                                                    userCommandChecker = false;
                                                    int topUpSum = DZ1.User.TopUpUserBalance(newUser.uname, users);
                                                    newUser.balance += topUpSum;
                                                    ///
                                                }
                                                else if (inputCom.ToLower() == "buyticket")
                                                {
                                                    userCommandChecker = false;
                                                    ///
                                                }
                                                else
                                                {
                                                    Console.WriteLine(DZ1.Constants.wrongData);
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine(DZ1.Constants.wrongData);
                                            }
                                        }
                                        break;

                                    case ConsoleKey.Backspace:
                                        Console.Clear();
                                        goto Start;


                                    case ConsoleKey.Escape:
                                        Console.WriteLine(DZ1.Constants.exitLine);
                                        Thread.Sleep(1500);
                                        userMainChecker = false;
                                        Environment.Exit(0);
                                        break;

                                    default:
                                        Console.WriteLine(DZ1.Constants.wrongButton);
                                        break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Вы уже авторизированы.\nПеренаправляем на страничку управления аккаунтом... ");
                    }
                    break;

                case ConsoleKey.S:
                    if (users.Count != 0)
                    {
                        DZ1.User loggedUser = DZ1.User.UserLogin(users);
                        DZ1.Constants.UserMainPage(loggedUser.uname);
                        bool userMainChecker = true;
                        while (userMainChecker)
                        {

                            var userKey = Console.ReadKey(true);
                            switch (userKey.Key)
                            {
                                case ConsoleKey.E:
                                    bool userCommandChecker = true;
                                    while (userCommandChecker)
                                    {
                                        Console.Write("Введите команду - ");
                                        string inputCom = Console.ReadLine();
                                        if (inputCom != null)
                                        {
                                            if (inputCom.ToLower() == "showbalance")
                                            {
                                                userCommandChecker = false;
                                                Console.WriteLine($"Ваш баланс на данный момент - {loggedUser.balance} руб.");
                                                Console.WriteLine("Ожидание ввода команды...\n");
                                                ///
                                            }
                                            else if (inputCom.ToLower() == "topupbalance")
                                            {
                                                userCommandChecker = false;
                                                int topUpSum = DZ1.User.TopUpUserBalance(loggedUser.uname, users);
                                                loggedUser.balance += topUpSum;
                                                ///
                                            }
                                            else if (inputCom.ToLower() == "buyticket")
                                            {
                                                userCommandChecker = false;
                                                ///
                                            }
                                            else
                                            {
                                                Console.WriteLine(DZ1.Constants.wrongData);
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine(DZ1.Constants.wrongData);
                                        }
                                    }
                                    break;

                                case ConsoleKey.Backspace:
                                    Console.Clear();
                                    goto Start;


                                case ConsoleKey.Escape:
                                    Console.WriteLine(DZ1.Constants.exitLine);
                                    Thread.Sleep(1500);
                                    userMainChecker = false;
                                    Environment.Exit(0);
                                    break;

                                default:
                                    Console.WriteLine(DZ1.Constants.wrongButton);
                                    break;
                            }
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Еще не создано ни одного пользователя. Зарегистрируйтесь!");
                        break;
                    }
                    
                
                case ConsoleKey.Escape:
                    userReg = false;
                    Console.WriteLine(DZ1.Constants.exitLine);
                    Thread.Sleep(1500);
                    Environment.Exit(0);
                    break;

                case ConsoleKey.Backspace:
                    Console.Clear();
                    goto Start;

                default:
                    Console.WriteLine(DZ1.Constants.wrongButton);
                    break;
            }

        }

    }
    else if (enteredKey.Key == ConsoleKey.Escape)
    {
        Console.WriteLine("Всего доброго!");
        Thread.Sleep(1500);
        break;
    }
    else
    {
        Console.WriteLine(DZ1.Constants.wrongButton);
    }
} ;