using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using FeawosCoffeeApp.Services;
using FeawosCoffeeApp.View;
using FeawosCoffeeApp.ViewModel;

namespace FeawosCoffeeApp
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            // Register services
            builder.Services.AddSingleton<FeawosCoffeeAppService>();

            // Register ViewModels
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<DetailsViewModel>();
            builder.Services.AddTransient<OrderViewModel>();
            builder.Services.AddSingleton<OrderHistoryViewModel>();

            // Register Views
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<DetailsPage>();
            builder.Services.AddTransient<OrderPage>();
            builder.Services.AddSingleton<OrderHistoryPage>();

            return builder.Build();
        }
    }
}
