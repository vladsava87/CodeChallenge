using System.Collections;
using Interfaces.Navigation;

namespace Services.Navigation;

public class NavigationParameters : INavigationParameters
{
    private readonly IList<KeyValuePair<string, object>> _parameters = new List<KeyValuePair<string, object>>();

    public NavigationParameters()
    {
        
    }

    public NavigationParameters(string key, object value)
    {
        AddParameter(key, value);
    }
    
    public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    {
        return _parameters.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void AddParameter(string key, object value)
    {
        _parameters.Add(new KeyValuePair<string, object>(key, value));
    }

    public T GetParameter<T>(string key)
    {
        var kvp = _parameters.FirstOrDefault(p => p.Key == key);
        if (kvp.Key == null)
        {
            return default;
        }
        
        return (T)kvp.Value;
    }
}