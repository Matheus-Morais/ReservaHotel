using Microsoft.EntityFrameworkCore;
using ReservaHotel.Api.Models;

namespace ReservaHotel.Api.Data;

public class HotelContext : DbContext
{
    public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Room> Rooms { get; set; }

}
