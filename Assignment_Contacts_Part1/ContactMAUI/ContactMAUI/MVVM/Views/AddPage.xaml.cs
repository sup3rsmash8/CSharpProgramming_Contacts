using ContactMAUI.MVVM.ViewModels;

namespace ContactMAUI.MVVM.Views;

public partial class AddPage : ContentPage
{
	public AddPage(AddViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;

    }
}