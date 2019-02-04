//-----------------------------------------------------------------------
// <copyright file="TransactionsInQueue.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    /// <summary>
    /// this class is used to store data in queue
    /// </summary>
    public class TransactionsInQueue
    {
        /// <summary>
        /// Transactions the in queue.
        /// </summary>
        public void TransactionInQueue() 
        {
            ////creating object of constant to access location of file
            Constants constants = new Constants();
            ////creating list object to read data from file
            IList<TransactionModel> transactions = new List<TransactionModel>();           
            ////queue object is use to keep transaction timing the company in queue
            Queue<TransactionModel> queue = new Queue<TransactionModel>();
            ////stream Reader is a class to read data from the file
            using (StreamReader stream = new StreamReader(constants.TransactionFile))
            {
                ////reading data from file and storing in the string variable
                string json = stream.ReadToEnd();
                ////storing all the data from string to list
                transactions = JsonConvert.DeserializeObject<IList<TransactionModel>>(json);
                stream.Close();
            }
            ////iteration is use to enqueue all the transactions
            foreach (var items in transactions)
            {
                queue.Enqueue(items);
            }
            ////iteration is used to print the data from the queue
            foreach (var item in queue)
            {
                Console.WriteLine(item.Time);
            }
        }
    }
}
