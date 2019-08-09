using Microsoft.AspNetCore.Mvc;
using Phonebook.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Controllers
{
    public class ContactController : Controller
    {
        private static int idCounter = 1;

        public IActionResult Create (string name, string number)
        {
            Contact contact = new Contact(idCounter++, name, number);

            DataAccess.Contacts.Add(contact);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(int id)
        {
            Contact contactToRemove = DataAccess.Contacts
                .FirstOrDefault(x => x.Id == id);

            if (contactToRemove != null)
            {
                DataAccess.Contacts.Remove(contactToRemove);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
