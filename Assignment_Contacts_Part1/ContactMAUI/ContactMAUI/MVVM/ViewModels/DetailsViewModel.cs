using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactMAUI.MVVM.Views;
using Shared.Interfaces;
using Shared.Models;
using Shared.Services;

namespace ContactMAUI.MVVM.ViewModels;

public partial class DetailsViewModel : ObservableObject
{
    public DetailsViewModel(ContactService contactService)
    {
        _contactService = contactService;
    }

    private readonly ContactService _contactService;

    [ObservableProperty]
    public ContactUser contact = new ContactUser();

    [RelayCommand]
    public async Task GoToEdit(ContactUser contact)
    {
        await Shell.Current.GoToAsync(nameof(EditPage), new Dictionary<string, object>
        {
            { "contact", contact },
        });
    }

    [RelayCommand]
    public async Task Remove(ContactUser contact)
    {
        _contactService.DeleteContact(x => x == contact);
        await GoBack();
    }

    [RelayCommand]
    public async Task GoBack()
    {
        await Shell.Current.GoToAsync($"..");
    }
}
