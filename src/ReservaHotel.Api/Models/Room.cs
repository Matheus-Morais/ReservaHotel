namespace ReservaHotel.Api.Models;

public class Room
{
    public int RoomId { get; set; }
    public int NumberRoom { get; set; }
    public bool IsAvailable { get; set; }

    public override string ToString()
    {
        return $"{NumberRoom} - {IsAvailable}";
    }
}
