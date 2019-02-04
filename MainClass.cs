//-----------------------------------------------------------------------
// <copyright file="MainClass.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;

    /// <summary>
    /// this class is used to for creating the objects for all the classes
    /// </summary>
    public class MainClass
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
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
                    Console.WriteLine("enter 6 for stock data processing");
                    Console.WriteLine("enter 7 for address book");
                    Console.WriteLine("enter 8 for deck of cards in queue");
                    Console.WriteLine("enter 9 for getting transaction in queue");
                    Console.WriteLine("enter 10 for getting transaction in stack");
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
                            ////creating object of inventory class
                            Inventory inventory = new Inventory();
                            inventory.PrintData();
                            break;
                        case 2:
                            ////creating object of RegularExpression class
                            RegularExpression regularExpression = new RegularExpression();
                            regularExpression.ReplacingRegularExpressionWithString();
                            break;
                        case 3:
                            ////creating object of Stock class
                            Stock stock = new Stock();
                            stock.CreateStock();
                            break;
                        case 4:
                            ////creating object of InventoryManagement class
                            InventoryManagement inventoryManagement = new InventoryManagement();
                            inventoryManagement.Manage();
                            break;
                        case 5:
                            ////creating object of DeckOfCards class
                            DeckOfCards deckOfCards = new DeckOfCards();
                            deckOfCards.Distribution();
                            break;
                        case 6:
                            ////creating the object of DataProcessingMainClass class
                            DataProcessingMainClass dataProcessingMainClass = new DataProcessingMainClass();
                            dataProcessingMainClass.DataProcesssing();
                            break;
                        case 7:
                            ////creating the object of AddressBook class
                            AddressBook addressBook = new AddressBook();
                            addressBook.AddressBookDetails();
                            break;
                        case 8:
                            ////creating the object of CardQueue class
                            CardQueue cardQueue = new CardQueue();
                            cardQueue.CardInQueue();
                            break;
                        case 9:
                            ////creating the object of TransactionsInQueue class
                            TransactionsInQueue transaction = new TransactionsInQueue();
                            transaction.TransactionInQueue();
                            break;
                        case 10:
                            ////creating the object of TransactionStack class
                            TransactionStack transactionStack  = new TransactionStack();
                            transactionStack.StackTransaction();
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
