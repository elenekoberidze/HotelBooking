using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Models;

public partial class Room
{
    [Key]
    [Column("RoomID")]
    public int RoomId { get; set; }

    [Column("HotelID")]
    public int HotelId { get; set; }

    [Column("TypeID")]
    public int TypeId { get; set; }

    [StringLength(10)]
    public string RoomNumber { get; set; } = null!;

    public bool? IsAvailable { get; set; }

    [InverseProperty("Room")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [ForeignKey("HotelId")]
    [InverseProperty("Rooms")]
    public virtual Hotel Hotel { get; set; } = null!;

    [InverseProperty("Room")]
    public virtual ICollection<RoomImage> RoomImages { get; set; } = new List<RoomImage>();

    [ForeignKey("TypeId")]
    [InverseProperty("Rooms")]
    public virtual RoomType Type { get; set; } = null!;
}
