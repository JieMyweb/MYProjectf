using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project2.Models;

public partial class ShopContext : DbContext
{
    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<tMember> tMember { get; set; }

    public virtual DbSet<tOrder> tOrder { get; set; }

    public virtual DbSet<tOrderDetail> tOrderDetail { get; set; }

    public virtual DbSet<tProduct> tProduct { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tMember>(entity =>
        {
            entity.HasKey(e => e.fId);

            entity.Property(e => e.fEmail).HasMaxLength(50);
            entity.Property(e => e.fName).HasMaxLength(50);
            entity.Property(e => e.fPwd).HasMaxLength(50);
            entity.Property(e => e.fUserId).HasMaxLength(50);
        });

        modelBuilder.Entity<tOrder>(entity =>
        {
            entity.HasKey(e => e.fId);

            entity.Property(e => e.fAddress).HasMaxLength(50);
            entity.Property(e => e.fDate).HasColumnType("datetime");
            entity.Property(e => e.fEmail).HasMaxLength(50);
            entity.Property(e => e.fOrderGuid).HasMaxLength(50);
            entity.Property(e => e.fReceiver).HasMaxLength(50);
            entity.Property(e => e.fUserId).HasMaxLength(50);
        });

        modelBuilder.Entity<tOrderDetail>(entity =>
        {
            entity.HasKey(e => e.fId);

            entity.Property(e => e.fIsApproved).HasMaxLength(10);
            entity.Property(e => e.fName).HasMaxLength(50);
            entity.Property(e => e.fOrderGuid).HasMaxLength(50);
            entity.Property(e => e.fPId).HasMaxLength(50);
            entity.Property(e => e.fUserId).HasMaxLength(50);
        });

        modelBuilder.Entity<tProduct>(entity =>
        {
            entity.HasKey(e => e.fId);

            entity.Property(e => e.fImg).HasMaxLength(50);
            entity.Property(e => e.fName).HasMaxLength(50);
            entity.Property(e => e.fPId).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
