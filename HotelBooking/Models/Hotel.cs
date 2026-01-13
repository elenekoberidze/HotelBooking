using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Models;

public partial class Hotel
{
    [Key]
    [Column("HotelID")]
    public int HotelId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    [StringLength(50)]
    public string City { get; set; } = null!;

    [StringLength(255)]
    public string Address { get; set; } = null!;

    [Column(TypeName = "decimal(2, 1)")]
    public decimal? Rating { get; set; }

    [InverseProperty("Hotel")]
    public virtual ICollection<FavoriteHotel> FavoriteHotels { get; set; } = new List<FavoriteHotel>();

    [InverseProperty("Hotel")]
    public virtual ICollection<HotelImage> HotelImages { get; set; } = new List<HotelImage>();

    [InverseProperty("Hotel")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [InverseProperty("Hotel")]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
