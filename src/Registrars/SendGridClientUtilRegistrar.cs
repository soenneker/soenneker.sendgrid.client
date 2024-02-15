using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.SendGrid.Client.Abstract;

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
        services.TryAddSingleton<ISendGridClientUtil, SendGridClientUtil>();
    }

    /// <summary>
    /// Adds <see cref="ISendGridClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static void AddSendGridClientUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<ISendGridClientUtil, SendGridClientUtil>();
    }
}
