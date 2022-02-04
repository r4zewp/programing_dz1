using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DZ1
{
    public class Hall
    {
        public int hallNumber { get; set; }
        public int[,] sitsPrices { get; set; }
        public int[] userSitsInput { get; set; }
        public Hall(int hallNumber, int[,] sitsPrices, int[] userSitsInput) 
        {
            this.hallNumber = hallNumber;
            this.sitsPrices = sitsPrices;
            this.userSitsInput = userSitsInput;
        }
        public static object[] AddingNewHall(List<DZ1.Hall> listOfHalls)
        {
            int[] rowS = DZ1.Hall.GetRowsAndSits();
            int[,] prices = DZ1.Hall.GetSitPrices(rowS);
            int hallNumber = DZ1.Hall.GetHallNumber(listOfHalls);

            return new object[] {hallNumber, prices, rowS};
        }

        private static int[] GetRowsAndSits()
        {
            int[] rowS = new int[2];
            string[] rowString = new string[] { };
            bool rowsChecker = true;
            bool formatChecker = false;

            while (rowsChecker)
            {
                bool excChecker = true;
                Console.Write("Введите количество рядов и мест в них (в формате N M) - ");
                rowString = Console.ReadLine().Split(" ");
                Regex rowsController = new Regex(@"[\W]");
                for (int i = 0; i < rowString.Length; i++)
                { 
                    if (!rowsController.IsMatch(rowString[i]))
                    {
                        if (rowString.Length == 2)
                        {
                            for (int j = 0; j < rowString.Length; j++)
                            {
                                rowS[i] = Convert.ToInt32(rowString[i]);
                                rowsChecker = false;
                            }
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
            }
            return rowS;
        }

        private static int[,] GetSitPrices(int[] sits)
        {
            int[,] prices = new int[sits[0], sits[1]];
            bool priceChecker = true;
           
            while (priceChecker)
            {
                Console.WriteLine("Введите цены на места по расположению в зале ниже:");
                try
                {
                    for (int i = 0; i < sits[0]; i++)
                    {
                        var values = Console.ReadLine().Split(' ');
                        if (values.Length < 0 || values.Length != sits[1])
                        {
                            Console.WriteLine(DZ1.Constants.wrongData);
                        }
                        else
                        {
                            for (int j = 0; j < sits[1]; j++)
                            {
                                if (prices[i, j] > 0)
                                {
                                    prices[i, j] = int.Parse(values[j]);
                                }
                                else
                                {
                                    Console.WriteLine(DZ1.Constants.wrongData);
                                }
                            }
                            priceChecker = false;
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(DZ1.Constants.wrongData);
                }
            }
            return prices;
        }

        private static int GetHallNumber(List<DZ1.Hall> halls) 
        {
            int hallNum = 0;
            bool hallChecker = true;
            while (hallChecker)
            {
                Console.Write("Введите номер зала - ");
                try
                {
                    hallNum = Convert.ToInt32(Console.ReadLine());
                    if (hallNum <= 0)
                    {
                        Console.WriteLine(DZ1.Constants.wrongData);
                    }
                    else
                    {
                        int hallsCount = halls.Count;
                        if (hallsCount == 0)
                        {
                            hallChecker = false;
                            Console.WriteLine("Зал успешно добавлен!\n");
                            Console.WriteLine("  ~ Чтобы заново ввести команду - нажмите на 'e'.");
                            Console.WriteLine("  ~ Для выхода из программы - нажмите на 'ESC'.\n");

                            return hallNum;
                        }
                        else {
                            for (int j = 0; j < hallsCount; j++)
                            {
                                if (hallNum == halls[j].hallNumber)
                                {
                                    Console.WriteLine("Такой зал уже существует, повторите ввод!");
                                }
                                else
                                {
                                    hallChecker = false;
                                    Console.WriteLine("Зал успешно добавлен!");
                                    return hallNum;
                                }
                            }
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(DZ1.Constants.wrongData);
                }
            }
            return hallNum;
        }
        
        public static object[] ChangePrices(List<DZ1.Hall> listOfHalls) 
        {
            int hallNumToEdit = GetHallNumForEdit(listOfHalls);
            int[] placeNum = GetPlaceNum(listOfHalls);

            return new object[] { };
        }

        public static int GetHallNumForEdit(List<DZ1.Hall> listOfHalls)
        {
            bool hallChecker = true;
            while (hallChecker)
            {
                Console.Write("Введите номер зала, где вы хотите поменять цены - ");
                try
                {
                    int hallNum = Convert.ToInt32(Console.ReadLine());
                    if (hallNum == 0)
                    {
                        Console.WriteLine(DZ1.Constants.wrongData);
                    }
                    else
                    {
                        for (int i = 0; i < listOfHalls.Count; i++)
                        {
                            if (hallNum == listOfHalls[i].hallNumber)
                            {
                                hallChecker = false;
                                return hallNum;
                            }
                            else {
                                Console.WriteLine("Такого зала не существует, повторите ввод!");
                            }
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(DZ1.Constants.wrongData);
                }
            }
            return 0;
        }

        public static int[] GetPlaceNum(List<DZ1.Hall> listOfHalls)
        {
            bool placeChecker = true;
            int[] sitNum = new int[2];
            while (placeChecker)
            {
                Console.Write("Введите ряд и номер места, цену которого хотите поменять, через пробел - ");
                string[] values = Console.ReadLine().Split(' ');
                if (values.Length != 2)
                {
                    Console.WriteLine(DZ1.Constants.wrongData);
                }
                else
                {
                    try
                    {
                        for (int i = 0; i < values.Length; i++)
                        {
                             sitNum[i] = Convert.ToInt32(values[i]);
                        }
                        try
                        {
                            /*for (int i = 0; i < length; i++)
                            {

                            }*/
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(DZ1.Constants.wrongData);
                    }
                } 
            }
            return new int[] { };
        }
    }

    public class Place : Hall 
    {
        public bool isFree = true;
        public int sitPrice;
        public Place(int hallNumber, int[,] sitsPrices, bool isFree, int sitPrice, int[] rowS ) : base(hallNumber, sitsPrices, rowS) 
        {
            this.isFree = isFree;
            this.sitPrice = sitPrice;
        }
    }
}
