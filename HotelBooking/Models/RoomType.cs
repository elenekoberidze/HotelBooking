using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Models;

public partial class RoomType
{
    [Key]
    [Column("TypeID")]
    public int TypeId { get; set; }

    [StringLength(50)]
    public string TypeName { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal BasePrice { get; set; }

    [InverseProperty("Type")]
    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
