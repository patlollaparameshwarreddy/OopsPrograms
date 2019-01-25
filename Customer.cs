using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OopsPrograms
{
    interface ICustomer
    {
        void AddCustomer();
         IList<CustomerModel> GetAllCustomer();

    }
    public class CustomerData : ICustomer
    {
        Constants constants = new Constants();
        public void AddCustomer()
        {
            Console.WriteLine("enter id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter name");
            string name = Console.ReadLine();
            Console.WriteLine("enter valuation");
            int valuation = Convert.ToInt32(Console.ReadLine());
            CustomerModel customerModel = new CustomerModel();
            {
                customerModel.Id = id;
                customerModel.Name = name;
                customerModel.Valuation = valuation;
            }
            IList<CustomerModel> customers = new List<CustomerModel>();
            using (StreamReader stream = new StreamReader(constants.customerDetails))
            {
                string json = stream.ReadToEnd();
                stream.Close();
                customers = JsonConvert.DeserializeObject<List<CustomerModel>>(json);
                customers.Add(customerModel);
                var convertedJson = JsonConvert.SerializeObject(customers);
                File.WriteAllText(constants.customerDetails, convertedJson);

            }
        }



        public IList<CustomerModel> GetAllCustomer()
        {
            IList<CustomerModel> customers = new List<CustomerModel>();
            using (StreamReader stream = new StreamReader(constants.customerDetails))
            {
                string json = stream.ReadToEnd();
                stream.Close();
                customers = JsonConvert.DeserializeObject<IList<CustomerModel>>(json);
                if (customers == null)
                {
                    throw new Exception("No customers available");
                }
            }
            return customers;

        }

    }
}
