using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Shared.Models;
using CommunityToolkit.Mvvm.Input;
using ContactMAUI.MVVM.Views;
using Shared.Services;

namespace ContactMAUI.MVVM.ViewModels;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel(ContactService contactService) 
    {
        _contactService = contactService;
        UpdateContactList();
    }

    private readonly ContactService _contactService;

    [ObservableProperty]
    ObservableCollection<ContactUser> _contacts = new ObservableCollection<ContactUser>();

    [RelayCommand]
    public async Task GoToDetails(ContactUser contact)
    {
        await Shell.Current.GoToAsync(nameof(DetailsPage), new Dictionary<string, object>
        {
            { "contact", contact },
        });
    }

    [RelayCommand]
    public async Task GoToAdd()
    {
        await Shell.Current.GoToAsync($"{nameof(AddPage)}");
    }

    public void UpdateContactList()
    {
        // GetContacts() automatically updates list from file.
        var contacts = _contactService.GetContacts();

        Contacts.Clear();
        foreach (var contact in contacts) 
        {
            if (contact is ContactUser cUser)
                Contacts.Add(cUser);
        }
    }
}
