using ReservaHotel.Tests.Core;
using Xunit.Abstractions;

namespace ReservaHotel.Tests.Domain;

public class RoomTests : IClassFixture<RoomFixture>
{
    private readonly RoomFixture _fixture;
    private readonly ITestOutputHelper _output;

    public RoomTests (RoomFixture fixture, ITestOutputHelper output)
    {
        _fixture = fixture;
        _output = output;
    }
    [Fact]
    public void ShouldCreateRoom()
    {
        var room = _fixture.AddNewRoom();

        _output.WriteLine(room.ToString());

        room.Should().NotBeNull();
    }
}
