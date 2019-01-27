using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace OopsPrograms
{
    class AddressUtility
    {
        public void AddPerson()
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
            if(Regex.IsMatch(phoneNumber, @"[0-9]{10}") && Regex.IsMatch(zip, @"[0-9]{6}") && Regex.IsMatch(firstname, @"[a-zA-Z]") && Regex.IsMatch(lastname, @"[a-zA-Z]") && Regex.IsMatch(city, @"[a-zA-Z]") && Regex.IsMatch(state, @"[a-zA-Z]"))
            {
                AddressBookModel addressBookModel = new AddressBookModel()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Address = address,
                    City = city,
                    State = state,
                    ZipCode = zip,
                    PhoneNuumber = phoneNumber
                };
                var convertedJson = JsonConvert.SerializeObject(addressBookModel);
                File.WriteAllText(constants.AddressBook, convertedJson);
                Console.WriteLine("new person added");
            }
            else
            {
                Console.WriteLine("enter proper details");
            }
        }
    }
}
