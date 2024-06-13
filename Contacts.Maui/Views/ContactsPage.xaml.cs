namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();

        List<Contact> contacts = new List<Contact>()
        {
            new Contact() { Name = "John Doe", Email = "john.doe@example.com" },
            new Contact() { Name = "Jane Doe", Email = "jane.doe@example.com" },
            new Contact() { Name = "John Smith", Email = "john.smith@example.com" },
            new Contact() { Name = "Smith Johnson", Email = "smith.johnson@example.com" },
        };

        listContacts.ItemsSource = contacts;
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    private void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }
}