//-----------------------------------------------------------------------
// <copyright file="Inventory.cs" company="CompanyName">
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
    /// this class is used for inventory stock details
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// Prints the data.
        /// </summary>
        public void PrintData()
        {
            //// Reads the file which is in json format
            Inventory printsDetailsOfInventory = new Inventory();
            ////creating the object of constant class
            Constants constants = new Constants();
            List<InventoryModel> items = printsDetailsOfInventory.ReadFile(constants.InventoryForProducts);
            Console.WriteLine("Name\tweight\tRate\tAmount");
            //// for loop to iterate a data which will received in list format
            foreach (var item in items)
            {
                Console.WriteLine("{0}" + "\t" + "{1}" + " \t" + "{2}" + "\t" + "{3}", item.Name, item.Weight, item.PricePerKg, item.PricePerKg * item.Weight);
            }
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>the elements that are in the object</returns>
        /// <exception cref="Exception">file not found</exception>
        public List<InventoryModel> ReadFile(string fileName)
        {
            try
            {
                ////StreamReader is  used to read from the file
                using (StreamReader stream = new StreamReader(fileName))
                {
                    var json = stream.ReadToEnd();
                    stream.Close();
                    //// deserialize data because it is in json format
                    var items = JsonConvert.DeserializeObject<List<InventoryModel>>(json);
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