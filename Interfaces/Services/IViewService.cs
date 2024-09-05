using Interfaces.Views;

namespace Interfaces.Services;

public interface IViewService
{
    INavigationPage CreatePage(Type pageType);
}