using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.SendGrid.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.SendGrid.Client.Tests;

[Collection("Collection")]
public class SendGridClientUtilTests : FixturedUnitTest
{
    private readonly ISendGridClientUtil _util;

    public SendGridClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<ISendGridClientUtil>(true);
    }
}
