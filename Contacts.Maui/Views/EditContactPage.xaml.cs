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

    private void btnCancel_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    public string ContactId
    {
        set
        {
            _contact = ContactRepository.GetContact(int.Parse(value));
            if ( _contact != null )
            {
                entryName.Text = _contact.Name;
                entryEmail.Text = _contact.Email;
                entryPhone.Text = _contact.Phone;
                entryAddress.Text = _contact.Address;
            }
        }
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        _contact.Name = entryName.Text;
        _contact.Email = entryEmail.Text;
        _contact.Phone = entryPhone.Text;
        _contact.Address = entryAddress.Text;

        ContactRepository.UpdateContact(_contact.Id, _contact);

        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }
}