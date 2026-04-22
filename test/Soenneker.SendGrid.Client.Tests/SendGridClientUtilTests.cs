using Soenneker.SendGrid.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.SendGrid.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class SendGridClientUtilTests : HostedUnitTest
{
    private readonly ISendGridClientUtil _util;

    public SendGridClientUtilTests(Host host) : base(host)
    {
        _util = Resolve<ISendGridClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
