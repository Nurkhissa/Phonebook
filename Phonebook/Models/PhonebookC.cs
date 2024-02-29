using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Models
{
    class PhonebookC
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Phone; ;
        }


    }
}
