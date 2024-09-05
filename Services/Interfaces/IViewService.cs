using Interfaces.Views;

namespace Services.Interfaces;

public interface IViewService
{
    INavigationPage CreatePage(Type pageType);
}