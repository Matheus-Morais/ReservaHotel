﻿using System.ComponentModel.DataAnnotations;

namespace ReservaHotel.Api.Models;

public class Reservation
{
    [Key]
    public int reservationId { get; set; }
    [Required]
    public int clientId { get; set; }
    [Required]
    public DateTime data_init { get; set; }
    [Required]
    public DateTime data_finish { get; set; }
    [Required]
    [Range(1, 4)]
    public int numberAdults { get; set; }
    [Required]
    [Range(0, 4)]
    public int numberChildren { get; set; }
}
