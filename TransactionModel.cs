using OopsPrograms.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    public class TransactionModel
    {
        private string customerName;
        private string stockName;       
        private int noOfShares;
        private int amount;
        private string time;
        public string CustomerName { get => customerName; set => customerName = value; }
        public string StockName { get => stockName; set => stockName = value; }
        public int NoOfShares { get => noOfShares; set => noOfShares = value; }
        public int Amount { get => amount; set => amount = value; }
        public string Time { get => time; set => time = value; }
        public TransactionType transactionType{get; set;}
       
        
    }
}
