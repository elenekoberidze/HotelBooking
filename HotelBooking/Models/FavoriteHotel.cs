using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Models;

[PrimaryKey("UserId", "HotelId")]
public partial class FavoriteHotel
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [Key]
    [Column("HotelID")]
    public int HotelId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? SavedAt { get; set; }

    [ForeignKey("HotelId")]
    [InverseProperty("FavoriteHotels")]
    public virtual Hotel Hotel { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("FavoriteHotels")]
    public virtual User User { get; set; } = null!;
}
