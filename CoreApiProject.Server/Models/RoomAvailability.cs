using System;
using System.Collections.Generic;

namespace CoreApiProject.Server.Models;

public partial class RoomAvailability
{
    public int Id { get; set; }

    public int? RoomId { get; set; }

    public int? PrivateRoomId { get; set; }

    public string? AvailableDay { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public virtual PrivateRoom? PrivateRoom { get; set; }

    public virtual Room? Room { get; set; }
}
