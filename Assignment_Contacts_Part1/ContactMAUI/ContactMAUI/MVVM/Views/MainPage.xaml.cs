using ContactMAUI.MVVM.ViewModels;

namespace ContactMAUI.MVVM.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            if (BindingContext is MainViewModel viewModel)
            {
                viewModel.UpdateContactList();
            }
        }
    }
}