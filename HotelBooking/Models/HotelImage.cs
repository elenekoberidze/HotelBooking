using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Models;

public partial class HotelImage
{
    [Key]
    [Column("ImageID")]
    public int ImageId { get; set; }

    [Column("HotelID")]
    public int HotelId { get; set; }

    [Column("ImageURL")]
    public string ImageUrl { get; set; } = null!;

    public bool? IsPrimary { get; set; }

    [ForeignKey("HotelId")]
    [InverseProperty("HotelImages")]
    public virtual Hotel Hotel { get; set; } = null!;
}
