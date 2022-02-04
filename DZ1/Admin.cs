using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    internal class Admin
    {
        public const string username = "admin";
        public const string password = "admin";
        public static bool AdminLogin(string userInput)
        {
            if (Admin.password == userInput)
            {
                return true;
            }
            else 
            {
                Console.WriteLine("     ~ Введен неверный пароль, нажмите на клавишу I, чтобы ввести пароль заново.");
                Console.WriteLine("     ~ Для того, чтобы выйти, нажмите ESC.");
                Console.WriteLine("     ~ Чтобы вернуться на главную, нажмите Backspace.\n");
            }
            return false;
        }
    }
}
