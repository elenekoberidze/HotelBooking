using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Models;

public partial class RoomImage
{
    [Key]
    [Column("ImageID")]
    public int ImageId { get; set; }

    [Column("RoomID")]
    public int RoomId { get; set; }

    [Column("ImageURL")]
    public string ImageUrl { get; set; } = null!;

    [ForeignKey("RoomId")]
    [InverseProperty("RoomImages")]
    public virtual Room Room { get; set; } = null!;
}
