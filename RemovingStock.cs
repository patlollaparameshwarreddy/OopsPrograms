//-----------------------------------------------------------------------
// <copyright file="RemovingStock.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{   
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// this class is used to Remove Stock
    /// </summary>
    public class RemovingStock
    {
        /// <summary>
        /// Removes the stock.
        /// </summary>
        public void RemoveStock()
        {
            ////creating the object of Constants class 
            Constants constants = new Constants();
            ////this is used for reading the file
            using (StreamReader stream = new StreamReader(constants.StockFile))
            {
                string data = stream.ReadToEnd();
                stream.Close();
                IList<StockDataModel> removestock = JsonConvert.DeserializeObject<List<StockDataModel>>(data);
                ////this loop is used for printing the items in a removestock list
                foreach (var items in removestock)
                {
                    Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.NumberOfShares + "\t" + items.PricePerShare);
                }

                Console.WriteLine("Enter the Id to delete");
                int id = Convert.ToInt32(Console.ReadLine());
                bool itemExists = true;
                ////this loop is used for printing the items in a removestock list with particular id
                foreach (var item in removestock)
                {
                    if (id == item.Id)
                    {
                        Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.NumberOfShares + "\t" + item.PricePerShare);
                        itemExists = false;
                        break;
                    }
                }

                ////this condition is used for checking the whether the item exists in a list or not
                if (itemExists == true)
                {
                    Console.WriteLine("inventory does not exists");
                }

                ////this is used for removing the object
                var itemToRemove = removestock.Single(r => r.Id == id);
                removestock.Remove(itemToRemove);
                ////serializeing the object
                var convertedJson = JsonConvert.SerializeObject(removestock);
                ////writing into the file
                File.WriteAllText(constants.StockFile, convertedJson);
                Console.WriteLine("stock removed");                
            }
        }
    }
}