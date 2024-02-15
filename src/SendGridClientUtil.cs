using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using Soenneker.Extensions.Configuration;
using Soenneker.SendGrid.Client.Abstract;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.SendGrid.Client;

///<inheritdoc cref="ISendGridClientUtil"/>
public class SendGridClientUtil : ISendGridClientUtil
{
    private readonly ILogger<SendGridClientUtil> _logger;

    private readonly AsyncSingleton<SendGridClient> _client;

    public SendGridClientUtil(IConfiguration config, ILogger<SendGridClientUtil> logger)
    {
        _logger = logger;

        _client = new AsyncSingleton<SendGridClient>(() =>
        {
            var apiKey = config.GetValueStrict<string>("SendGrid:ApiKey");
            var client = new SendGridClient(apiKey);
            return client;
        });
    }

    public ValueTask<SendGridClient> Get()
    {
        return _client.Get();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);
        return _client.DisposeAsync();
    }
}