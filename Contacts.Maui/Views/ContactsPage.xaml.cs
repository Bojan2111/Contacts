using Contacts.Maui.Models;
using System.Collections.ObjectModel;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
    public ContactsPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        LoadContacts();
    }

    private void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());

        listContacts.ItemsSource = contacts;
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (listContacts.SelectedItem != null)
        {
            Contact contact = listContacts.SelectedItem as Contact;
            await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={contact.Id}");
        }
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        listContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;

        ContactRepository.RemoveContact(contact.Id);

        LoadContacts();
    }
}