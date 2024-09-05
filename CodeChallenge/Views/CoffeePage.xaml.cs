using Interfaces.ViewModels;
using Interfaces.Views;

namespace CodeChallenge.Views;

public partial class CoffeePage : ICoffeePage
{
    public CoffeePage()
    {
        InitializeComponent();
        DataContext = BindingContext = ServiceLocator.GetService<ICoffeeViewModel>();
    }
}