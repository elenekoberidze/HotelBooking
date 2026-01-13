using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Models;

[Index("UserId", Name = "UQ__UserProf__1788CCAD49C44865", IsUnique = true)]
public partial class UserProfile
{
    [Key]
    [Column("ProfileID")]
    public int ProfileId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    [StringLength(255)]
    public string? Address { get; set; }

    [ForeignKey("UserId")]
    [InverseProperty("UserProfile")]
    public virtual User User { get; set; } = null!;
}
