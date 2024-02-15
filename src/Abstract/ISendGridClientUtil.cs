using System.Threading.Tasks;
using System;
using SendGrid;

namespace Soenneker.SendGrid.Client.Abstract;

/// <summary>
/// An async thread-safe singleton for the SendGrid client
/// </summary>
public interface ISendGridClientUtil : IDisposable, IAsyncDisposable
{
    ValueTask<SendGridClient> Get();
}