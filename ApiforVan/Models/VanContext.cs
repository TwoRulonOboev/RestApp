using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiforVan.Models;

public partial class VanContext : DbContext
{
    public VanContext()
    {
    }

    public VanContext(DbContextOptions<VanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PaymentRecord> PaymentRecords { get; set; }

    public virtual DbSet<Subscriber> Subscribers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=(localDB)\\MSSQLLocalDB;Initial Catalog=Van;Integrated Security=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PaymentRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentR__3214EC07C878CFF8");

            entity.Property(e => e.DebtOrOverpayment).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PaymentDate).HasColumnType("date");

            entity.HasOne(d => d.Subscriber).WithMany(p => p.PaymentRecords)
                .HasForeignKey(d => d.SubscriberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PaymentRe__Subsc__286302EC");
        });

        modelBuilder.Entity<Subscriber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subscrib__3214EC071B06396D");

            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MonthlyFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0785C8F9D0");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EMail).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Password).IsRequired().HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
