//-----------------------------------------------------------------------
// <copyright file="TransactionModel.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using OopsPrograms.Common;

    /// <summary>
    /// this class is used for declaring the class variables
    /// </summary>
    public class TransactionModel
    {
        /// <summary>
        /// The customer name
        /// </summary>
        private string customerName;

        /// <summary>
        /// The stock name
        /// </summary>
        private string stockName;

        /// <summary>
        /// The no of shares
        /// </summary>
        private int noOfShares;

        /// <summary>
        /// The amount
        /// </summary>
        private int amount;

        /// <summary>
        /// The time
        /// </summary>
        private string time;

        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        public string CustomerName { get => this.customerName; set => this.customerName = value; }

        /// <summary>
        /// Gets or sets the name of the stock.
        /// </summary>
        /// <value>
        /// The name of the stock.
        /// </value>
        public string StockName { get => this.stockName; set => this.stockName = value; }

        /// <summary>
        /// Gets or sets the no of shares.
        /// </summary>
        /// <value>
        /// The no of shares.
        /// </value>
        public int NoOfShares { get => this.noOfShares; set => this.noOfShares = value; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public int Amount { get => this.amount; set => this.amount = value; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public string Time { get => this.time; set => this.time = value; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        /// <value>
        /// The type of the transaction.
        /// </value>
        public TransactionType TransactionType{ get; set; }        
    }
}
