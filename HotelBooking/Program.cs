
//using HotelBooking.Data;
//using HotelBooking.Models;

//using (var context = new HotelBookingContext())
//{
//    var user = new User
//    {
//        Username = "nika01",
//        Email = "nika01@mail.com",
//        PasswordHash = "hash123",
//        IsActive = true
//    };

//    context.Users.Add(user);
//    context.SaveChanges();

//    var profile = new UserProfile
//    {
//        UserId = user.UserId,
//        FirstName = "Nika",
//        LastName = "Beridze",
//        PhoneNumber = "555123456",
//        Address = "Tbilisi"
//    };

//    context.UserProfiles.Add(profile);
//    context.SaveChanges();
//}
//using (var context = new HotelBookingContext())
//{
//    var hotel = new Hotel
//    {
//        Name = "Sunrise Hotel",
//        Description = "Modern hotel near the beach",
//        City = "Batumi",
//        Address = "Beach Street 10",
//        Rating = 4.5m
//    };

//    context.Hotels.Add(hotel);
//    context.SaveChanges();
//}
//using (var context = new HotelBookingContext())
//{
//    var room = new Room
//    {
//        HotelId = 1,
//        TypeId = 1,
//        RoomNumber = "101",
//        IsAvailable = true
//    };

//    context.Rooms.Add(room);
//    context.SaveChanges();
//}
//using (var context = new HotelBookingContext())
//{
//    var users = context.Users
//        .Where(u => (bool)u.IsActive)
//        .OrderBy(u => u.Username)
//        .ToList();
//}
//using (var context = new HotelBookingContext())
//{
//    var hotels = context.Hotels
//        .Where(h => h.Rating >= 4)
//        .OrderByDescending(h => h.Rating)
//        .ToList();
//}
//using (var context = new HotelBookingContext())
//{
//    var user = context.Users.FirstOrDefault(u => u.UserId == 1);

//    if (user != null)
//    {
//        user.Email = "newemail@mail.com";
//        context.SaveChanges();
//    }
//}
//using (var context = new HotelBookingContext())
//{
//    var room = context.Rooms.FirstOrDefault(r => r.RoomId == 3);

//    if (room != null)
//    {
//        room.IsAvailable = false;
//        context.SaveChanges();
//    }
//}
//using (var context = new HotelBookingContext())
//{
//    var hotel = context.Hotels.FirstOrDefault(h => h.HotelId == 1);

//    if (hotel != null)
//    {
//        hotel.Rating = 4.8m;
//        context.SaveChanges();
//    }
//}
//using (var context = new HotelBookingContext())
//{
//    var review = context.Reviews.FirstOrDefault(r => r.ReviewId == 5);

//    if (review != null)
//    {
//        context.Reviews.Remove(review);
//        context.SaveChanges();
//    }
//}
//using (var context = new HotelBookingContext())
//{
//    var room = context.Rooms.FirstOrDefault(r => r.RoomId == 10);

//    if (room != null)
//    {
//        context.Rooms.Remove(room);
//        context.SaveChanges();
//    }
//}
//using (var context = new HotelBookingContext())
//{
//    var user = context.Users.FirstOrDefault(u => u.UserId == 2);

//    if (user != null)
//    {
//        context.Users.Remove(user);
//        context.SaveChanges();
//    }
//}

