using System;
using System.Collections.Generic;

namespace CoreApiProject.Server.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Phone { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<Blacklist> Blacklists { get; set; } = new List<Blacklist>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<ChatMessage> ChatMessageReceivers { get; set; } = new List<ChatMessage>();

    public virtual ICollection<ChatMessage> ChatMessageSenders { get; set; } = new List<ChatMessage>();

    public virtual ICollection<PrivateBooking> PrivateBookings { get; set; } = new List<PrivateBooking>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<RoomBooking> RoomBookings { get; set; } = new List<RoomBooking>();
}
