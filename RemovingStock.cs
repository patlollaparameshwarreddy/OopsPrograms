﻿

namespace OopsPrograms
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    class RemovingStock
    {
        public void RemoveStock()
        {
            Constants constants = new Constants();
            using (StreamReader stream = new StreamReader(constants.StockFile))
            {

                string data = stream.ReadToEnd();
                stream.Close();
                IList<StockDataModel> removestock = JsonConvert.DeserializeObject<List<StockDataModel>>(data);
                foreach (var items in removestock)
                {
                    Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShares + "\t" + items.PricePerShare);
                }
                Console.WriteLine("Enter the Id to delete");
                int id = Convert.ToInt32(Console.ReadLine());
                bool itemExists = true;
                foreach (var item in removestock)
                {
                    if (id == item.Id)
                    {
                        Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.NumberOfShares + "\t" + item.PricePerShare);
                        itemExists = false;
                        break;
                    }
                }
                if (itemExists == true)
                {
                    Console.WriteLine("inventory does not exists");
                }
                var itemToRemove = removestock.Single(r => r.Id == id);
                removestock.Remove(itemToRemove);

                var convertedJson = JsonConvert.SerializeObject(removestock);
                File.WriteAllText(constants.StockFile, convertedJson);
                Console.WriteLine("stock removed");                
            }
        }
    }
}