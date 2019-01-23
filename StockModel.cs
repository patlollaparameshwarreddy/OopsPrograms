﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    public class StockModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string shareName { get; set; }

        /// <summary>
        /// Gets or sets the available shares.
        /// </summary>
        /// <value>
        /// The available shares.
        /// </value>
        public int numberOfShares { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public int PriceOfShare { get; set; }
    }
}
