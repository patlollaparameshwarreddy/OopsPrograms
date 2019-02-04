//-----------------------------------------------------------------------
// <copyright file="DataProcessing.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// this class is used for data processing
    /// </summary>
    public class DataProcessing
    {
        /// <summary>
        /// Customers the data.
        /// </summary>
        public void CustomerData()
        {
            ////customer data in file
            CustomerData customerData1 = new CustomerData();
            IList<CustomerModel> values = customerData1.GetAllCustomer();
            foreach (var items in values)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.Valuation);
            }
        }

        /// <summary>
        /// Stocks the data.
        /// </summary>
        public void StockData()
        {
            ////this case is used for getting all the records
            StockData stockData1 = new StockData();
            IList<StockDataModel> stock = stockData1.GetStock();
            foreach (var items in stock)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShares + "\t" + items.PricePerShare);
            }
        }

        /// <summary>
        /// Transactions the data.
        /// </summary>
        public void TransactionData()
        {
            ////this case is used for getting all the Transactions
            IList<TransactionModel> valuess = Transaction.GetAllTransactions();
            foreach (var items in valuess)
            {
                Console.WriteLine(items.CustomerName + "\t" + items.StockName + "\t" + items.TransactionType + "\t" + items.NoOfShares + "\t" + items.Amount + "\t" + items.Time);
            }
        }
    }
}