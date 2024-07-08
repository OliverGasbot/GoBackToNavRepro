using Nav_repro.ViewModels;

namespace Nav_repro.Views
{
    public partial class AssetConfigurationPage : ContentPage
    {
        AssetConfigurationPageViewModel viewModel;
        public AssetConfigurationPage()
        {
            InitializeComponent();
        }


        private async void Next_Clicked(object sender, EventArgs e)
        {
            viewModel = (AssetConfigurationPageViewModel)BindingContext;
            if (viewModel != null)
            {
                await viewModel.GoToAddDeviceSuccessPage();
            }
        }
        private async void Back_Clicked(object sender, EventArgs e)
        {
            viewModel = (AssetConfigurationPageViewModel)BindingContext;
            if (viewModel != null)
            {
                await viewModel.GoBack();
            }
        }
    }

}
