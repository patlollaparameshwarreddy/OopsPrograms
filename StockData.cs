using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OopsPrograms
{
    public class StockData
    {
         Constants constants = new Constants();
        public void AddStock()
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
            StockDataModel stockDataModel = new StockDataModel();
            {
                stockDataModel.Id = id;
                stockDataModel.Name = name;
                stockDataModel.NumberOfShares = numberOfStocks;
                stockDataModel.PricePerShare = pricePerShare;
                using (StreamReader stream = new StreamReader(constants.stockFile))
                {
                    string json = stream.ReadToEnd();
                    stream.Close();
                    stock = JsonConvert.DeserializeObject<List<StockDataModel>>(json);
                    stock.Add(stockDataModel);
                    var convertedJson = JsonConvert.SerializeObject(stock);
                    File.WriteAllText(constants.stockFile, convertedJson);

                }
            }
        }
        public IList<StockDataModel> GetStock()
        {
            IList<StockDataModel> stock = new List<StockDataModel>();
            using (StreamReader stream = new StreamReader(constants.stockFile))
            {
                string json = stream.ReadToEnd();
                stream.Close();
                stock = JsonConvert.DeserializeObject<List<StockDataModel>>(json);
                return stock;
            }
                
        }
    }
}
