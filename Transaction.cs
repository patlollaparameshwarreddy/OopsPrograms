//-----------------------------------------------------------------------
// <copyright file="Transaction.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{    
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;
    using OopsPrograms.Common;

    /// <summary>
    /// this class is used for maintaining the stock details
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Buys the stock.
        /// </summary>
        /// <exception cref="Exception">
        /// Invalid stock id        
        /// No. of shares you mentioned are not available in stock or invalid input
        /// </exception>
        public void BuyStock()
        {
            ////creating the object of customer class
            CustomerData customer = new CustomerData();
            ////creating new list
            IList<CustomerModel> customerModels = customer.GetAllCustomer();
            Console.WriteLine("id \t name \t valuation");
            ////this loop is used for printing the elements in a list
            foreach (var items in customerModels)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.Valuation);
            }

            Console.WriteLine("Please enter the customer id");
            int customerId = Convert.ToInt32(Console.ReadLine());
            ////creating the object of  StockData class
            StockData stockData = new StockData();
            IList<StockDataModel> stockModels = stockData.GetStock();
             Console.WriteLine("id \tname \tnumberofshares \tpricepershare");
            ////this loop is used for printing the data in  StockData
            foreach (var items in stockModels)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShares + "\t" + items.PricePerShare);
            }

            Console.WriteLine("Please enter the  Stock Id to select stock for the customer");
            int stockId = Convert.ToInt32(Console.ReadLine());
            StockDataModel stockDataModel = null;
            bool stockFl = true;
            ////this loop is used for printing the data in  stockModels
            foreach (var items in stockModels)
            {   
                if (items.Id == stockId)
                {
                    stockDataModel = items;
                    Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShares + "\t" + items.PricePerShare);
                    stockFl = false;
                }                
            }

            ////this condition is used for checking the whether the stock present or not
            if (stockFl == true)
            {
                throw new Exception("Invalid stock id");
            }

            Console.WriteLine("Enter the number of shares need to purchase");
            int numberOfShares = Convert.ToInt32(Console.ReadLine());
            string customerName = string.Empty;
            string stockName = string.Empty;
            int amountValuation = 0;
            ////this condition is used for checking whether user entered the valid number of shares
            if (numberOfShares < stockDataModel.NumberOfShares || numberOfShares <= 0)
            {
                int priceOfShare = 0;
                bool stockFlag = true;
                ////this loop is used for searching for the given stock id
                foreach (var items in stockModels)
                {
                    if (items.Id == stockId)
                    {                       
                        items.NumberOfShares = items.NumberOfShares - numberOfShares;                       
                        priceOfShare = items.PricePerShare;
                        stockName = items.Name;
                        stockFlag = false;
                    }
                }

                ////this condition is used for checking the id exists
                if (stockFlag == true)
                {
                    throw new Exception("Invalid stock id");
                }

                bool customerFlag = true;
                ////this loop is used for searching for the given customer id
                foreach (var item in customerModels)
                {
                    if (item.Id == customerId)
                    {
                        item.Valuation = item.Valuation - (priceOfShare * numberOfShares);
                        customerName = item.Name;
                        amountValuation = item.Valuation;
                        customerFlag = false;
                    }
                }

                ////this condition is used for checking the id exists
                if (customerFlag == true)
                {
                    throw new Exception("Invalid customer id");
                }
            }
            else
            {
                throw new Exception("No. of shares you mentioned are not available in stock or invalid input");
            }

            ////creating the object of transactionModel class
            TransactionModel transactionModel = new TransactionModel()
            {
                CustomerName = customerName,
                StockName = stockName,
                NoOfShares = numberOfShares,
                Amount = amountValuation,
                Time = DateTime.Now.ToString(),
                TransactionType = TransactionType.Buy
            };

            IList<TransactionModel> transactionModels = Transaction.GetAllTransactions();
            transactionModels.Add(transactionModel);
            Constants constants = new Constants();
            Transaction.WriteFile(constants.StockFile, stockModels);
            Transaction.WriteFile(constants.CustomerDetails, customerModels);
            Transaction.WriteFile(constants.TransactionFile, transactionModels);
            Console.WriteLine("purchase sucessfull");
        }

        /// <summary>
        /// Writes the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="data">The data.</param>
        public static void WriteFile(string fileName, object data)
        {
            var convertedJson = JsonConvert.SerializeObject(data);
            File.WriteAllText(fileName, convertedJson);
        }

        /// <summary>
        /// Sells the stock.
        /// </summary>
        /// <exception cref="Exception">
        /// Invalid stock id      
        /// No. of shares you mentioned are not available in stock or invalid input
        /// </exception>
        public void SellStock()
        {
            CustomerData customer = new CustomerData();
            IList<CustomerModel> customerModels = customer.GetAllCustomer();
            Console.WriteLine("id \t name \t valuation");
            foreach (var items in customerModels)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.Valuation);
            }

            Console.WriteLine("Please enter the selling customer id");
            int customerId = Convert.ToInt32(Console.ReadLine());
            StockData stockData = new StockData();
            IList<StockDataModel> stockModels = stockData.GetStock();
            Console.WriteLine("id \tname \tnumberofshares \tpricepershare");
            foreach (var items in stockModels)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShares + "\t" + items.PricePerShare);
            }

            Console.WriteLine("Please enter the Stock Id to which stock you want to sell");
            int stockId = Convert.ToInt32(Console.ReadLine());            
            StockDataModel stockDataModel = null;
            bool stockFl = true;
            ////this loop is used for printing the data in stock model
            foreach (var items in stockModels)
            {
                if (items.Id == stockId)
                {
                    stockDataModel = items;
                    Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShares + "\t" + items.PricePerShare);
                    stockFl = false;
                }
            }

            if (stockFl == true)
            {
                throw new Exception("Invalid stock id");
            }

            Console.WriteLine("Enter the number of shares need to sell");
            ////taking the input from the user
            int numberOfShares = Convert.ToInt32(Console.ReadLine());
            string customerName = string.Empty;
            string stockName = string.Empty;
            int amountValuation = 0;
            if (numberOfShares > 0)
            {
                int priceOfShare = 0;
                bool stockFlag = true;
                ////this loop is used for searching the entered id 
                foreach (var items in stockModels)
                {
                    if (items.Id == stockId)
                    {                        
                        items.NumberOfShares = items.NumberOfShares + numberOfShares;                        
                        priceOfShare = items.PricePerShare * numberOfShares;
                        stockName = items.Name;
                        stockFlag = false;
                    }
                }

                if (stockFlag == true)
                {
                    throw new Exception("Invalid stock id");
                }

                bool customerFlag = true;
                foreach (var item in customerModels)
                {
                    if (item.Id == customerId)
                    {
                        item.Valuation = item.Valuation + priceOfShare;
                        customerName = item.Name;
                        amountValuation = item.Valuation;
                        customerFlag = false;
                    }
                }

                if (customerFlag == true)
                {
                    throw new Exception("Invalid customer id");
                }
            }
            else
            {
                throw new Exception("No. of shares you mentioned are not available in stock or invalid input");
            }

            ////creating the object of transactionModel
            TransactionModel transactionModel = new TransactionModel()
            {
                CustomerName = customerName,
                StockName = stockName,
                NoOfShares = numberOfShares,
                Amount = amountValuation,
                Time = DateTime.Now.ToString(),
                TransactionType = TransactionType.Sell
            };
            IList<TransactionModel> transactionModels = Transaction.GetAllTransactions();
            transactionModels.Add(transactionModel);
            Constants constants = new Constants();
            ////writing the stock in to the file
            Transaction.WriteFile(constants.StockFile, stockModels);
            ////writing the customer in to the file
            Transaction.WriteFile(constants.CustomerDetails, customerModels);
            ////writing the transaction in to file
            Transaction.WriteFile(constants.TransactionFile, transactionModels);
            Console.WriteLine("selling is successfull");
        }

        /// <summary>
        /// Gets all transactions.
        /// </summary>
        /// <returns>the list</returns>
        public static IList<TransactionModel> GetAllTransactions()
        {
            Constants constants = new Constants();
            IList<TransactionModel> transactions = new List<TransactionModel>();
            ////this is used for reading the file
            using (StreamReader stream = new StreamReader(constants.TransactionFile))
            {
                string json = stream.ReadToEnd();
                stream.Close();
                transactions = JsonConvert.DeserializeObject<IList<TransactionModel>>(json);
                stream.Close();               
            }
            
            return transactions;
        }
    }
}
