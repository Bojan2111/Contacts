using Contacts.Maui.Models;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Contact _contact;
    public EditContactPage()
    {
        InitializeComponent();
    }

    private void btnBack_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    public string ContactId
    {
        set
        {
            _contact = ContactRepository.GetContact(int.Parse(value));
            lblName.Text = _contact.Name;
        }
    }
}