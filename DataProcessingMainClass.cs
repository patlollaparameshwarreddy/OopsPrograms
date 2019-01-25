using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    class DataProcessingMainClass
    {
        public void DataProcesssing()
        {
            Console.WriteLine("enter 1 for adding customer");
            Console.WriteLine("enter 2 for adding stock");
            Console.WriteLine("enter 3 for buying stock");
            Console.WriteLine("enter 4 for selling stock");
            Console.WriteLine("enter 5 for view customers");
            Console.WriteLine("enter 6 for view stock");
            Console.WriteLine("enter 7 for view transaction");
            int caseCondition = Convert.ToInt32(Console.ReadLine());
            switch (caseCondition)
            {
                case 1:
                    CustomerData customerData = new CustomerData();
                    customerData.AddCustomer();
                    break;
                case 2:
                    StockData stockData = new StockData();
                    stockData.AddStock();
                    break;
                case 3: Transaction transaction = new Transaction();
                    transaction.BuyStock();
                    break;
                case 4:
                    Transaction transaction1 = new Transaction();
                    transaction1.SellStock();
                    break;
                case 5:
                    CustomerData customerData1 = new CustomerData();
                    IList<CustomerModel> values = customerData1.GetAllCustomer();
                    foreach (var items in values)
                    {
                        Console.WriteLine(items.Id +"\t" + items.Name + "\t" + items.Valuation);
                    }
                    break;
                case 6:
                    StockData stockData1 = new StockData();
                    stockData1.GetStock();
                    break;
                case 7:
                    break;

            }
        }
    }
}
