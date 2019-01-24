//-----------------------------------------------------------------------
// <copyright file="MainClass.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//----------------------------------------------------------------------
namespace OopsPrograms
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// this class is used to for creating the objects for all the classes
    /// </summary>
    class MainClass
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            string condition = null;
            int caseCondition = 0;
            try
            {
                do
                {
                    Console.WriteLine("enter 1 for inventory details");
                    Console.WriteLine("enter 2 for regular expression");
                    Console.WriteLine("enter 3 for stock");
                    Console.WriteLine("enter 4 for inventory management");
                    Console.WriteLine("enter 5 for deck of cards");
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
                        case 4:
                            InventoryManagement inventoryManagement = new InventoryManagement();
                            inventoryManagement.Manage();
                            break;
                        case 5:
                            DeckOfCards deckOfCards = new DeckOfCards();
                            deckOfCards.Distribution();
                            break;
                    }
                    Console.WriteLine("Enter Y to continue OR any key to stop");

                    condition = Console.ReadLine();
                }
                while (condition.Equals("y") || condition.Equals("Y"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            
        }
    }

}
