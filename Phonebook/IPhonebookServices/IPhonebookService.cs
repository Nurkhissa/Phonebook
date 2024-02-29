using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Phonebook.IPhonebookServices
{
    interface IPhonebookService
    {
        PhonebookC Create (PhonebookC phonebook);
        List<PhonebookC> ReadAllPhoneBooks();
        bool Delete(Guid Id);
        PhonebookC ReadById(Guid Id);
        PhonebookC Update(PhonebookC phonebook, Guid Id);


    }
}
