using System.Windows.Input;
using WPFTutorial.Store;
using WPFTutorial.Commands;
using WPFTutorial.Serivces;

namespace WPFTutorial.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel(INavigationService<LoginViewModel> navigateLoginService) 
        {
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigateLoginService);
        }
    }
}
