
namespace Nav_repro.ViewModels;

public class HomePageViewModel : ViewModelBase
{


    public HomePageViewModel(INavigationService navigationService) : base(navigationService)
    {

    }

    public override void OnNavigatedTo(INavigationParameters parameters)
    {
        base.OnNavigatedTo(parameters);
    }



  
}
