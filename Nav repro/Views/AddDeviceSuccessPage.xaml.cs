
using Nav_repro.ViewModels;

namespace Nav_repro.Views
{
    public partial class AddDeviceSuccessPage : ContentPage
    {
        AddDeviceSuccessPageViewModel viewModel;
        public AddDeviceSuccessPage()
        {
            InitializeComponent();
        }

        private async void BackToFleet_Clicked(object sender, EventArgs e)
        {
            viewModel = (AddDeviceSuccessPageViewModel)BindingContext;
            if (viewModel != null)
            {
                await viewModel.GoBackToFleet();
            }
        }
        private async void BackToAddDevice_Clicked(object sender, EventArgs e)
        {
            viewModel = (AddDeviceSuccessPageViewModel)BindingContext;
            if (viewModel != null)
            {
                await viewModel.GoBackToAddDevice();
            }
        }

    }

}
