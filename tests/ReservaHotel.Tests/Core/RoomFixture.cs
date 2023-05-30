namespace ReservaHotel.Tests.Core;

public class RoomFixture
{
    public Room AddNewRoom()
    {
        var faker = new Faker<Room>()
            .RuleFor(b => b.NumberRoom, f => f.IndexFaker)
            .RuleFor(b => b.IsAvailable, f => f.Equals(true));

        return faker.Generate();
    }
}
