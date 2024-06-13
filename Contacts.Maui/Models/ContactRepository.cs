using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Contacts.Maui.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>()
        {
            new Contact() { Id=1, Name = "John Doe", Email = "john.doe@example.com" },
            new Contact() { Id=2, Name = "Jane Doe", Email = "jane.doe@example.com" },
            new Contact() { Id=3, Name = "John Smith", Email = "john.smith@example.com" },
            new Contact() { Id=4, Name = "Smith Johnson", Email = "smith.johnson@example.com" },
        };

        public static List<Contact> GetContacts()
        {
            return _contacts;
        }

        public static Contact GetContact(int id)
        {
            return _contacts.FirstOrDefault(x => x.Id == id);
        }
    }
}
