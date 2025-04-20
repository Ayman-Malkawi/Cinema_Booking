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
        => optionsBuilder.UseSqlServer("Server=DESKTOP-5U44ISQ;Database=CinemaDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blacklist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Blacklis__3214EC0790920178");

            entity.ToTable("Blacklist");

            entity.Property(e => e.Reason).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Blacklists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Blacklist__UserI__6E01572D");
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bookings__3214EC07DAC30289");

            entity.Property(e => e.BookingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CancellationDate).HasColumnType("datetime");
            entity.Property(e => e.Cancelled).HasDefaultValue(false);
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            entity.Property(e => e.StartTime).HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Movie).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Bookings__MovieI__6754599E");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Bookings__RoomId__66603565");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Bookings__UserId__656C112C");
        });

        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ChatMess__3214EC07DD305949");

            entity.Property(e => e.Message).HasMaxLength(500);
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Receiver).WithMany(p => p.ChatMessageReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK__ChatMessa__Recei__778AC167");

            entity.HasOne(d => d.Sender).WithMany(p => p.ChatMessageSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__ChatMessa__Sende__76969D2E");
        });

        modelBuilder.Entity<ContactU>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contact___3213E83F91B75DB2");

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
            entity.HasKey(e => e.Id).HasName("PK__Movies__3214EC077FEA31A7");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.TicketPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Movies)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Movies__Category__52593CB8");
        });

        modelBuilder.Entity<MovieCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MovieCat__3214EC075212D734");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payments__3214EC070FA168F2");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__Payments__Bookin__03F0984C");
        });

        modelBuilder.Entity<PrivateBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PrivateB__3214EC076012EF20");

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
                .HasConstraintName("FK__PrivateBo__Movie__5AEE82B9");

            entity.HasOne(d => d.PrivateRoom).WithMany(p => p.PrivateBookings)
                .HasForeignKey(d => d.PrivateRoomId)
                .HasConstraintName("FK__PrivateBo__Priva__59FA5E80");

            entity.HasOne(d => d.User).WithMany(p => p.PrivateBookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__PrivateBo__UserI__59063A47");
        });

        modelBuilder.Entity<PrivateRoom>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PrivateR__3214EC079771DFF3");

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
            entity.HasKey(e => e.Id).HasName("PK__Reviews__3214EC07C01D168B");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReviewText).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Movie).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__Reviews__MovieId__71D1E811");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reviews__UserId__70DDC3D8");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rooms__3214EC07C8087678");

            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.RoomDescription).HasMaxLength(255);
            entity.Property(e => e.RoomName).HasMaxLength(100);
        });

        modelBuilder.Entity<RoomAvailability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomAvai__3214EC0789C5018C");

            entity.ToTable("RoomAvailability");

            entity.Property(e => e.AvailableDay).HasMaxLength(20);

            entity.HasOne(d => d.PrivateRoom).WithMany(p => p.RoomAvailabilities)
                .HasForeignKey(d => d.PrivateRoomId)
                .HasConstraintName("FK__RoomAvail__Priva__619B8048");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomAvailabilities)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__RoomAvail__RoomI__60A75C0F");
        });

        modelBuilder.Entity<RoomBooking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomBook__3214EC074CB435D1");

            entity.Property(e => e.SeatNumber).HasMaxLength(20);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Movie).WithMany(p => p.RoomBookings)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK__RoomBooki__Movie__00200768");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomBookings)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__RoomBooki__RoomI__7F2BE32F");

            entity.HasOne(d => d.User).WithMany(p => p.RoomBookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__RoomBooki__UserI__7E37BEF6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07DDCFB3A9");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534EAB97F61").IsUnique();

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
