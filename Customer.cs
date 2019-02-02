//-----------------------------------------------------------------------
// <copyright file="ICustomer.cs" company="CompanyName">
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
    /// this inter face is used for developing the add customer method
    /// </summary>
    public interface ICustomer
    {
        /// <summary>
        /// Adds the customer.
        /// </summary>
        void AddCustomer();

        /// <summary>
        /// Gets all customer.
        /// </summary>
        /// <returns>returns the customer objects</returns>
        IList<CustomerModel> GetAllCustomer();
    }

    /// <summary>
    /// this class is used for developing the interface methods
    /// </summary>
    /// <seealso cref="OopsPrograms.ICustomer" />
    public class CustomerData : ICustomer
    {
        /// <summary>
        /// The constant object is created
        /// </summary>
        private Constants constants = new Constants();

        /// <summary>
        /// Adds the customer.
        /// </summary>
        /// <exception cref="Exception">file not found exception</exception>
        public void AddCustomer()
        {
            try
            {
                Console.WriteLine("enter id");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter name");
                string name = Console.ReadLine();
                Console.WriteLine("enter valuation");
                int valuation = Convert.ToInt32(Console.ReadLine());
                if (valuation > 0)
                {
                    ////creating the object of the customer model class
                    CustomerModel customerModel = new CustomerModel();
                    {
                        customerModel.Id = id;
                        customerModel.Name = name;
                        customerModel.Valuation = valuation;
                    }
                    ////creating new ilist
                    IList<CustomerModel> customers = new List<CustomerModel>();
                    ////this is used for reading the file
                    using (StreamReader stream = new StreamReader(this.constants.CustomerDetails))
                    {
                        ////reading the hole content in the file
                        string json = stream.ReadToEnd();
                        ////closing the file
                        stream.Close();
                        ////Deserialize the customet model file
                        customers = JsonConvert.DeserializeObject<List<CustomerModel>>(json);
                        customers.Add(customerModel);
                        ////Serialize the customer model object
                        var convertedJson = JsonConvert.SerializeObject(customers);
                        ////writing all the text in to a file
                        File.WriteAllText(this.constants.CustomerDetails, convertedJson);
                        Console.WriteLine("new customer added");
                    }
                }
                else
                {
                    Console.WriteLine("enter valid data");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Gets all customer.
        /// </summary>
        /// <returns>returns the customer objects</returns>
        /// <exception cref="Exception">No customers available</exception>
        public IList<CustomerModel> GetAllCustomer()
        {
            IList<CustomerModel> customers = new List<CustomerModel>();
            ////this is used for reading the file
            using (StreamReader stream = new StreamReader(this.constants.CustomerDetails))
            {
                string json = stream.ReadToEnd();
                stream.Close();
                ////Deserialize the customet model file
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
