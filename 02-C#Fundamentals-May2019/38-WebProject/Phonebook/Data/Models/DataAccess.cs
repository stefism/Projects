using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Data.Models
{
    public class DataAccess
    {
        public static List<Contact> Contacts { get; set; }

        static DataAccess()
        {
            Contacts = new List<Contact>();
            
        }
    }
}
