
using Nav_repro.Views;
using Controls.UserDialogs.Maui;
using Nav_repro.Resources;

namespace Nav_repro.ViewModels;

internal class RootPageViewModel : ViewModelBase
{


    public RootPageViewModel(INavigationService navigationService) : base(navigationService)
    {
        
    }

    public override async void OnNavigatedTo(INavigationParameters parameters)
    {

        if (parameters.GetNavigationMode() != Prism.Navigation.NavigationMode.Back)
            return;

        using (UserDialogs.Instance.Loading(AppString.loading_label))
        {
                var result = await NavigationService.NavigateAsync(nameof(HomePage), new NavigationParameters {
                    { KnownNavigationParameters.SelectedTab, nameof(AssetListPage) }
                });

                if (!result.Success)
                {
                    Console.WriteLine(result); 
                    //throw probably
                }
            }
        }
    }


