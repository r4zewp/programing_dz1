using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DZ1
{
    internal class User
    {
        public string uname { get; set; }
        public int balance { get; set; }
        public string password { get; set; }
        public User(string uname, int balance, string password) {
            this.uname = uname;
            this.balance = balance;
            this.password = password;
        }

        public static object[] UserReg(List<DZ1.User> users)
        {
            string userName = GetUserName(users);
            Thread.Sleep(1500);
            string password = GetUserPassword();
            bool isReg = true;
            object[] userData = new object[] {userName, password, isReg};
            
            return userData;
        }

        public static string GetUserPassword()
        {
            string password = String.Empty;
            bool passChecker = true;
            Console.WriteLine("Придумайте пароль. Он может содержать любые символы, но быть не более 10 символов в длину.");
            while (passChecker)
            {
                Console.Write("Введите придуманный пароль - ");
                password = Console.ReadLine();
                if (password.Length <= 10)
                {
                    Console.WriteLine("Вы успешно зарегистрировались!");
                    Thread.Sleep(1500);
                    passChecker = false;
                }
                else 
                {
                    Console.WriteLine(DZ1.Constants.wrongData);    
                }
            }
            return password;
        }
        public static string GetUserName(List<DZ1.User> users)
        {
            string userName = String.Empty;
            bool useregCheck = true;
            while (useregCheck)
            {
                Console.WriteLine("Имя пользователя не должно содержать цифр и любых других знаков.");
                Console.Write("Введите имя пользователя (username) - ");
                userName = Console.ReadLine();
                if (!string.IsNullOrEmpty(userName))
                {
                    if (userName != DZ1.Admin.username)
                    {
                        Regex loginController = new Regex(@"[\d\W]");
                        if (!loginController.IsMatch(userName))
                        {
                            if (users.Count != 0)
                            {
                                for (int i = 0; i < users.Count; i++)
                                {
                                    if (users[i].uname == userName)
                                    {
                                        Console.WriteLine("Пользователь с таким именем пользователя уже есть.\n");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Привет, {userName}!");
                                        return userName;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Привет, {userName}!\n");
                                return userName;
                            }
                        }
                        else
                        {
                            Console.WriteLine(DZ1.Constants.wrongData);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Это имя пользователя уже занято.\n");
                    }
                }
                else
                {
                    Console.WriteLine(DZ1.Constants.wrongData);
                }
            }
            return userName;
        }

        public static User UserLogin (List<DZ1.User> users)
        {
            User user = new(String.Empty, 0, String.Empty);
            bool userLoginChecker = true;
            while (userLoginChecker)
            {
                Console.Write("Введите имя пользователя - ");
                string inputUsername = Console.ReadLine();
                for (int i = 0; i < users.Count; i++)
                {
                    if (inputUsername == users[i].uname)
                    {
                        bool userPasswordChecker = true;
                        
                        while (userPasswordChecker)
                        {
                            Console.Write("Введите пароль - ");
                            string inputPassword = Console.ReadLine();
                            if (inputPassword == users[i].password)
                            {
                                Console.WriteLine("Вы успешно авторизованы!");
                                user = new(users[i].uname, users[i].balance, users[i].password);
                                Thread.Sleep(1500);
                                Console.Clear();
                                return user;
                            }
                            else
                            {
                                Console.WriteLine("Неверный пароль, попробуйте еще раз!\n");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Такого пользователя не существует, повторите ввод!\n");
                    }
                }
            }
            return user;
        }

        public static int TopUpUserBalance(string username, List<DZ1.User> users)
        {
            bool topupChecker = true;
            while (topupChecker)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (username == users[i].uname)
                    {
                        Console.Write("Введите сумму, на которую хотите пополнить баланс - ");
                        try
                        {
                            int topUpSum = Convert.ToInt32(Console.ReadLine());
                            if (topUpSum > 0)
                            {
                                Console.WriteLine("Баланс успешно пополнен!");
                                Console.WriteLine("Ожидание ввода команды...\n");
                                return topUpSum;
                            }
                            else
                            {
                                Console.WriteLine(DZ1.Constants.wrongData);
                                
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(DZ1.Constants.wrongData);
                            
                        }
                    }
                }
            }
            return 0;
        }
    }
}
