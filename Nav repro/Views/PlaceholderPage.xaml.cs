using Nav_repro.ViewModels;

namespace Nav_repro.Views
{
    public partial class PlaceholderPage : ContentPage
    {

        PlaceholderPageViewModel viewModel;
        public PlaceholderPage()
        {
            InitializeComponent();
        }

        private async void Login(object sender, EventArgs e)
        {
            viewModel = (PlaceholderPageViewModel)BindingContext;
            if (viewModel != null)
            {
                await viewModel.Login();
            }
        }
    }

}
