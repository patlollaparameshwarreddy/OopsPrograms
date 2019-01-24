using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    class StockUtility
    {
        public void AddCustomer()
        {
            Console.WriteLine("enter id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter name");
            string name = Console.ReadLine();
            Console.WriteLine("enter total share");
            int totalShares = Convert.ToInt32(Console.ReadLine());
            CustomerModel customerModel = new CustomerModel();
            {
                customerModel.id = id;
                customerModel.name = name;
                customerModel.totalShares = totalShares;
            }

        }
    }
}
