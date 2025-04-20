using System;
using System.Collections.Generic;

namespace CoreApiProject.Server.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? Duration { get; set; }

    public int? CategoryId { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public string? Image { get; set; }

    public decimal? TicketPrice { get; set; }

    public int? Rating { get; set; }

    public bool IsViable { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual MovieCategory? Category { get; set; }

    public virtual ICollection<PrivateBooking> PrivateBookings { get; set; } = new List<PrivateBooking>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<RoomBooking> RoomBookings { get; set; } = new List<RoomBooking>();
}
