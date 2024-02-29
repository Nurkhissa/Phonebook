using ConsoleTables;
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

                else if (n == 3)
                {
                    Console.Write("Enter the ID number: ");
                    string IdNumber = Console.ReadLine();   
                    Guid checker = Guid.Parse(IdNumber);

                    if (repos.Delete(checker))
                    {
                        Console.WriteLine("Deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine("was not deleted");
                    }
                    Console.WriteLine( );
                }

                else if( n == 4)
                {
                    Console.Write("Enter the ID number: ");
                    string IdNumber = Console.ReadLine();
                    
                    var phonebook = repos.ReadById(Guid.Parse(IdNumber));

                    var table = new ConsoleTable("Id", "Name", "Phone");
                    table.AddRow(phonebook.Id, phonebook.Name, phonebook.Phone);
                    table.Write();
                    Console.WriteLine();
                }

                else if(n == 5)
                {
                    Console.Write("Enter the ID number: ");
                    string IdNumber = Console.ReadLine();

                    Console.Write("Name: ");
                    string FirstName = Console.ReadLine();
                    Console.Write("Phone: ");
                    string PhoneNumber = Console.ReadLine();

                    PhonebookC phonebookC = new PhonebookC()
                    {
                        Name = FirstName,
                        Phone = PhoneNumber
                    };
                    repos.Update(phonebookC, Guid.Parse(IdNumber));
                    Console.WriteLine();
                }

            }
        }
    }
}
