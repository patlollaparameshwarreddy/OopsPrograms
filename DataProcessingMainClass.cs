//-----------------------------------------------------------------------
// <copyright file="DataProcessingMainClass.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// this class is used for knowing the details of a customers and a stock
    /// </summary>
    public class DataProcessingMainClass
    {
        /// <summary>
        /// Data processing.
        /// </summary>
        /// <exception cref="Exception">system exceptions </exception>
        public void DataProcesssing()
        {
            try
            {
                int caseCondition;
                ////this variable is used for checking the condition of do 
                string doCondition = null;
                do
                {
                    Console.WriteLine("enter 1 for adding customer");
                    Console.WriteLine("enter 2 for adding stock");
                    Console.WriteLine("enter 3 for buying stock");
                    Console.WriteLine("enter 4 for selling stock");
                    Console.WriteLine("enter 5 for view customers");
                    Console.WriteLine("enter 6 for view stock");
                    Console.WriteLine("enter 7 for view transaction");
                    Console.WriteLine("enter 8 for removing the stock ");
                    caseCondition = Convert.ToInt32(Console.ReadLine());
                    switch (caseCondition)
                    {
                        case 1:
                            CustomerData customerData = new CustomerData();
                            customerData.AddCustomer();
                            break;
                        case 2:
                            StockData stockData = new StockData();
                            stockData.AddStock();
                            break;
                        case 3:
                            Transaction transaction = new Transaction();
                            transaction.BuyStock();
                            break;
                        case 4:
                            Transaction transaction1 = new Transaction();
                            transaction1.SellStock();
                            break;
                        case 5:
                            CustomerData customerData1 = new CustomerData();
                            IList<CustomerModel> values = customerData1.GetAllCustomer();
                            foreach (var items in values)
                            {
                                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.Valuation);
                            }

                            break;
                        case 6:
                            StockData stockData1 = new StockData();
                            IList<StockDataModel> stock = stockData1.GetStock();
                            foreach (var items in stock)
                            {
                                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShares + "\t" + items.PricePerShare);
                            }

                            break;
                        case 7:
                            IList<TransactionModel> valuess = Transaction.GetAllTransactions();
                            foreach (var items in valuess)
                            {
                                Console.WriteLine(items.CustomerName + "\t" + items.StockName + "\t" + items.TransactionType + "\t" + items.NoOfShares + "\t" + items.Amount + "\t" + items.Time);
                            }

                            break;
                        case 8:
                            RemovingStock removingStock = new RemovingStock();
                            removingStock.RemoveStock();
                            break;
                    }

                    Console.WriteLine("enter y to continue");
                    doCondition = Console.ReadLine();
                }
                while (doCondition.Equals("y"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
