

using Nav_repro.Views;
using Prism.Navigation;

namespace Nav_repro.ViewModels;

internal class AddDeviceSuccessPageViewModel : ViewModelBase
{


    public AddDeviceSuccessPageViewModel(INavigationService navigationService) : base(navigationService)
    {
        NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
        var test = string.Empty;
    }

    public override async void OnNavigatedTo(INavigationParameters parameters)
    {

    }

    public DelegateCommand<string> NavigateCommand { get; }

    private void OnNavigateCommandExecuted(string uri)
    {
        NavigationService.NavigateAsync(uri)
            .OnNavigationError(ex => Console.WriteLine(ex));
    }

    public async Task GoBackToFleet()
    {
        var navigationParameters = new NavigationParameters();
        navigationParameters.Add(KnownNavigationParameters.SelectedTab, nameof(AssetListPage));
        await GoBackToPage(nameof(HomePage), navigationParameters);
        //await GoBackToPage(nameof(HomePage), navigationParameters);
        //await GoBackPage(nameof(HomePage), navigationParameters);
        //await GoBackToPage(nameof(AssetListPage), navigationParameters);
        //await GoBackPage(nameof(AssetListPage), navigationParameters);
    }

    public async Task GoBackToAddDevice()
    {
        var navigationParameters = new NavigationParameters();
        navigationParameters.Add(KnownNavigationParameters.SelectedTab, nameof(AddDevicePage));
        await GoBackToPage(nameof(HomePage), navigationParameters);
        //await GoBackToPage(nameof(HomePage), navigationParameters);
        //await GoBackPage(nameof(HomePage), navigationParameters);
        //await GoBackToPage(nameof(AddDevicePage), navigationParameters);
        //await GoBackPage(nameof(AddDevicePage), navigationParameters);

    }
}
