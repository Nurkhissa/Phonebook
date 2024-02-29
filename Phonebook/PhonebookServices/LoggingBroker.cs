using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phonebook.IPhonebookServices;
using Phonebook.Models;
using Phonebook.PhonebookServices;

namespace Phonebook.PhonebookServices
{
    public class LoggingBroker
    {
        IPhonebookService repos = new PhonebookService();

        public void CreateBook()
        {
            Console.Write("Name: ");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Phone: ");
            string PhoneNumber = Console.ReadLine();

            PhonebookC phonebookC = new PhonebookC()
            {
                Name = FirstName,
                Phone = PhoneNumber
            };
            Console.WriteLine();
        } 

        static void ReadAllPhoneBooks(PhonebookService repos)
        {

        }

    }
}
