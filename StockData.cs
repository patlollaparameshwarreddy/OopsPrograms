//-----------------------------------------------------------------------
// <copyright file="StockData.cs" company="CompanyName">
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
    /// this class is used for stock data
    /// </summary>
    public class StockData
    {
        /// <summary>
        /// The constants object
        /// </summary>
        Constants constants = new Constants();

        /// <summary>
        /// Adds the stock.
        /// </summary>
        public void AddStock()
        {
            try
            {              
                IList<StockDataModel> stock = new List<StockDataModel>();
                Console.WriteLine("enter id of stock");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter name of stock");
                string name = Console.ReadLine();
                Console.WriteLine("enter the number of shares");
                int numberOfStocks = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter price per share");
                int pricePerShare = Convert.ToInt32(Console.ReadLine());
                ////creating the object of StockDataModel class 
                StockDataModel stockDataModel = new StockDataModel();
                {
                    stockDataModel.Id = id;
                    stockDataModel.Name = name;
                    stockDataModel.NumberOfShares = numberOfStocks;
                    stockDataModel.PricePerShare = pricePerShare;
                    ////this is used for reading the file
                    using (StreamReader stream = new StreamReader(this.constants.StockFile))
                    {
                        string json = stream.ReadToEnd();
                        stream.Close();
                        stock = JsonConvert.DeserializeObject<List<StockDataModel>>(json);
                        stock.Add(stockDataModel);
                        ////searializeing the object
                        var convertedJson = JsonConvert.SerializeObject(stock);
                        File.WriteAllText(this.constants.StockFile, convertedJson);
                        Console.WriteLine("new stock added");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Gets the stock.
        /// </summary>
        /// <returns> the list</returns>
        public IList<StockDataModel> GetStock()
        {
            IList<StockDataModel> stock = new List<StockDataModel>();
            ////this is used for reading the file
            using (StreamReader stream = new StreamReader(this.constants.StockFile))
            {
                string json = stream.ReadToEnd();
                stream.Close();
                ////Deserializeing the object
                stock = JsonConvert.DeserializeObject<List<StockDataModel>>(json);
                return stock;
            }               
        }
    }
}
