using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Shared.Models;
using Shared.Services;

namespace ContactMAUI.MVVM.ViewModels;

public partial class AddViewModel : ObservableObject
{
    private readonly ContactService _contactService;

    public AddViewModel(ContactService contactService)
    {
        _contactService = contactService;
    }

    [ObservableProperty] ContactCreateRequest createRequest = new ContactCreateRequest();

    [RelayCommand]
    public async Task GoBack()
    {
        // Set to new so that we get fresh and empty fields
        // next time we enter this page.
        CreateRequest = new ContactCreateRequest();

        await Shell.Current.GoToAsync($"..");
    }

    [RelayCommand]
    public async Task Save()
    {
        _contactService.AddContact(CreateRequest);

        await GoBack();
    }
}
