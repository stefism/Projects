﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Data.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public int Id { get; set; }

        public Contact(int id, string name, string number)
        {
            this.Name = name;
            this.Number = number;
            this.Id = id;
        }
    }
}
