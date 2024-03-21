using WPFTutorial.Store;
using WPFTutorial.ViewModels;

namespace WPFTutorial.Serivces
{
    public class ParamNavigationService<TParam, TViewModel>
        where TViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;

        private readonly Func<TParam, TViewModel> _createViewModel;
        public ParamNavigationService(NavigationStore navigationStore, Func<TParam, TViewModel> createViewModel )
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate(TParam param)
        {
            _navigationStore.CurrentViewModel = _createViewModel(param); 
        }

    }
}
