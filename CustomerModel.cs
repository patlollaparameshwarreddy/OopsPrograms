//-----------------------------------------------------------------------
// <copyright file="CustomerModel.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    /// <summary>
    /// this class is used for declaring the getters and setters
    /// </summary>
    public class CustomerModel
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
        /// The valuation
        /// </summary>
        private int valuation;

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
        /// Gets or sets the valuation.
        /// </summary>
        /// <value>
        /// The valuation.
        /// </value>
        public int Valuation { get => this.valuation; set => this.valuation = value; }
    }
}
