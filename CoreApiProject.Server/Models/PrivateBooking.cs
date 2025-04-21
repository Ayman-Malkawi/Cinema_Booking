using System;
using System.Collections.Generic;

namespace CoreApiProject.Server.Models;

public partial class PrivateBooking
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? PrivateRoomId { get; set; }

    public int? MovieId { get; set; }

    public DateTime? BookingDate { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public decimal? TotalPrice { get; set; }

    public string? PaymentStatus { get; set; }

    public string? PaymentMethod { get; set; }

    public string? Status { get; set; }

    public virtual Movie? Movie { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual PrivateRoom? PrivateRoom { get; set; }

    public virtual User? User { get; set; }
}
