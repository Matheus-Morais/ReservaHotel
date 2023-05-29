
namespace ReservaHotel.Tests.Core;

public class ClientFixture
{
    public Client AddNewClient()
    {
        var faker = new Faker<Client>()
            .RuleFor(b => b.clientId, f => f.IndexFaker)
            .RuleFor(b => b.Name, f => f.Person.FullName)
            .RuleFor(b => b.CPF, f => f.Random.ReplaceNumbers("###.###.###.##"));

        return faker.Generate();
    }
}
