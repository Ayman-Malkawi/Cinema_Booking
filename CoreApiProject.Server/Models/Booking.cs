using System;
using System.Collections.Generic;

namespace CoreApiProject.Server.Models;

public partial class Booking
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RoomId { get; set; }

    public int? MovieId { get; set; }

    public DateTime? BookingDate { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public decimal? TotalPrice { get; set; }

    public bool? Cancelled { get; set; }

    public DateTime? CancellationDate { get; set; }

    public string? PaymentStatus { get; set; }

    public string? PaymentMethod { get; set; }

    public string? Seat1 { get; set; }

    public string? Seat2 { get; set; }

    public string? Seat3 { get; set; }

    public virtual Movie? Movie { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Room? Room { get; set; }

    public virtual User? User { get; set; }
}
