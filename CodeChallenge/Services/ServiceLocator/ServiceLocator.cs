namespace CodeChallenge;

public static class ServiceLocator
{
    public static TService GetService<TService>()
        => Current.GetService<TService>();

    public static IServiceProvider Current
        =>
#if ANDROID
            MauiApplication.Current.Services;
#elif IOS || MACCATALYST
			MauiUIApplicationDelegate.Current.Services;
#else
			null;
#endif
}