using Microsoft.Extensions.DependencyInjection;

namespace App.core.InjectionHelper;

public static class InjectExtensions
{

    private static IServiceProvider _serviceProvider { get; set; }

    public static void SetServiceProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static T Inject<T>(this T obj)
    {
        try
        {
            obj = _serviceProvider!.GetRequiredService<T>();
        }
        catch (InvalidOperationException)
        {
        }
        return obj;
    }

}
