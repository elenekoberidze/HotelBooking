using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Models;

public partial class Review
{
    [Key]
    [Column("ReviewID")]
    public int ReviewId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("HotelID")]
    public int HotelId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReviewDate { get; set; }

    [ForeignKey("HotelId")]
    [InverseProperty("Reviews")]
    public virtual Hotel Hotel { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Reviews")]
    public virtual User User { get; set; } = null!;
}
