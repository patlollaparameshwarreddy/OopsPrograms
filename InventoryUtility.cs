using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OopsPrograms
{
    class InventoryUtility
    {
        IList<InventoryManagementModel> inventory = new List<InventoryManagementModel>();
        public void InventoryManagementData()
        {
            Console.WriteLine(" diaplaying the items in a inventory management");
            Constants constants = new Constants();

            using (StreamReader streamReader = new StreamReader(constants.inventoryManageMentDetails))
            {
                string json = streamReader.ReadToEnd();
                inventory = JsonConvert.DeserializeObject<List<InventoryManagementModel>>(json);
            }
            foreach (var items in inventory)
            {
                Console.WriteLine(items.name + "\t" + items.weight + "\t" + items.pricePerKg);
            }
        }
        public void AddToInventory()
        {
            try
            {
                Constants constants = new Constants();
                Console.WriteLine("enter name of the item");
                string nameOfItem = Console.ReadLine();
                Console.WriteLine("enter the weight of the item");
                double weightOfItem = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("enter the price per kg for the item");
                double pricePerkgOfItem = Convert.ToDouble(Console.ReadLine());
                InventoryManagementModel managementModel = new InventoryManagementModel()
                {
                    name = nameOfItem,
                    weight = weightOfItem,
                    pricePerKg = pricePerkgOfItem
                };

                string data = InventoryUtility.ReadFile(constants.inventoryManageMentDetails);
                inventory = JsonConvert.DeserializeObject<List<InventoryManagementModel>>(data);
                inventory.Add(managementModel);
                var convertedJson = JsonConvert.SerializeObject(inventory);
                File.WriteAllText(constants.inventoryManageMentDetails, convertedJson);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public static string ReadFile(string fileName)
        {
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string json = streamReader.ReadToEnd();
                streamReader.Close();
                return json;
            }

        }
        public void UpdateInventoryData()
        {
            Constants constants = new Constants();
            string data = InventoryUtility.ReadFile(constants.inventoryManageMentDetails);
            IList<InventoryManagementModel> inventoryDetails = JsonConvert.DeserializeObject<List<InventoryManagementModel>>(data);

            foreach (var items in inventoryDetails)
            {
                Console.WriteLine(items.id + "\t" + items.name + "\t" + items.weight + "\t" + items.pricePerKg);
            }
            Console.WriteLine("Enter the Id to update");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var item in inventoryDetails)
            {
                while (id == item.id)
                {
                    Console.WriteLine(item.id + "\t" + item.name + "\t" + item.weight + "\t" + item.pricePerKg);
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
                        while (id == item.id)
                        {
                            item.pricePerKg = newPrice;
                            break;
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter new Price");
                    newWeight = Convert.ToInt32(Console.ReadLine());
                    foreach (var item in inventoryDetails)
                    {
                        while (id == item.id)
                        {
                            item.weight = newWeight;
                            break;
                        }
                    }
                    break;
            }
            var convertedJson = JsonConvert.SerializeObject(inventoryDetails);
            File.WriteAllText(constants.inventoryManageMentDetails, convertedJson);
        }

        //public void Iteration(IList<InventoryManagementModel> inventoryDetails, InventoryManagementModel property, int value, int id)
        //{
        //    foreach (var item in inventoryDetails)
        //    {
        //        while (id == item.id)
        //        {
        //            item.property = value;
        //            break;
        //        }
        //    }

        //}

        public void deleteInventory()
        {
            Constants constants = new Constants();
            ArrayList arrayList = new ArrayList();
            string data = InventoryUtility.ReadFile(constants.inventoryManageMentDetails);
            IList<InventoryManagementModel> inventoryDelete = JsonConvert.DeserializeObject<List<InventoryManagementModel>>(data);           
            Console.ReadLine();
            foreach (var items in inventoryDelete)
            {
                Console.WriteLine(items.id + "\t" + items.name + "\t" + items.weight + "\t" + items.pricePerKg);
            }
            Console.WriteLine("Enter the Id to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            foreach (var item in inventoryDelete)
            {
                while (id == item.id)
                {
                    Console.WriteLine(item.id + "\t" + item.name + "\t" + item.weight + "\t" + item.pricePerKg);
                    break;
                }
            }
            Console.WriteLine(inventoryDelete);
            foreach (var item in inventoryDelete)
            {
                while (item.id == id)
                {
                    inventoryDelete.Remove(item);

                }
            }
            var convertedJson = JsonConvert.SerializeObject(inventoryDelete);
            File.WriteAllText(constants.inventoryManageMentDetails, convertedJson);
            Console.ReadLine();
        }
    }
}
