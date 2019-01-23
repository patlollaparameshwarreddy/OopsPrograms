using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OopsPrograms
{
    public class InventoryManagement
    {
        public void Manage()
        {
            InventoryUtility inventoryUtility = new InventoryUtility();
            Console.WriteLine("enter 1 for reading the item in an inventory");
            Console.WriteLine("enter 2 for adding items in to an inventory");
            Console.WriteLine("enter 3 for updating the item in a inventory");
            int caseToExecute = Convert.ToInt32(Console.ReadLine());
            switch (caseToExecute)
            {
                case 1:
                    
                    inventoryUtility.InventoryManagementData();
                    break;
                case 2:
                    inventoryUtility.AddToInventory();
                    break;
                case 3:
                   inventoryUtility.UpdateInventoryData();
                    break;

            }
        }
    }
}
