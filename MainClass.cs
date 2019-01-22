using Newtonsoft.Json;
using System;

namespace OopsPrograms
{
    class MainClass
    {
        static void Main(string[] args)
        {
            string condition = null;
            int caseCondition = 0;
            do
            {
                Console.WriteLine("enter 1 for inventory details");
                Console.WriteLine("enter 2 for regular expression");
                Console.WriteLine("enter 3 for stock");
                try
                {
                     caseCondition = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("enter proper condition");
                }
                switch (caseCondition)
                {
                    case 1:
                        Inventory inventory = new Inventory();
                        inventory.PrintData();
                        break;
                    case 2:
                        RegularExpression regularExpression = new RegularExpression();
                        regularExpression.ReplacingRegularExpressionWithString();
                        break;
                    case 3:
                        Stock stock = new Stock();
                        stock.CreateStock();
                        break;
                }
                Console.WriteLine("Enter Y to continue OR any key to stop");

                condition = Console.ReadLine();
            }
            while (condition.Equals("y") || condition.Equals("Y"));
        }
    }

}
