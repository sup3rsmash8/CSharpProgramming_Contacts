using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ContactMAUI.MVVM.Views;
using Shared.Models;
using Shared.Services;

namespace ContactMAUI.MVVM.ViewModels;

public partial class EditViewModel : ObservableObject
{
    public EditViewModel(ContactService contactService)
    {
        _contactService = contactService;
    }

    private readonly ContactService _contactService;

    [ObservableProperty]
    public ContactUser contact = new ContactUser();

    [ObservableProperty]
    public ContactEditRequest editRequest = new ContactEditRequest();

    [RelayCommand]
    public async Task Save()
    {
        _contactService.EditContact(Contact, EditRequest);

        await Shell.Current.GoToAsync(nameof(DetailsPage), new Dictionary<string, object>
        {
            { "contact", Contact },
        });
    }
}
