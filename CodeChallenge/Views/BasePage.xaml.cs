using Interfaces.ViewModels;
using Interfaces.Views;

namespace CodeChallenge.Views;

public partial class BasePage : INavigationPage
{
    public object DataContext { get; set; }
    
    public BasePage()
    {
        InitializeComponent();
        DataContext = BindingContext = ServiceLocator.GetService<IBasePageViewModel>();
    }
}