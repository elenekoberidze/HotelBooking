using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Models;

public partial class Booking
{
    [Key]
    [Column("BookingID")]
    public int BookingId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("RoomID")]
    public int RoomId { get; set; }

    public DateOnly CheckInDate { get; set; }

    public DateOnly CheckOutDate { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? TotalPrice { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [ForeignKey("RoomId")]
    [InverseProperty("Bookings")]
    public virtual Room Room { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Bookings")]
    public virtual User User { get; set; } = null!;
}
