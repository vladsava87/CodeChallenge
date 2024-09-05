namespace Interfaces.Navigation;

public interface INavigationParameters : IEnumerable<KeyValuePair<string, object>>
{
    void AddParameter(string key, object value);
    T GetParameter<T>(string key);
}