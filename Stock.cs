using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OopsPrograms
{
    class Stock
    {
        public void CreateStock()
        {
            Constants constants = new Constants();
            Inventory inventory = new Inventory();
            IList<StockModel> stockModels = new List<StockModel>();
            stockModels = Stock.ReadFile(constants.stockDetails);
            foreach (var item in stockModels)
            {
                Console.WriteLine("{0}"+"\t" +"{1}" +"\t" + "{2}"+" ",item.name, item.price, item.availableShares);
            }

        }

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



