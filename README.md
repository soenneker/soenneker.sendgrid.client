[![](https://img.shields.io/nuget/v/soenneker.sendgrid.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sendgrid.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sendgrid.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.sendgrid.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.sendgrid.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sendgrid.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sendgrid.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.sendgrid.client/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.SendGrid.Client

Provides a lazily initialized instance of the official `SendGridClient` for mail, contacts, lists, templates, suppressions, statistics, and account APIs.

## Installation

```bash
dotnet add package Soenneker.SendGrid.Client
```

## Configuration

```json
{
  "SendGrid": {
    "ApiKey": "SG.xxxxxxxxx"
  }
}
```

## Usage

```csharp
using SendGrid;
using Soenneker.SendGrid.Client.Abstract;
using Soenneker.SendGrid.Client.Registrars;

services.AddSendGridClientUtilAsSingleton();

public sealed class SendGridScopeReader
{
    private readonly ISendGridClientUtil _sendGrid;

    public SendGridScopeReader(ISendGridClientUtil sendGrid)
    {
        _sendGrid = sendGrid;
    }

    public async Task<Response> GetScopes(CancellationToken cancellationToken)
    {
        SendGridClient client = await _sendGrid.Get(cancellationToken);
        return await client.RequestAsync(
            method: BaseClient.Method.GET,
            urlPath: "scopes",
            cancellationToken: cancellationToken);
    }
}
```

The configured key determines which SendGrid endpoints the returned client can access. Use `AddSendGridClientUtilAsScoped()` when each scope should lazily create its own official client instance.
