using Soenneker.SendGrid.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.SendGrid.Client.Tests;

[Collection("Collection")]
public class SendGridClientUtilTests : FixturedUnitTest
{
    private readonly ISendGridClientUtil _util;

    public SendGridClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<ISendGridClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
