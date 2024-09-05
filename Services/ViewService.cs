using Interfaces.Views;
using Services.Interfaces;

namespace Services;

public class ViewService : IViewService
{
    private readonly IServiceProvider _serviceProvider;

    public ViewService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public INavigationPage CreatePage(Type pageType)
    {
        try
        {
            var navPage = _serviceProvider.GetService(pageType);
            if (navPage != null && navPage is INavigationPage newPage)
            {
                return newPage;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
            
        return null;
    }
}