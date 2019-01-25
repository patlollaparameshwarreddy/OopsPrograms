using Newtonsoft.Json;
using OopsPrograms.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OopsPrograms
{
    class Transaction
    {
        public void BuyStock()
        {
            CustomerData customer = new CustomerData();
            IList<CustomerModel> customerModels = customer.GetAllCustomer();
            Console.WriteLine("id \t name \t valuation");
            foreach (var items in customerModels)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.Valuation);
            }
            Console.WriteLine("Please enter the customer id");
            int customerId = Convert.ToInt32(Console.ReadLine());
            StockData stockData = new StockData();
            IList<StockDataModel> stockModels = stockData.GetStock();
             Console.WriteLine("id \tname \tnumberofshares \tpricepershare");
            foreach (var items in stockModels)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShares + "\t" + items.PricePerShare);
            }
            Console.WriteLine("Please enter the  Stock Id to select stock for the customer");
            int stockId = Convert.ToInt32(Console.ReadLine());
            StockDataModel stockDataModel = null;
            bool stockFl = true;
            foreach (var items in stockModels)
            {   
                if(items.Id == stockId)
                {
                    stockDataModel = items;
                    Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShares + "\t" + items.PricePerShare);
                    stockFl = false;
                }
                
            }
            if(stockFl == true)
            {
                throw new Exception("Invalid stock id");
            }
            Console.WriteLine("Enter the number of shares need to purchase");
            int numberOfShares = Convert.ToInt32(Console.ReadLine());
            string customerName = "";
            string stockName = "";
            int amountValuation = 0;
            if (numberOfShares < stockDataModel.NumberOfShares || numberOfShares <= 0)
            {
                int priceOfShare = 0;
                bool stockFlag = true;
                foreach (var items in stockModels)
                {
                    if (items.Id == stockId)
                    {
                        Console.WriteLine(items.NumberOfShares);
                        Console.WriteLine(numberOfShares);
                        items.NumberOfShares = items.NumberOfShares - numberOfShares;
                        Console.WriteLine(numberOfShares);
                        Console.WriteLine(items.NumberOfShares);
                        priceOfShare = items.PricePerShare;
                        stockName = items.Name;
                        stockFlag = false;
                    }

                }
                if(stockFlag == true)
                {
                    throw new Exception("Invalid stock id");
                }
                bool customerFlag = true;
                foreach (var item in customerModels)
                {
                    if(item.Id == customerId)
                    {
                        item.Valuation = item.Valuation + (priceOfShare * numberOfShares);
                        customerName = item.Name;
                        amountValuation = item.Valuation;
                        customerFlag = false;
                    }
                }
                if(customerFlag == true)
                {
                    throw new Exception("Invalid customer id");
                }
            }

            else
            {
                throw new Exception("No. of shares you mentioned are not available in stock or invalid input");
            }
             
            TransactionModel transactionModel = new TransactionModel()
            {
                CustomerName = customerName,
                StockName = stockName,
                NoOfShares = numberOfShares,
                Amount = amountValuation,
                Time = DateTime.Now.ToString(),
                transactionType = TransactionType.Buy
            };
            IList<TransactionModel> transactionModels = Transaction.GetAllTransactions();
            transactionModels.Add(transactionModel);
            Constants constants = new Constants();
            Transaction.writeFile(constants.stockFile, stockModels);
            Transaction.writeFile(constants.customerDetails, customerModels);
            Transaction.writeFile(constants.transactionFile, transactionModels);

        }

        public static void writeFile(string fileName, Object data)
        {
            var convertedJson = JsonConvert.SerializeObject(data);
            File.WriteAllText(fileName, convertedJson);
        }
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
            int numberOfShares = Convert.ToInt32(Console.ReadLine());
            string customerName = "";
            string stockName = "";
            int amountValuation = 0;
            if (numberOfShares >= 0)
            {
                int priceOfShare = 0;
                bool stockFlag = true;
                foreach (var items in stockModels)
                {
                    if (items.Id == stockId)
                    {
                        //Console.WriteLine(items.NumberOfShares);
                        //Console.WriteLine(numberOfShares);
                        items.NumberOfShares = items.NumberOfShares + numberOfShares;
                        //Console.WriteLine(numberOfShares);
                        //Console.WriteLine(items.NumberOfShares);
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
                        item.Valuation = item.Valuation - priceOfShare;
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

            TransactionModel transactionModel = new TransactionModel()
            {
                CustomerName = customerName,
                StockName = stockName,
                NoOfShares = numberOfShares,
                Amount = amountValuation,
                Time = DateTime.Now.ToString(),
                transactionType = TransactionType.Buy
            };
            IList<TransactionModel> transactionModels = Transaction.GetAllTransactions();
            transactionModels.Add(transactionModel);
            Constants constants = new Constants();
            Transaction.writeFile(constants.stockFile, stockModels);
            Transaction.writeFile(constants.customerDetails, customerModels);
            Transaction.writeFile(constants.transactionFile, transactionModels);

        }



          
        public static IList<TransactionModel> GetAllTransactions()
        {
            Constants constants = new Constants();
            IList<TransactionModel> transactions = new List<TransactionModel>();
            using (StreamReader stream = new StreamReader(constants.transactionFile))
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
