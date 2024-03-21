using WPFTutorial.Store;
using WPFTutorial.ViewModels;

namespace WPFTutorial.Serivces
{
    public class LayoutNavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;

        private readonly Func<TViewModel> _createTViewModel;

        private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;

        public LayoutNavigationService(
            NavigationStore navigationStore, Func<TViewModel> createLayoutViewModel, 
            Func<NavigationBarViewModel> createNavigationBarViewModel)
        {
            _navigationStore = navigationStore;
            _createTViewModel = createLayoutViewModel;
            _createNavigationBarViewModel = createNavigationBarViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(_createTViewModel(), _createNavigationBarViewModel());
        }
    }
}
