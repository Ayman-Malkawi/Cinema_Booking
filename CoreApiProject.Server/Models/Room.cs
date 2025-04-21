using System;
using System.Collections.Generic;

namespace CoreApiProject.Server.Models;

public partial class Room
{
    public int Id { get; set; }

    public string? RoomName { get; set; }

    public int? Capacity { get; set; }

    public string? RoomDescription { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<RoomAvailability> RoomAvailabilities { get; set; } = new List<RoomAvailability>();

    public virtual ICollection<RoomBooking> RoomBookings { get; set; } = new List<RoomBooking>();
}
