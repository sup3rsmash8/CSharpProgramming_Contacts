using ContactMAUI.MVVM.ViewModels;
using ContactMAUI.MVVM.Views;
using Microsoft.Extensions.Logging;
using Shared.Services;

namespace ContactMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<ContactService>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder.Services.AddSingleton<EditViewModel>();
            builder.Services.AddSingleton<EditPage>();

            builder.Services.AddSingleton<DetailsViewModel>();
            builder.Services.AddSingleton<DetailsPage>();

            builder.Services.AddSingleton<AddViewModel>();
            builder.Services.AddSingleton<AddPage>();

            return builder.Build();
        }
    }
}