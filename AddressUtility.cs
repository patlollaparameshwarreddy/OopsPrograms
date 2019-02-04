//-----------------------------------------------------------------------
// <copyright file="AddressUtility.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{    
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;

    /// <summary>
    /// this class is used for storing the address
    /// </summary>
    public class AddressUtility
    {
        /// <summary>
        /// Adds the person.
        /// </summary>
        public void AddPerson()
        {
            try
            {
                Constants constants = new Constants();
                IList<AddressBookModel> addressBook = new List<AddressBookModel>();
                Console.WriteLine("enter first name");
                string firstname = Console.ReadLine();
                Console.WriteLine("enter last name");
                string lastname = Console.ReadLine();
                Console.WriteLine("enter address");
                string address = Console.ReadLine();
                Console.WriteLine("enter city");
                string city = Console.ReadLine();
                Console.WriteLine("enter state");
                string state = Console.ReadLine();
                Console.WriteLine("enter zip");
                string zip = Console.ReadLine();
                Console.WriteLine("enter phone number");
                string phoneNumber = Console.ReadLine();
                ////this condition is used for checking the valid data
                if (Regex.IsMatch(phoneNumber, @"[0-9]{10}") && Regex.IsMatch(zip, @"[0-9]{6}") && Regex.IsMatch(firstname, @"[a-zA-Z]") && Regex.IsMatch(lastname, @"[a-zA-Z]") && Regex.IsMatch(city, @"[a-zA-Z]") && Regex.IsMatch(state, @"[a-zA-Z]") && Regex.IsMatch(address, @"[a-zA-Z0-9[-]"))
                {
                    AddressBookModel addressBookModel = new AddressBookModel()
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Address = address,
                        City = city,
                        State = state,
                        ZipCode = zip,
                        PhoneNumber = phoneNumber
                    };
                    ////this will read the file
                    string file = AddressUtility.ReadFile(constants.AddressBook);
                    addressBook = JsonConvert.DeserializeObject<List<AddressBookModel>>(file);
                    addressBook.Add(addressBookModel);
                    var convertedJson = JsonConvert.SerializeObject(addressBook);
                    File.WriteAllText(constants.AddressBook, convertedJson);
                    Console.WriteLine("new person added");
                }
                else
                {
                    Console.WriteLine("enter proper details");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>returns the list</returns>
        public static string ReadFile(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                string json = streamReader.ReadToEnd();
                streamReader.Close();
                return json;
            }
        }

        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void Update()
        {
            try
            {
                this.PrintAddressBook();
                Console.WriteLine("enter your registered phone number to update");
                string phoneNumber = Console.ReadLine();
                Constants constants = new Constants();
                IList<AddressBookModel> addressBookModel = new List<AddressBookModel>();
                string json = AddressUtility.ReadFile(constants.AddressBook);
                addressBookModel = JsonConvert.DeserializeObject<List<AddressBookModel>>(json);
                bool number = true;
                foreach (var items in addressBookModel)
                {
                    ////this condition is for checking whether the customer existis or not
                    if (items.PhoneNumber == phoneNumber)
                    {
                        Console.WriteLine(items.FirstName + "\n" + items.LastName + "\n" + items.Address + "\n" + items.City + "\n" + items.State + "\n" + items.ZipCode + "\n" + items.PhoneNumber);
                        number = false;
                        string doCondition = null;
                        do
                        {
                            Console.WriteLine("enter 1 for changing phone number");
                            Console.WriteLine("enter 2 for changing address");
                            Console.WriteLine("enter 3 for changing state");
                            Console.WriteLine("enter 4 for changing city");
                            int switchCase = Convert.ToInt32(Console.ReadLine());
                            switch (switchCase)
                            {
                                case 1:
                                    UpdatePhoneNumber(items);
                                    break;
                                case 2:
                                    ////this case is used for changing the address
                                    Console.WriteLine("enter new address");
                                    string newAddress = Console.ReadLine();
                                    items.Address = Console.ReadLine();
                                    break;
                                case 3:
                                    UpdateState(items);
                                    break;

                                case 4:
                                    UpdateCity(items);
                                    break;
                            }

                            Console.WriteLine("enter y to continue update or enter any key to stop update");
                            doCondition = Console.ReadLine();
                        }
                        while (doCondition.Equals("y"));
                        ////Serializeing the object
                        var convertedJson = JsonConvert.SerializeObject(addressBookModel);
                        File.WriteAllText(constants.AddressBook, convertedJson);
                        Console.WriteLine("update successful");
                    }
                }

                if (number == true)
                {
                    Console.WriteLine("enter proper phone number");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Prints the address book.
        /// </summary>
        public void PrintAddressBook()
        {
            Constants constants = new Constants();
            IList<AddressBookModel> addressBook = new List<AddressBookModel>();
            ////this is used for reading the file
            using (StreamReader stream = new StreamReader(constants.AddressBook))
            {
                string data = stream.ReadToEnd();
                stream.Close();
                ////Deserializeing the file to object
                addressBook = JsonConvert.DeserializeObject<List<AddressBookModel>>(data);
                foreach (var items in addressBook)
                {
                    Console.WriteLine(items.FirstName + "\t" + items.LastName + "\t" + items.Address + "\t" + items.City + "\t" + items.State + "\t" + items.ZipCode + "\t" + items.PhoneNumber);
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Deletes the data.
        /// </summary>
        public void DeleteData()
        {
            Console.WriteLine("enter your phone number to update");
            string phoneNumber = Console.ReadLine();
            ////creating the object of constants class
            Constants constants = new Constants();
            IList<AddressBookModel> addressBookModel = new List<AddressBookModel>();
            ////reading the file
            string json = AddressUtility.ReadFile(constants.AddressBook);
            ////deserializeing the file
            addressBookModel = JsonConvert.DeserializeObject<List<AddressBookModel>>(json);
            bool number = true;
            foreach (var items in addressBookModel)
            {
                ////this condition is for checking whether the customer existis or not
                if (items.PhoneNumber == phoneNumber)
                {
                    Console.WriteLine(items.FirstName + "\n" + items.LastName + "\n" + items.Address + "\n" + items.City + "\n" + items.State + "\n" + items.ZipCode + "\n" + items.PhoneNumber);
                    number = false;
                }
            }

            if (number == true)
            {
                Console.WriteLine("your details does not fount enter proper name");
            }

            var itemToRemove = addressBookModel.Single(r => r.PhoneNumber == phoneNumber);
            addressBookModel.Remove(itemToRemove);
            ////searilizeing the object
            var convertedJson = JsonConvert.SerializeObject(addressBookModel);
            ////writing in to the file
            File.WriteAllText(constants.AddressBook, convertedJson);
            Console.WriteLine("your record deleted");
        }

        /// <summary>
        /// Sorts the last name of the by.
        /// </summary>
        public void SortByLastName()
        {
            ////creating the object of constants class
            Constants constants = new Constants();
            ////reading the file date
            string json = AddressUtility.ReadFile(constants.AddressBook);
            IList<AddressBookModel> addressBookModel = new List<AddressBookModel>();
            ////Deserializeing the file to string
            addressBookModel = JsonConvert.DeserializeObject<List<AddressBookModel>>(json);
            ////OrderBy is used keeping the data in assending order
            var assendingOrder = addressBookModel.OrderBy(x => x.LastName);
            ////Serializeing the object to string 
            var orderedByLastName = JsonConvert.SerializeObject(assendingOrder);
            ////writing into the file
            File.WriteAllText(constants.AddressBook, orderedByLastName);
            Console.WriteLine("ordered by last name");
            this.PrintAddressBook();
        }

        /// <summary>
        /// Sorts the by zip.
        /// </summary>
        public void SortByZip()
        {
            ////creating the object of constants class
            Constants constants = new Constants();
            ////reading the file date
            string json = AddressUtility.ReadFile(constants.AddressBook);
            IList<AddressBookModel> addressBookModel = new List<AddressBookModel>();
            ////Deserializeing the file to string
            addressBookModel = JsonConvert.DeserializeObject<List<AddressBookModel>>(json);
            ////OrderBy is used keeping the data in assending order
            var assendingOrder = addressBookModel.OrderBy(x => x.ZipCode);
            ////Serializeing the object to string 
            var orderedByLastName = JsonConvert.SerializeObject(assendingOrder);
            ////writing into the file
            File.WriteAllText(constants.AddressBook, orderedByLastName);
            Console.WriteLine("ordered by zip code");
            this.PrintAddressBook();
        }

        /// <summary>
        /// Updates the phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="items">The items.</param>
        public void UpdatePhoneNumber(AddressBookModel items)
        {
            ////these case is used for changing the phone number
            Console.WriteLine("enter new number");
            string newPhoneNumber = Console.ReadLine();
            if (Regex.IsMatch(newPhoneNumber, @"[0-9]{10}"))
            {
                items.PhoneNumber = newPhoneNumber;
            }
            else
            {
                Console.WriteLine("enter phone number correctly");
            }
        }

        /// <summary>
        /// Updates the state.
        /// </summary>
        /// <param name="state">The state.</param>
        /// <param name="items">The items.</param>
        public void UpdateState(AddressBookModel items)
        {
            ////this case is used for changing the state
            Console.WriteLine("enter new state");
            string newState = Console.ReadLine();
            if (Regex.IsMatch(newState, @"[a-zA-Z]"))
            {
                items.State = newState;
            }
            else
            {
                Console.WriteLine("invalid data");
            }
        }

        /// <summary>
        /// Updates the city.
        /// </summary>
        /// <param name="items">The items.</param>
        public void UpdateCity(AddressBookModel items)
        {
            ////this case is used for changing the city
            Console.WriteLine("enter new city");
            string newCity = Console.ReadLine();
            if (Regex.IsMatch(newCity, @"[a-zA-Z]"))
            {
                items.PhoneNumber = newCity;
            }
            else
            {
                Console.WriteLine("invalid data");
            }
        }
    }
}
