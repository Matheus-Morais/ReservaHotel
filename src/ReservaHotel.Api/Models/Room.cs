namespace ReservaHotel.Api.Models;

public class Room
{
    public int RoomId { get; set; }
    public int NumberRoom { get; set; }

    public override string ToString()
    {
        return $"{RoomId} - {NumberRoom}";
    }
}
