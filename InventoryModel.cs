namespace OopsPrograms
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Model class for inventory management
    /// </summary>
    public class InventoryModel
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>
        /// The weight.
        /// </value>
        [Range(1, 100, ErrorMessage = "Weight must be between 1 and 100 kg")]
        public double weight { get; set; }

        /// <summary>
        /// Gets or sets the price per kg.
        /// </summary>
        /// <value>
        /// The price per kg.
        /// </value>
        [Range(1, 100, ErrorMessage = "Price must be between Rs. 1 and Rs. 100 ")]
        public double pricePerKg { get; set; }
    }
}
