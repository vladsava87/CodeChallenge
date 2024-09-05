using Interfaces.ViewModels;
using Interfaces.Views;

namespace CodeChallenge.Views;

public partial class CoffeeDetailPage : ICoffeeDetailPage
{
    public CoffeeDetailPage()
    {
        InitializeComponent();
        DataContext = BindingContext = ServiceLocator.GetService<ICoffeeDetailViewModel>();
    }
}