//-----------------------------------------------------------------------
// <copyright file="StockDataModel.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    /// <summary>
    /// this class is used for declaring the class variables
    /// </summary>
    public class StockDataModel
    {
        /// <summary>
        /// The identifier
        /// </summary>
        private int id;

        /// <summary>
        /// The name
        /// </summary>
        private string name;

        /// <summary>
        /// The number of shares
        /// </summary>
        private int numberOfShares;

        /// <summary>
        /// The price per share
        /// </summary>
        private int pricePerShare;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get => this.id; set => this.id = value; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get => this.name; set => this.name = value; }

        /// <summary>
        /// Gets or sets the number of shares.
        /// </summary>
        /// <value>
        /// The number of shares.
        /// </value>
        public int NumberOfShares { get => this.numberOfShares; set => this.numberOfShares = value; }

        /// <summary>
        /// Gets or sets the price per share.
        /// </summary>
        /// <value>
        /// The price per share.
        /// </value>
        public int PricePerShare { get => this.pricePerShare; set => this.pricePerShare = value; }
    }
}
