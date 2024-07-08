using Controls.UserDialogs.Maui;
using Microsoft.Extensions.Logging;
using Nav_repro.ViewModels;
using Nav_repro.Views;

namespace Nav_repro
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
            builder.UseUserDialogs(() =>
             {
                 //setup your default styles for dialogs
                 AlertConfig.DefaultBackgroundColor = Colors.LightGrey;

                 ToastConfig.DefaultCornerRadius = 15;
             });
            builder.UsePrism(new DryIocContainerExtension(), prism =>
            {
                prism.RegisterTypes(containerRegistry =>
                {
                    //Prism used for navigation
                    PlatformInitializer.RegisterPages(containerRegistry);
                });

                prism.CreateWindow(async (container, navigation) =>
                {
                    //ApplyAppConfigurationAsync(DataConstants.AppSettingConfig);

                    var loggedIn = true;
                    var p = navigation.CreateBuilder();
                    if (loggedIn)
                        p.AddSegment<RootPage>().AddSegment<HomePage>();
                    else
                        p.AddSegment<RootPage>().AddSegment<PlaceholderPage>();
                        //fake login page


                    navigation.NavigateAsync(p.Uri).OnNavigationError(x => LogPrismError(x));
                });
            });

#if DEBUG
                builder.Logging.AddDebug();
#endif

                return builder.Build();
            }

        private static Task LogPrismError(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Task.CompletedTask;
        }
    }



        public static class PlatformInitializer
        {

            public static void RegisterPages(IContainerRegistry containerRegistry)
            {
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<RootPage, RootPageViewModel>();

            containerRegistry.RegisterForNavigation<AssetListPage, AssetListPageViewModel>();
            containerRegistry.RegisterForNavigation<AddDevicePage, AddDevicePageViewModel>();
            containerRegistry.RegisterForNavigation<PlaceholderPage, PlaceholderPageViewModel>();

            containerRegistry.RegisterForNavigation<AssetConfigurationPage, AssetConfigurationPageViewModel>();
            containerRegistry.RegisterForNavigation<AddDeviceSuccessPage, AddDeviceSuccessPageViewModel>();
            }
        } 
    }
