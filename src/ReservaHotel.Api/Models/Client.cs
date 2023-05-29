using System.ComponentModel.DataAnnotations;

namespace ReservaHotel.Api.Models;

public class Client
{
    public int clientId { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    [MinLength(11)]
    [MaxLength(11)]
    public required string CPF { get; set; }

    public override string ToString()
    {
        return $"{clientId} - {Name} - {CPF}";
    }
}
