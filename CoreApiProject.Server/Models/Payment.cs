using System;
using System.Collections.Generic;

namespace CoreApiProject.Server.Models;

public partial class Payment
{
    public int Id { get; set; }

    public int? BookingId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public string? PaymentStatus { get; set; }

    public int? PrivateBookingId { get; set; }

    public virtual Booking? Booking { get; set; }

    public virtual PrivateBooking? PrivateBooking { get; set; }
}
