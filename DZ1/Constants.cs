using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1
{
    internal class Constants
    {
        public static string welcomeMessage = "Добро пожаловать в приложение кинозала!";
        public static string remindOnExitMessage = "Вы можете в любой момент выйти из приложения, нажав на клавишу ESC\n";
        public static string welcomeAdminMessage = "Для того, чтобы продолжить, вам нужно ввести пароль администратора.\n";
        public static string adminPage = "Вы находитесь в консоли администратора\n";
        public static string adminCommands = "Для администратора доступны следующие команды:";
        public static string adminAdd = "- Команда add позволяет добавить новый зал и указать цены на билеты,";
        public static string adminChange = "- Команда change позволяет изменить существующие цены.\n";
        public static string adminCount = "- Команда count выдает данные по свободным и занятым местам в зале";
        public static string adminInputCommand = "    ~ Для ввода команды нажмите на 'e', для выхода - на ESC";
        public static string adminBackspace = "    ~ Для возврата на главную нажмите на кнопку Backspace.\n";
        public static string exitLine = "Программа завершена. Успехов!";
        public static string wrongButton = "Нажата неправильная клавиша, повторите.\n";
        public static string wrongData = "Повторите ввод данных - они введены неверно.\n";
        public static string changeMenu = "Вы попали в меню для изменения цены.\n";
        public static string userWelcome = "Добро пожаловать в кассу кинотеатра!\n";
        

        internal static void AdminPassPage()
        { 
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (DZ1.Constants.welcomeAdminMessage.Length / 2)) + "}",
            DZ1.Constants.welcomeAdminMessage));
            Console.WriteLine("- Для ввода пароля нажмите на кнопку I.");
            Console.WriteLine("- Для выхода из программы нажмите на кнопку ESC.");
            Console.WriteLine("- Чтобы вернуться на главную страницу, нажмите Backspace.\n");
            Console.WriteLine("  Ожидание нажатия...\n");
        }
        public static void AdminWelcome() 
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (DZ1.Constants.adminPage.Length / 2)) + "}",
                        DZ1.Constants.adminPage));
            Console.WriteLine(DZ1.Constants.adminCommands);
            Console.WriteLine(DZ1.Constants.adminAdd);
            Console.WriteLine(DZ1.Constants.adminCount);
            Console.WriteLine(DZ1.Constants.adminChange);
            Console.WriteLine(DZ1.Constants.adminInputCommand);
            Console.WriteLine(DZ1.Constants.adminBackspace);
        }
        public static void UserWelcomePage()
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (DZ1.Constants.userWelcome.Length / 2)) + "}",
                        DZ1.Constants.userWelcome));
            Console.WriteLine("Далее вам предстоит пройти регистрацию/войти в аккаунт или же вернуться обратно на главную страницу.\n");
            Console.WriteLine("    ~ Для того, чтобы продолжить регистрацию, нажмите 'r'.");
            Console.WriteLine("    ~ Если у вас уже есть аккаунт, нажмите на кнопку 's' для логина.");
            Console.WriteLine("    ~ Чтобы вернуться в главное меню, нажмите Backspace.");
            Console.WriteLine("    ~ Чтобы выйти из программы - нажмите ESC.\n");
            Console.WriteLine("Ожидание ввода команды...\n");
        }

        public static void UserMainPage(string username)
        {
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ($"Добро пожаловать в кинокассу, {username}!\n".Length / 2)) + "}",
                       $"Добро пожаловать в кинокассу, {username}!\n"));
            Console.WriteLine(" - Чтобы ввести любую команду, нажмите 'e'.");
            Console.WriteLine("    ~ чтобы проверить баланс, введите 'showbalance',");
            Console.WriteLine("    ~ для пополнения баланса введите 'topupbalance',");
            Console.WriteLine("    ~ для приобретения билета введите 'buyticket',\n");
            Console.WriteLine(" - Чтобы вернуться обратно в главное меню, нажмите Backspace.");
            Console.WriteLine(" - Чтобы выйти из программы, нажмите ESC.\n");
            Console.WriteLine("Ожидание ввода команды...");
        }
    }
}
