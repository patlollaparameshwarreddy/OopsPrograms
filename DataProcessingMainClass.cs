﻿//-----------------------------------------------------------------------
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
                DataProcessing dataProcessing = new DataProcessing();
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
                            ////this case is used for adding customer
                            CustomerData customerData = new CustomerData();
                            customerData.AddCustomer();
                            break;
                        case 2:
                            ////this case is used for adding the stock
                            StockData stockData = new StockData();
                            stockData.AddStock();
                            break;
                        case 3:
                            ////this case is used for buying the stock
                            Transaction transaction = new Transaction();
                            transaction.BuyStock();
                            break;
                        case 4:
                            ////this case is used for selling the stock
                            Transaction transaction1 = new Transaction();
                            transaction1.SellStock();
                            break;
                        case 5:
                            ////this case is used for getting the all customer data                           
                            dataProcessing.CustomerData();

                            break;
                        case 6:
                            ////this case is used for getting all the records
                            dataProcessing.StockData();

                            break;
                        case 7:
                            ////this case is used for getting all the Transactions
                            dataProcessing.TransactionData();

                            break;
                        case 8:
                            ////this case is used for removing the stock
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
