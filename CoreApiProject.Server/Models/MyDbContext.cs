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
        => optionsBuilder.UseSqlServer("Server=DESKTOP-R8LTBNV;Database=CinemaDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blacklist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Blacklis__3214EC07EFA63740");

            entity.ToTable("Blacklist");

            entity.Property(e => e.Reason).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Blacklists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Blacklist__UserI__5AEE82B9");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bookings__3214EC0788CAC685");

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
                .HasConstraintName("FK__Bookings__MovieI__5441852A");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Bookings__RoomId__534D60F1");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Bookings__UserId__52593CB8");
        });

        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChatMess__3214EC07BD69A133");

            entity.Property(e => e.Message).HasMaxLength(500);
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Receiver).WithMany(p => p.ChatMessageReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK__ChatMessa__Recei__6477ECF3");

            entity.HasOne(d => d.Sender).WithMany(p => p.ChatMessageSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__ChatMessa__Sende__6383C8BA");
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contact___3213E83F18C40560");

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
            entity.HasKey(e => e.Id).HasName("PK__Movies__3214EC0780861EFD");

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
            entity.HasKey(e => e.Id).HasName("PK__MovieCat__3214EC0785BEC644");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
            entity.Property(e => e.IsVisible).HasDefaultValue(true);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3214EC0775E3DB21");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__Payments__Bookin__70DDC3D8");

            entity.HasOne(d => d.PrivateBooking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PrivateBookingId)
                .HasConstraintName("FK__Payments__Privat__02FC7413");
        });

        modelBuilder.Entity<PrivateBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PrivateB__3214EC076C37D6C6");

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
                .HasConstraintName("FK__PrivateBo__Movie__47DBAE45");

            entity.HasOne(d => d.PrivateRoom).WithMany(p => p.PrivateBookings)
                .HasForeignKey(d => d.PrivateRoomId)
                .HasConstraintName("FK__PrivateBo__Priva__46E78A0C");

            entity.HasOne(d => d.User).WithMany(p => p.PrivateBookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__PrivateBo__UserI__45F365D3");
        });

        modelBuilder.Entity<PrivateRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PrivateR__3214EC0759D8C17D");

            entity.Property(e => e.Vipdescription)
                .HasMaxLength(255)
                .HasColumnName("VIPDescription");
            entity.Property(e => e.Vipname)
                .HasMaxLength(100)
                .HasColumnName("VIPName");
            entity.Property(e => e.Vipprice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("VIPPrice");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reviews__3214EC077DCDAAFA");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReviewText).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Movie).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Reviews__MovieId__5EBF139D");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reviews__UserId__5DCAEF64");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rooms__3214EC07C076D994");

            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.RoomDescription).HasMaxLength(255);
            entity.Property(e => e.RoomName).HasMaxLength(100);
        });

        modelBuilder.Entity<RoomAvailability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomAvai__3214EC07E20E168A");

            entity.ToTable("RoomAvailability");

            entity.Property(e => e.AvailableDay).HasMaxLength(20);

            entity.HasOne(d => d.PrivateRoom).WithMany(p => p.RoomAvailabilities)
                .HasForeignKey(d => d.PrivateRoomId)
                .HasConstraintName("FK__RoomAvail__Priva__4E88ABD4");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomAvailabilities)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__RoomAvail__RoomI__4D94879B");
        });

        modelBuilder.Entity<RoomBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomBook__3214EC07E4A69086");

            entity.Property(e => e.SeatNumber).HasMaxLength(20);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Movie).WithMany(p => p.RoomBookings)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__RoomBooki__Movie__6D0D32F4");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomBookings)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__RoomBooki__RoomI__6C190EBB");

            entity.HasOne(d => d.User).WithMany(p => p.RoomBookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__RoomBooki__UserI__6B24EA82");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07F33CC1A2");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534E6954B9C").IsUnique();

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
