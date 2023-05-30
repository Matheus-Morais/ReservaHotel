namespace ReservaHotel.Tests.Core;

public class ReservationFixture
{
    public Reservation MakeReservation()
    {
        DateTime start = DateTime.Now;
        DateTime end = DateTime.Parse("02/06/2023");

        var faker = new Faker<Reservation>()
            .RuleFor(b => b.reservationId, f => f.IndexFaker)
            .RuleFor(b => b.data_init, start)
            .RuleFor(b => b.data_finish, end)
            .RuleFor(b => b.numberAdults, f => f.Random.Number(1,4))
            .RuleFor(b => b.numberChildren, f => f.Random.Number(1,4));

        return faker.Generate();
    }
}
