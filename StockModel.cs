//-----------------------------------------------------------------------
// <copyright file="StockModel.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    /// <summary>
    /// this class is used for declaring the getters and setters
    /// </summary>
    public class StockModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string ShareName { get; set; }

        /// <summary>
        /// Gets or sets the available shares.
        /// </summary>
        /// <value>
        /// The available shares.
        /// </value>
        public int NumberOfShares { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public int PriceOfShare { get; set; }
    }
}
