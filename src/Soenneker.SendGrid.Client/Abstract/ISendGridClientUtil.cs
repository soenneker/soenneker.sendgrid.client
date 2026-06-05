using System.Threading.Tasks;
using System;
using SendGrid;
using System.Threading;

namespace Soenneker.SendGrid.Client.Abstract;

/// <summary>
/// An async thread-safe singleton for the SendGrid client
/// </summary>
public interface ISendGridClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<SendGridClient> Get(CancellationToken cancellationToken = default);
}