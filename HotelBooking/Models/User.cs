using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Models;

[Index("Username", Name = "UQ__Users__536C85E4312404E4", IsUnique = true)]
[Index("Email", Name = "UQ__Users__A9D10534882B51B6", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(50)]
    public string Username { get; set; } = null!;

    [StringLength(100)]
    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public bool? IsActive { get; set; }

    [InverseProperty("User")]
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    [InverseProperty("User")]
    public virtual ICollection<FavoriteHotel> FavoriteHotels { get; set; } = new List<FavoriteHotel>();

    [InverseProperty("User")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [InverseProperty("User")]
    public virtual UserProfile? UserProfile { get; set; }
}
