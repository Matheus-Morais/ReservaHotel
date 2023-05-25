namespace ReservaHotel.Api.Models;

public class Reservation
{
    public int reservationId { get; set; }
    public DateTime data_init { get; set; }
    public DateTime data_finish { get; set; }
    public int numberAdults { get; set; }
    public int numberChildren { get; set; }
}
