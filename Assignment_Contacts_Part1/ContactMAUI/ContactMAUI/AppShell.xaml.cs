using ContactMAUI.MVVM.Views;

namespace ContactMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddPage), typeof(AddPage));
            Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
            Routing.RegisterRoute(nameof(EditPage), typeof(EditPage));
            //Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        }
    }
}