//-----------------------------------------------------------------------
// <copyright file="RegularExpression.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//----------------------------------------------------------------------
namespace OopsPrograms
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    /// <summary>
    /// this class is used for replacing the regular expression with the string
    /// </summary>
    class RegularExpression
    {
        /// <summary>
        /// Replacings the regular expression with string.
        /// </summary>
        public void ReplacingRegularExpressionWithString()
        {
            
            string message = "Hello <<name>>, We have your full name as <<full name>> in our system." +
                             " your contact number is 91xxxxxxxxxx. " +
                             "Please,let us know in case of any clarification Thank you BridgeLabz 01/01/2016.";
            //Console.WriteLine(message);
            Console.WriteLine("enter name");
            //string name = Console.ReadLine();
            Console.WriteLine("enter your full name");
            //string fullName = Console.ReadLine();
            Console.WriteLine("enter your mobile number");
            //long mobileNumber = Convert.ToInt32(Console.ReadLine());
            string datePattern = @"/d/d[/]/d/d[/]/d/d/d/d";
            Console.WriteLine(Regex.Match(message, datePattern)); 


        }
    }
}
