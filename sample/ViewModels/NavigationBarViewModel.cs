using System.Windows.Input;
using WPFTutorial.Commands;
using WPFTutorial.Serivces;
using WPFTutorial.Store;

namespace WPFTutorial.ViewModels
{
    public class NavigationBarViewModel : BaseViewModel
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateLoginCommand { get; }

        public bool IsLoggedIn;

        private AccountStore _accountStore;

        public NavigationBarViewModel (
            AccountStore accountStore,
            INavigationService<HomeViewModel> homeNavigationService, 
            INavigationService<AccountViewModel> accountNavigateService, 
            INavigationService<LoginViewModel> loginNavigateService)
        {
            IsLoggedIn = => !_accountStore.IsLoggedIn;
            _accountStore = accountStore;
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(accountNavigateService);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigateService);
        }
    }
}
