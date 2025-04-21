using System;
using System.Collections.Generic;

namespace CoreApiProject.Server.Models;

public partial class PrivateRoom
{
    public int Id { get; set; }

    public string? Vipname { get; set; }

    public string? Vipdescription { get; set; }

    public decimal? Vipprice { get; set; }

    public int? Capacity { get; set; }

    public virtual ICollection<PrivateBooking> PrivateBookings { get; set; } = new List<PrivateBooking>();

    public virtual ICollection<RoomAvailability> RoomAvailabilities { get; set; } = new List<RoomAvailability>();
}
