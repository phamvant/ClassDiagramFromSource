using System.Windows.Input;
using WPFTutorial.Commands;
using WPFTutorial.Models;
using WPFTutorial.Serivces;
using WPFTutorial.Store;

namespace WPFTutorial.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username = "";

        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _email = string.Empty;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(AccountStore accountStore, INavigationService<AccountViewModel> navigateAccountService)
        {
            LoginCommand = new LoginCommand(accountStore, navigateAccountService, this);
        }
    }
}
