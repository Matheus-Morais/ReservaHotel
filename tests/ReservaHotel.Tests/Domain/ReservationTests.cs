using ReservaHotel.Tests.Core;
using Xunit.Abstractions;

namespace ReservaHotel.Tests.Domain;

public class ReservationTests : IClassFixture<ReservationFixture>
{
    private readonly ReservationFixture _fixtureReservation;
    private readonly RoomFixture _fixtureRoom;
    private readonly ITestOutputHelper _output;

    public ReservationTests(ReservationFixture fixtureReservation, ITestOutputHelper output, RoomFixture fixtureRoom)
    {
        _fixtureReservation = fixtureReservation;
        _output = output;
        _fixtureRoom = fixtureRoom;
    }

    [Fact]
    public void ShouldCreateReservation()
    {
        var room = _fixtureRoom.AddNewRoom();
        var reservation = _fixtureReservation.MakeReservation();

        _output.WriteLine(reservation.ToString());
        _output.WriteLine(room.ToString());

        reservation.Should()
            .NotBeNull();

    }
}
