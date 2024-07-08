

using Nav_repro.Views;

namespace Nav_repro.ViewModels;

internal class PlaceholderPageViewModel : ViewModelBase
{


    public PlaceholderPageViewModel(INavigationService navigationService) : base(navigationService)
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

    internal async Task Login()
    {
        await GotoPage(nameof(HomePage));
    }
}
