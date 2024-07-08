
using Nav_repro.ViewModels;

namespace Nav_repro.Views
{
    public partial class AddDevicePage : ContentPage
    {

        private AddDevicePageViewModel viewModel;

        public AddDevicePage()
        {
            InitializeComponent();
        }


        void AddNewDevice_Clicked(object sender, EventArgs args)
        {
            try
            {
                viewModel = (AddDevicePageViewModel)BindingContext;
                if (viewModel != null)
                {


                    viewModel.GotoConfigurePage();
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
