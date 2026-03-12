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
    public static IServiceCollection AddSendGridClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<ISendGridClientUtil, SendGridClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ISendGridClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddSendGridClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<ISendGridClientUtil, SendGridClientUtil>();

        return services;
    }
}