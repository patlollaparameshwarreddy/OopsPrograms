//-----------------------------------------------------------------------
// <copyright file="Stock.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//----------------------------------------------------------------------
namespace OopsPrograms
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// this class is used for taking the details of the stock and its shares
    /// </summary>
    class Stock
    {
        public void CreateStock()
        {
            ////creating the object of constants class
            Constants constants = new Constants();
            ////creating the object of linkedList
            IList<StockModel> stockModels = new List<StockModel>();
            ////the method Stock.ReadFile is called for reading the elements from the stock object
            stockModels = Stock.ReadFile(constants.stockDetails);
            ////this loop is used for printing the elements in a object
            foreach (var item in stockModels)
            {
                Console.WriteLine("{0}"+"\t" +"{1}" +"\t" + "{2}"+" ",item.shareName, item.PriceOfShare, item.numberOfShares    );
            }

        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>returns the elements in a stock object </returns>
        /// <exception cref="Exception"></exception>
        public static IList<StockModel> ReadFile(string fileName)
        {
            try
            {
                using (StreamReader r = new StreamReader(fileName))
                {
                    var json = r.ReadToEnd();
                    /// deserialize data because it is in json format
                    var items = JsonConvert.DeserializeObject<List<StockModel>>(json);
                    return items;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}



