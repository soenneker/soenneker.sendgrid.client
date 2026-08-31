using System.Threading.Tasks;
using System;
using SendGrid;
using System.Threading;

namespace Soenneker.SendGrid.Client.Abstract;

/// <summary>
/// Provides a lazily initialized official SendGrid client.
/// </summary>
public interface ISendGridClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the shared client for this utility instance.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<SendGridClient> Get(CancellationToken cancellationToken = default);

    /// <summary>
    /// Releases resources used by the current instance.
    /// </summary>
    new void Dispose();

    /// <summary>
    /// Asynchronously releases resources used by the current instance.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    new ValueTask DisposeAsync();
}
