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
            var contact = _contacts.FirstOrDefault(x => x.Id == id);

            if (contact != null)
            {
                return new Contact()
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Address = contact.Address
                };
            }
            return null;
        }

        public static void UpdateContact(int id, Contact contact)
        {
            if (id != contact.Id) return;

            var contactToUpdate = _contacts.FirstOrDefault(x => x.Id == id);
            
            if (contactToUpdate != null)
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Address = contact.Address;
            }
        }

        public static void AddContact(Contact contact)
        {
            var maxId = _contacts.Max(x => x.Id);
            contact.Id = maxId + 1;
            _contacts.Add(contact);
        }

        public static void RemoveContact(int id)
        {
            var contact = _contacts.FirstOrDefault(x => x.Id == id);

            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        public static List<Contact> SearchContacts(string filterText)
        {
            var contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();

            if (contacts.Count == 0)
            {
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                return contacts;
            }

            if (contacts.Count == 0)
            {
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                return contacts;
            }

            if (contacts.Count == 0)
            {
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                return contacts;
            }

            return contacts;
        }
    }
}
