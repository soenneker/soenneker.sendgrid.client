using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using Soenneker.Extensions.Configuration;
using Soenneker.SendGrid.Client.Abstract;
using Soenneker.Utils.AsyncSingleton;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.SendGrid.Client;

///<inheritdoc cref="ISendGridClientUtil"/>
public class SendGridClientUtil : ISendGridClientUtil
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly ILogger<SendGridClientUtil> _logger;

    private readonly AsyncSingleton<SendGridClient> _client;

    public SendGridClientUtil(IConfiguration config, IHttpClientCache httpClientCache, ILogger<SendGridClientUtil> logger)
    {
        _httpClientCache = httpClientCache;
        _logger = logger;

        _client = new AsyncSingleton<SendGridClient>( () =>
        {
            var apiKey = config.GetValueStrict<string>("SendGrid:ApiKey");

            logger.LogDebug("Connecting SendGrid client...");

           // HttpClient httpClient = await httpClientCache.Get(nameof(SendGridClientUtil));

           // var options = new SendGridClientOptions { ApiKey = apiKey };

            return new SendGridClient(apiKey);
        });
    }

    public ValueTask<SendGridClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        //_httpClientCache.RemoveSync(nameof(SendGridClientUtil));

        _client.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        //await _httpClientCache.Remove(nameof(SendGridClientUtil));

        await  _client.DisposeAsync();
    }
}