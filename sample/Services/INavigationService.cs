using WPFTutorial.ViewModels;

namespace WPFTutorial.Serivces
{
    public interface INavigationService<TviewModel> where TviewModel : BaseViewModel
    {
       public void Navigate();
    }
}
