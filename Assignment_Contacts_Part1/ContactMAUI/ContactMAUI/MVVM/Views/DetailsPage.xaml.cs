using CommunityToolkit.Mvvm.ComponentModel;
using ContactMAUI.MVVM.ViewModels;
using Shared.Models;

namespace ContactMAUI.MVVM.Views;

[QueryProperty(nameof(Param_ContactUser), "contact")]
public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }

	public ContactUser Param_ContactUser 
	{ 
		set
		{
            if (BindingContext is DetailsViewModel viewModel)
            {
				// We have to set this to null before setting this to value because if
				// we're setting this to the same reference as it was previously, the
				// observable property won't update, which is bad if we're coming back
				// to the details page after editing a contact's credentials.
				viewModel.Contact = null;
                
				viewModel.Contact = value;
            }

            OnPropertyChanged();
        }
	}
}