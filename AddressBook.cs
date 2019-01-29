//-----------------------------------------------------------------------
// <copyright file="AddressBook.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;

    /// <summary>
    /// this class is used for storing the data of a person
    /// </summary>
    public class AddressBook
    {
        /// <summary>
        /// Addresses the book details.
        /// </summary>
        /// <exception cref="Exception">casting exception</exception>
        public void AddressBookDetails()
        {           
            try
            {
                ////this variable is used for cases in the switch case
                int caseCondition;
                ////this variable is used for do while termination
                string doCondition = null;
                do
                {
                    Console.WriteLine("enter 1 for add person");
                    Console.WriteLine("enter 2 for edit information");
                    Console.WriteLine("enter 3 for delete person");
                    Console.WriteLine("enter 4 for sort by last name");
                    Console.WriteLine("enter 5 for sort by zip");
                    Console.WriteLine("enter 6 for print address book ");
                    caseCondition = Convert.ToInt32(Console.ReadLine());
                    ////creating the object of address utility class
                    AddressUtility addressUtility = new AddressUtility();
                    switch (caseCondition)
                    {
                        case 1:
                            ////this case is used for adding person
                            addressUtility.AddPerson();
                            break;
                        case 2:
                            ////this case is used for update
                            addressUtility.Update();
                            break;
                        case 6:
                            ////this case is used for printing the address book
                            addressUtility.PrintAddressBook();
                            break;
                        case 3:
                            ////this data is used for delete data in address book
                            addressUtility.DeleteData();
                            break;
                        case 4:
                            ////this case is used for sorting by the last name
                            addressUtility.SortByLastName();
                            break;
                        case 5:
                            ////this case is used for sorting the by zip Code
                            addressUtility.SortByZip();
                            break;
                    }

                    Console.WriteLine("enter y to continue");
                    doCondition = Console.ReadLine();
                }
                while (doCondition.Equals("y"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
