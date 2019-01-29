//-----------------------------------------------------------------------
// <copyright file="InventoryManagement.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;

    /// <summary>
    /// this class is used for inventory management
    /// </summary>
    public class InventoryManagement
    {
        /// <summary>
        /// Manages this instance.
        /// </summary>
        public void Manage()
        {
            ////creating the object of InventoryUtility class
            InventoryUtility inventoryUtility = new InventoryUtility();
            Console.WriteLine("enter 1 for reading the item in an inventory");
            Console.WriteLine("enter 2 for adding items in to an inventory");
            Console.WriteLine("enter 3 for updating the item in a inventory");
            Console.WriteLine("enter 4 for deleteing inventory");
            int caseToExecute = Convert.ToInt32(Console.ReadLine());
            switch (caseToExecute)
            {
                case 1:
                    ////this case is used for manage data
                    inventoryUtility.InventoryManagementData();
                    break;
                case 2:
                    ////this case is used for a
                    inventoryUtility.AddToInventory();
                    break;
                case 3:
                   inventoryUtility.UpdateInventoryData();
                    break;
                case 4:
                    inventoryUtility.DeleteInventory();
                    break;
            }
        }
    }
}
