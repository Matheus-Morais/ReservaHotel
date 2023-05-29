using ReservaHotel.Tests.Core;
using Xunit.Abstractions;

namespace ReservaHotel.Tests.Domain;

public class ClientTests : IClassFixture<ClientFixture>
{
    private readonly ClientFixture _fixture;
    private readonly ITestOutputHelper _output;

    public ClientTests (ClientFixture fixture, ITestOutputHelper output)
    {
        _fixture = fixture;
        _output = output;
    }

    [Fact]
    public void ShouldCreateClient()
    {
        var client = _fixture.AddNewClient();

        _output.WriteLine(client.ToString());

        client.Should()
            .NotBeNull();

    }
}
