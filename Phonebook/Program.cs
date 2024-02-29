using Phonebook.IPhonebookServices;
using Phonebook.Models;
using Phonebook.PhonebookServices;

namespace Phonebook
{
    
     class Program
    {
        static void Main(string[] args)
        {
            IPhonebookService repos = new PhonebookService();
            while (true)
            {
                Console.WriteLine(
                    "1.Create\n" +
                    "2.ReadAllPhoneBooks\n" +
                    "3.DeletePhoneBooksById\n" +
                    "4.ReadById\n" +
                    "5.Update\n" +
                    "6.Back");

                Console.Write(">");
                int n= int.Parse(Console.ReadLine());
                Console.WriteLine();

                if(n == 1) 
                {
                    Console.Write("Name: ");
                    string FirstName = Console.ReadLine();
                    Console.Write("Phone: ");
                    string PhoneNumber = Console.ReadLine();

                    PhonebookC phonebookC = new PhonebookC()
                    {
                        Name = FirstName,
                        Phone = PhoneNumber
                    };
                    Console.WriteLine();
                    repos.Create(phonebookC);
                    Console.WriteLine();
                }
                else if(n == 2)
                {
                    var list = repos.ReadAllPhoneBooks();
                    Console.WriteLine("+------------------------------------+---------------+---------------+");
                    Console.WriteLine("|{0,36}|{1,15}|{2,15}|", "Id", "Name", "Phone");
                    foreach (var item in list)
                    {
                        Console.WriteLine("+------------------------------------+---------------+---------------+");
                        Console.WriteLine("|{0,36}|{1,15}|{2,15}|", item.Id, item.Name, item.Phone);
                    }
                    Console.WriteLine("+------------------------------------+---------------+---------------+");
                    Console.WriteLine();
                }
            }
        }
    }
}
