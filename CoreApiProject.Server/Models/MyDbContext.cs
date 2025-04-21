using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CoreApiProject.Server.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blacklist> Blacklists { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<ChatMessage> ChatMessages { get; set; }

    public virtual DbSet<ContactU> ContactUs { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieCategory> MovieCategories { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PrivateBooking> PrivateBookings { get; set; }

    public virtual DbSet<PrivateRoom> PrivateRooms { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomAvailability> RoomAvailabilities { get; set; }

    public virtual DbSet<RoomBooking> RoomBookings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-6263BV65;Database=CinemaDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blacklist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Blacklis__3214EC07B598A461");

            entity.ToTable("Blacklist");

            entity.Property(e => e.Reason).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Blacklists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Blacklist__UserI__4F7CD00D");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bookings__3214EC07D7AA9315");

            entity.Property(e => e.BookingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CancellationDate).HasColumnType("datetime");
            entity.Property(e => e.Cancelled).HasDefaultValue(false);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            entity.Property(e => e.Seat1)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Seat2)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Seat3)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Movie).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Bookings__MovieI__48CFD27E");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Bookings__RoomId__47DBAE45");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Bookings__UserId__46E78A0C");
        });

        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChatMess__3214EC072F8D1F7C");

            entity.Property(e => e.Message).HasMaxLength(500);
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Receiver).WithMany(p => p.ChatMessageReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK__ChatMessa__Recei__59063A47");

            entity.HasOne(d => d.Sender).WithMany(p => p.ChatMessageSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__ChatMessa__Sende__5812160E");
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contact___3213E83F827D23CE");

            entity.ToTable("contact_us");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Subject)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("subject");
            entity.Property(e => e.SubmissionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("submission_date");
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Movies__3214EC07F3F45252");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.IsViable).HasDefaultValue(true);
            entity.Property(e => e.TicketPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Movies)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Movies__Category__3F466844");
        });

        modelBuilder.Entity<MovieCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MovieCat__3214EC0720188028");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.IsVisible).HasDefaultValue(true);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3214EC07EBD945EA");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__Payments__Bookin__656C112C");

            entity.HasOne(d => d.PrivateBooking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PrivateBookingId)
                .HasConstraintName("FK__Payments__Privat__7B5B524B");
        });

        modelBuilder.Entity<PrivateBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PrivateB__3214EC07530782D0");

            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Movie).WithMany(p => p.PrivateBookings)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__PrivateBo__Movie__74AE54BC");

            entity.HasOne(d => d.PrivateRoom).WithMany(p => p.PrivateBookings)
                .HasForeignKey(d => d.PrivateRoomId)
                .HasConstraintName("FK__PrivateBo__Priva__73BA3083");

            entity.HasOne(d => d.User).WithMany(p => p.PrivateBookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__PrivateBo__UserI__72C60C4A");
        });

        modelBuilder.Entity<PrivateRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PrivateR__3214EC0765B92B8C");

            entity.Property(e => e.Vipdescription)
                .HasMaxLength(255)
                .HasColumnName("VIPDescription");
            entity.Property(e => e.Vipname)
                .HasMaxLength(100)
                .HasColumnName("VIPName");
            entity.Property(e => e.Vipprice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("VIPPrice");

            entity.HasOne(d => d.Room).WithMany(p => p.PrivateRooms)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__PrivateRo__RoomI__6FE99F9F");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reviews__3214EC07F479EB63");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReviewText).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Movie).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Reviews__MovieId__534D60F1");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reviews__UserId__52593CB8");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rooms__3214EC07995158DC");

            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.RoomDescription).HasMaxLength(255);
            entity.Property(e => e.RoomName).HasMaxLength(100);
        });

        modelBuilder.Entity<RoomAvailability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomAvai__3214EC07DB480444");

            entity.ToTable("RoomAvailability");

            entity.Property(e => e.AvailableDay).HasMaxLength(20);

            entity.HasOne(d => d.PrivateRoom).WithMany(p => p.RoomAvailabilities)
                .HasForeignKey(d => d.PrivateRoomId)
                .HasConstraintName("FK__RoomAvail__Priva__787EE5A0");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomAvailabilities)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__RoomAvail__RoomI__4316F928");
        });

        modelBuilder.Entity<RoomBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomBook__3214EC07FCB21754");

            entity.Property(e => e.SeatNumber).HasMaxLength(20);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Movie).WithMany(p => p.RoomBookings)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__RoomBooki__Movie__619B8048");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomBookings)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__RoomBooki__RoomI__60A75C0F");

            entity.HasOne(d => d.User).WithMany(p => p.RoomBookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__RoomBooki__UserI__5FB337D6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC0734A5B79A");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.Role).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
