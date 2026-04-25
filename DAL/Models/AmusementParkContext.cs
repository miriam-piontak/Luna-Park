using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class AmusementParkContext : DbContext
{
    public AmusementParkContext()
    {
    }

    public AmusementParkContext(DbContextOptions<AmusementParkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attraction> Attractions { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=Luna-Park;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attraction>(entity =>
        {
            entity.HasKey(e => e.AttractionId).HasName("PK__Attracti__DAE24D5AB0588017");

            entity.ToTable("Attraction");

            entity.Property(e => e.AttractionName).HasMaxLength(20);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeTz).HasName("PK__Employee__7AD021716F4302F3");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeTz).HasMaxLength(10);
            entity.Property(e => e.EmployeeFirstName).HasMaxLength(20);
            entity.Property(e => e.EmployeeLastName).HasMaxLength(20);

            entity.HasOne(d => d.Attraction).WithMany(p => p.Employees)
                .HasForeignKey(d => d.AttractionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_to_Attraction");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Ticket__712CC607F6CC65CE");

            entity.ToTable("Ticket");

            entity.Property(e => e.EmployeeId).HasMaxLength(10);

            entity.HasOne(d => d.Attraction).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.AttractionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_to_Attraction");

            entity.HasOne(d => d.Employee).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ticket_to_Emloyee");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
