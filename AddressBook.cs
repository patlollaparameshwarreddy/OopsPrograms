using System;
using System.Collections.Generic;
using System.Text;

namespace OopsPrograms
{
    class AddressBook
    {
        public void AddressBookDetails()
        {           
            try
            {
                int caseCondition;
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
                    switch (caseCondition)
                    {
                        case 1:
                            AddressUtility addressUtility = new AddressUtility();
                            addressUtility.AddPerson();
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
