
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

using Microsoft.Maui.Controls;
using Microsoft.Maui;
using System.Diagnostics;
using Controls.UserDialogs.Maui;


namespace Nav_repro.ViewModels
{
    public class ViewModelBase : BindableBase, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }





        public bool IsOnline()
        {
            return true;
        }

        public bool IsIOSDevice { get; set; }

        private bool _canNavigate = true;
        public bool CanNavigate
        {
            get => _canNavigate;
            set => SetProperty(ref _canNavigate, value);
        }

        private bool CanExecuteCommands { get; set; } = true;

        public ICommand? CreateExclusiveCommand(Func<Task> task, bool isReadonly = false)
        {
            if (!isReadonly)
            {
                return new Command(async () =>
                {
                    if (!CanExecuteCommands) return;
                    CanExecuteCommands = false;
                    await task();
                    CanExecuteCommands = true;
                });
            }
            return null;
        }

        public ICommand? CreateExclusiveCommand(Action task, bool isReadonly = false)
        {
            if (!isReadonly)
            {
                return new Command(() =>
                {
                    if (!CanExecuteCommands) return;
                    CanExecuteCommands = false;
                    task();
                    CanExecuteCommands = true;
                });
            }
            return null;
        }

     
        public ViewModelBase(INavigationService navigationService)
        {
            IsIOSDevice = DeviceInfo.Platform == DevicePlatform.iOS;
            NavigationService = navigationService;
            _title = GetType().Name.Replace("ViewModel", string.Empty); ;

        }
        public virtual void Initialize(INavigationParameters parameters)
        {
        }


        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
            //WeakReferenceMessenger.Default.UnregisterAll(this);
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
            Console.WriteLine($"{this.GetType().Name} OnNavigatedTo...");

        }

        public IDisposable Alert(string message, string title = null, string okText = null)
        {

            return UserDialogs.Instance.Alert(message, title, okText);
        }

        public Task AlertAsync(string message, string title = null, string okText = null, CancellationToken? cancelToken = null)
        {
            return UserDialogs.Instance.AlertAsync(message, title, okText, cancelToken: cancelToken);
        }

        public async Task GotoPage(string pageName, NavigationParameters? parameters = null)
        {
            Console.WriteLine($"{this.GetType().Name} GotoPage: {pageName} CanNavigate {CanNavigate}");
            if (CanNavigate)
            {
                CanNavigate = false;
                var result = await NavigationService.NavigateAsync(pageName, parameters);
                Console.WriteLine($"{this.GetType().Name} GotoPage: {pageName} Success: {result.Success}");

                if(!result.Success)
                {
                    Console.WriteLine("Can't nav");
                }
                CanNavigate = true;
            }
        }

        public async Task GoBackToPage(string pageName, NavigationParameters? parameters = null)
        {
            Console.WriteLine($"{this.GetType().Name} GoBacktoPage: {pageName} CanNavigate {CanNavigate}");
            if (CanNavigate)
            {
                CanNavigate = false;
                var result = await NavigationService.GoBackToAsync(pageName, parameters);
                Console.WriteLine($"{this.GetType().Name} GoBacktoPage: {pageName} Success: {result.Success}");

                if (!result.Success)
                {
                    Console.WriteLine("Can't nav");
                }
                CanNavigate = true;
            }
        }

        public async Task GoBackPage(string pageName, NavigationParameters? parameters = null)
        {
            Console.WriteLine($"{this.GetType().Name} goback CanNavigate {CanNavigate}");
            if (CanNavigate)
            {
                CanNavigate = false;
                var result = await NavigationService.GoBackAsync(pageName, parameters);
                Console.WriteLine($"{this.GetType().Name} goback Success: {result.Success}");

                if (!result.Success)
                {
                    Console.WriteLine("Can't nav");
                }
                CanNavigate = true;
            }
        }

        public async Task GoBack(NavigationParameters? parameters = null)
        {
            Console.WriteLine($"{this.GetType().Name} goback CanNavigate {CanNavigate}");
            if (CanNavigate)
            {
                CanNavigate = false;
                var result = await NavigationService.GoBackAsync(parameters);
                Console.WriteLine($"{this.GetType().Name} goback Success: {result.Success}");

                if (!result.Success)
                {
                    Console.WriteLine("Can't nav");
                }
                CanNavigate = true;
            }
        }


        public virtual void Destroy()
        {

        }
    }
}
