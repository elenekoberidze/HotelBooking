using System;
using System.Collections.Generic;
using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data;

public partial class HotelBookingContext : DbContext
{
    public HotelBookingContext()
    {
    }

    public HotelBookingContext(DbContextOptions<HotelBookingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<FavoriteHotel> FavoriteHotels { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<HotelImage> HotelImages { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomImage> RoomImages { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HotelBooking;" +
        "Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Bookings__73951ACDD96AA890");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__RoomID__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Bookings__UserID__5070F446");
        });

        modelBuilder.Entity<FavoriteHotel>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.HotelId }).HasName("PK__Favorite__F3E8EF17FF57E4C1");

            entity.Property(e => e.SavedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Hotel).WithMany(p => p.FavoriteHotels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FavoriteH__Hotel__5CD6CB2B");

            entity.HasOne(d => d.User).WithMany(p => p.FavoriteHotels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FavoriteH__UserI__5BE2A6F2");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HotelId).HasName("PK__Hotels__46023BBFC8E60EAD");
        });

        modelBuilder.Entity<HotelImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__HotelIma__7516F4EC6879CB04");

            entity.Property(e => e.IsPrimary).HasDefaultValue(false);

            entity.HasOne(d => d.Hotel).WithMany(p => p.HotelImages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HotelImag__Hotel__4222D4EF");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AE3E46ED23");

            entity.Property(e => e.ReviewDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__HotelID__571DF1D5");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reviews__UserID__5629CD9C");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Rooms__32863919489383BD");

            entity.Property(e => e.IsAvailable).HasDefaultValue(true);

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rooms__HotelID__48CFD27E");

            entity.HasOne(d => d.Type).WithMany(p => p.Rooms)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rooms__TypeID__49C3F6B7");
        });

        modelBuilder.Entity<RoomImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__RoomImag__7516F4EC05ECE342");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomImages)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RoomImage__RoomI__4D94879B");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__RoomType__516F03951D4A7B92");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC1E55899A");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK__UserProf__290C8884819CCF05");

            entity.HasOne(d => d.User).WithOne(p => p.UserProfile)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserProfi__UserI__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<User>().HasData(
          new User
          {
              UserId = 1,
              Username = "admin",
              Email = "admin@hotel.com",
              PasswordHash = "hashed_password",
              IsActive = true
          },
          new User
          {
              UserId = 2,
              Username = "user1",
              Email = "user1@mail.com",
              PasswordHash = "hashed_password",
              IsActive = true
          }
      );


        modelBuilder.Entity<UserProfile>().HasData(
            new UserProfile
            {
                ProfileId = 1,
                UserId = 1,
                FirstName = "Admin",
                LastName = "User",
                PhoneNumber = "555-111-222",
                Address = "Tbilisi"
            },
            new UserProfile
            {
                ProfileId = 2,
                UserId = 2,
                FirstName = "John",
                LastName = "Doe",
                PhoneNumber = "555-333-444",
                Address = "Batumi"
            }
        );


        modelBuilder.Entity<Hotel>().HasData(
            new Hotel
            {
                HotelId = 1,
                Name = "Sunrise Hotel",
                Description = "Modern hotel in city center",
                City = "Tbilisi",
                Address = "Rustaveli Avenue 10",
                Rating = 4.5m
            },
            new Hotel
            {
                HotelId = 2,
                Name = "Sea View Resort",
                Description = "Resort near the sea",
                City = "Batumi",
                Address = "Batumi Boulevard 25",
                Rating = 4.8m
            }
        );


        modelBuilder.Entity<RoomType>().HasData(
            new RoomType
            {
                TypeId = 1,
                TypeName = "Single",
                BasePrice = 120.00m
            },
            new RoomType
            {
                TypeId = 2,
                TypeName = "Double",
                BasePrice = 200.00m
            }
        );
    }
    

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    
};

