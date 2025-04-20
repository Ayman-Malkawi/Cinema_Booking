using System;
using System.Collections.Generic;

namespace CoreApiProject.Server.Models;

public partial class RoomBooking
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RoomId { get; set; }

    public int? MovieId { get; set; }

    public DateOnly? BookingDate { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }

    public string? SeatNumber { get; set; }

    public string? Status { get; set; }

    public virtual Movie? Movie { get; set; }

    public virtual Room? Room { get; set; }

    public virtual User? User { get; set; }
}
