using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Phonebook.IPhonebookServices;
using Phonebook.Models;

namespace Phonebook.PhonebookServices
{
    internal class PhonebookService : IPhonebookService
    {
        public PhonebookC Create(PhonebookC phonebook)
        {
            string allData = File.ReadAllText(Helper.Path);
            string Data = phonebook.ToString();
            allData=Data+"\n"+allData;
            File.WriteAllText(Helper.Path,allData);
            return phonebook;
        }

        public bool Delete(Guid Id)
        {
            bool result =false;
            string[] phonebooksData = File.ReadAllLines(Helper.Path);
            List<string> phonebooks = new List<string>(phonebooksData);
            foreach (string phonebookData in phonebooksData) 
            {
                string[] data = phonebookData.Split();
                if (Id == Guid.Parse(data[0]))
                {
                    phonebooks.Remove(phonebookData);
                    File.WriteAllLines(Helper.Path, phonebooks);
                    result = true;
                }
            }
            return result;
        }

        public List<PhonebookC> ReadAllPhoneBooks()
        {
            List<PhonebookC> phonebooks = new List<PhonebookC>();
            string[] phonebooksData = File.ReadAllLines(Helper.Path);

            foreach (string phonebookData in phonebooksData)
            {
                string[] data = phonebookData.Split();
                phonebooks.Add(new PhonebookC()
                {
                    Name = data[1],
                    Phone = data[2]

                });
            }
            return phonebooks;
        }

        public PhonebookC ReadById(Guid Id)
        {
            PhonebookC phonebookC = null;
            string[] phonebooksdata = File.ReadAllLines(Helper.Path);
            foreach(string phonebookData in phonebooksdata)
            {
                string[] data = phonebookData.Split();
                if (Id == Guid.Parse(data[0]))
                    phonebookC = new PhonebookC()
                    {
                        Name = data[1],
                        Phone = data[2]
                    };
            }
            return phonebookC;
            
        }

        public PhonebookC Update(PhonebookC phonebook, Guid Id)
        {
            string[] phonbooksData = File.ReadAllLines(Helper.Path);
            List<string> phonbooks = new List<string>(phonbooksData);
            foreach( string phonebookData in phonbooksData)
            {
                string[] data = phonebookData.Split();
                if(Id == Guid.Parse(data[0]))
                {
                    phonebook.Id=Id;
                    phonbooks.Remove(phonebookData);
                    phonbooks.Add(phonebook.ToString());
                    File.WriteAllLines(Helper.Path, phonbooks); 
                }
            }
            return phonebook;
        }
    }
}
