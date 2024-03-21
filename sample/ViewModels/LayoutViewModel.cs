namespace WPFTutorial.ViewModels
{
    public class LayoutViewModel : BaseViewModel
    {

        public BaseViewModel CurrentContentViewModel { get; }

        public NavigationBarViewModel NavigationBarViewModel { get; }

        public LayoutViewModel(BaseViewModel currentContentViewModel, NavigationBarViewModel navigationBarViewModel)
        {
            CurrentContentViewModel = currentContentViewModel;
            NavigationBarViewModel = navigationBarViewModel;
        }
    }
}
