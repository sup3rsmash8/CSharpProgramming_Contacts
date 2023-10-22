using ContactMAUI.MVVM.ViewModels;
using Shared.Models;

namespace ContactMAUI.MVVM.Views;

[QueryProperty(nameof(Param_ContactUser), "contact")]
public partial class EditPage : ContentPage
{
	public EditPage(EditViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}

    public ContactUser Param_ContactUser
    {
        set
        {
            if (BindingContext is EditViewModel viewModel)
            {
                viewModel.Contact = value;

                viewModel.EditRequest = new ContactEditRequest()
                {
                    FirstName = value.FirstName,
                    LastName = value.LastName,
                    Email = value.Email,
                    PhoneNumber = value.PhoneNumber,
                    Address = new AddressInfo()
                    {
                        StreetName = value.Address.StreetName,
                        StreetNumber = value.Address.StreetNumber,
                        City = value.Address.City,
                        PostalCode = value.Address.PostalCode,
                    },
                };
            }

            OnPropertyChanged();
        }
    }
}