using WPFTutorial.Store;
using WPFTutorial.ViewModels;

namespace WPFTutorial.Serivces
{
    public class NavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createTViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createTViewModel)
        {
            _navigationStore = navigationStore;
            _createTViewModel = createTViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createTViewModel();
        }
    }
}
