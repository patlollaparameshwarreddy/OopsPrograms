//-----------------------------------------------------------------------
// <copyright file="InventoryUtility.cs" company="CompanyName">
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
    /// this class is used for managing all the inventory details
    /// </summary>
    public class InventoryUtility
    {
        /// <summary>
        /// The inventory
        /// </summary>
         IList<InventoryManagementModel> inventory = new List<InventoryManagementModel>();

        /// <summary>
        /// Inventories the management data.
        /// </summary>
        public void InventoryManagementData()
        {
            Console.WriteLine(" diaplaying the items in a inventory management");
            Constants constants = new Constants();
            ////StreamReader is used to read the file
            using (StreamReader streamReader = new StreamReader(constants.InventoryManageMentDetails))
            {
                ////ReadToEnd will read the file up to the end
                string json = streamReader.ReadToEnd();
                this.inventory = JsonConvert.DeserializeObject<List<InventoryManagementModel>>(json);
            }

            ////this loop is used to read the objects in a list
            foreach (var items in this.inventory)
            {
                Console.WriteLine(items.Name + "\t" + items.Weight + "\t" + items.PricePerKg);
            }
        }

        /// <summary>
        /// this loop is used for adding the inventory object in to the  file
        /// </summary>
        public void AddToInventory()
        {
            try
            {
                ////taking the id from the customer
                Console.WriteLine("enter id");
                int idNo = Convert.ToInt32(Console.ReadLine());
                ////creating the object of constants class
                Constants constants = new Constants();
                Console.WriteLine("enter name of the item");
                string nameOfItem = Console.ReadLine();
                Console.WriteLine("enter the weight of the item");
                double weightOfItem = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("enter the price per kg for the item");
                double pricePerkgOfItem = Convert.ToDouble(Console.ReadLine());
                ////creating the new object of  InventoryManagementModel class
                InventoryManagementModel managementModel = new InventoryManagementModel()
                {
                    ////assigning the values of InventoryManagementModel class
                    Id = idNo,
                    Name = nameOfItem,
                    Weight = weightOfItem,
                    PricePerKg = pricePerkgOfItem
                };

                ////reading the data from the file
                string data = InventoryUtility.ReadFile(constants.InventoryManageMentDetails);
                ////deserializeing the string in to object
                this.inventory = JsonConvert.DeserializeObject<List<InventoryManagementModel>>(data);
                this.inventory.Add(managementModel);
                ////Serialize the inventory 
                var convertedJson = JsonConvert.SerializeObject(this.inventory);
                ////writing into the file
                File.WriteAllText(constants.InventoryManageMentDetails, convertedJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// this method is used reading the file
        /// </summary>
        /// <param name="fileName"> file path</param>
        /// <returns> the string</returns>
        public static string ReadFile(string fileName)
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string json = streamReader.ReadToEnd();
                streamReader.Close();
                return json;
            }
        }

        /// <summary>
        /// this method is used for updating the inventory data
        /// </summary>
        public void UpdateInventoryData()
        {
            ////creating the object of constantes class
            Constants constants = new Constants();
            ////reading the json file 
            string data = InventoryUtility.ReadFile(constants.InventoryManageMentDetails);
            IList<InventoryManagementModel> inventoryDetails = JsonConvert.DeserializeObject<List<InventoryManagementModel>>(data);

            foreach (var items in inventoryDetails)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.Weight + "\t" + items.PricePerKg);
            }

            Console.WriteLine("Enter the Id to update");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var item in inventoryDetails)
            {
                while (id == item.Id)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Weight + "\t" + item.PricePerKg);
                    break;
                }
            }

            Console.WriteLine("Enter 1 to change the price \n Enter 2 to change weight");
            int property = Convert.ToInt32(Console.ReadLine());
            int newPrice = 0;
            int newWeight = 0;
            switch (property)
            {
                case 1:
                    Console.WriteLine("Enter new Price");
                    newPrice = Convert.ToInt32(Console.ReadLine());
                    foreach (var item in inventoryDetails)
                    {
                        while (id == item.Id)
                        {
                            item.PricePerKg = newPrice;
                            break;
                        }
                    }

                    break;
                case 2:
                    Console.WriteLine("Enter new Price");
                    newWeight = Convert.ToInt32(Console.ReadLine());
                    foreach (var item in inventoryDetails)
                    {
                        while (id == item.Id)
                        {
                            item.Weight = newWeight;
                            break;
                        }
                    }

                   break;
            }

            var convertedJson = JsonConvert.SerializeObject(inventoryDetails);
            File.WriteAllText(constants.InventoryManageMentDetails, convertedJson);
        }
       
        /// <summary>
        /// this method is used for deleting the object
        /// </summary>
        public void DeleteInventory()
        {
            ////creating the object of constants class
            Constants constants = new Constants();          
            string data = InventoryUtility.ReadFile(constants.InventoryManageMentDetails);
            IList<InventoryManagementModel> inventoryDelete = JsonConvert.DeserializeObject<List<InventoryManagementModel>>(data);  
            ////this loop is used for printing the elements in a list
            foreach (var items in inventoryDelete)
            {
                Console.WriteLine(items.Id + "\t" + items.Name + "\t" + items.Weight + "\t" + items.PricePerKg);
            }

            Console.WriteLine("Enter the Id to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            bool itemExists = true;
            ////this loop is used for searching the given id
            foreach (var item in inventoryDelete)
            {
                if (id == item.Id)
                {
                    Console.WriteLine(item.Id + "\t" + item.Name + "\t" + item.Weight + "\t" + item.PricePerKg);
                    itemExists = false;
                    break;
                }
            }

            if (itemExists == true)
            {
                Console.WriteLine("inventory does not exists");
            }

            var itemToRemove = inventoryDelete.Single(r => r.Id == id);
            inventoryDelete.Remove(itemToRemove);
            ////searilizeing the object
            var convertedJson = JsonConvert.SerializeObject(inventoryDelete);
            ////writing in to the file
            File.WriteAllText(constants.InventoryManageMentDetails, convertedJson);
            Console.WriteLine("stock removed");
        }
    }
}
