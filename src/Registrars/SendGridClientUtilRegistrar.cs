using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.SendGrid.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.SendGrid.Client.Registrars;

/// <summary>
/// An async thread-safe singleton for the SendGrid client
/// </summary>
public static class SendGridClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ISendGridClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static void AddSendGridClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCache();
        services.TryAddSingleton<ISendGridClientUtil, SendGridClientUtil>();
    }

    /// <summary>
    /// Adds <see cref="ISendGridClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static void AddSendGridClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCache();
        services.TryAddScoped<ISendGridClientUtil, SendGridClientUtil>();
    }
}
