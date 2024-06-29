using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Microservices.DotNet8MiniBankingManagementSystem.DbService.AppDbContexts;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccount> TblAccounts { get; set; }

    public virtual DbSet<TblDeposit> TblDeposits { get; set; }

    public virtual DbSet<TblState> TblStates { get; set; }

    public virtual DbSet<TblTownship> TblTownships { get; set; }

    public virtual DbSet<TblTransactionHistory> TblTransactionHistories { get; set; }

    public virtual DbSet<TblWithdraw> TblWithdraws { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK_Account");

            entity.ToTable("Tbl_Account");

            entity.Property(e => e.AccountLevel).HasColumnType("decimal(18, 1)");
            entity.Property(e => e.AccountNo).HasMaxLength(50);
            entity.Property(e => e.Balance).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.CustomerCode).HasMaxLength(50);
            entity.Property(e => e.CustomerName).HasMaxLength(50);
            entity.Property(e => e.StateCode).HasMaxLength(50);
            entity.Property(e => e.TownshipCode).HasMaxLength(50);
        });

        modelBuilder.Entity<TblDeposit>(entity =>
        {
            entity.HasKey(e => e.DepositId).HasName("PK_Deposit");

            entity.ToTable("Tbl_Deposit");

            entity.Property(e => e.AccountNo).HasMaxLength(50);
            entity.Property(e => e.Amount).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.DepositDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblState>(entity =>
        {
            entity.HasKey(e => e.StateId).HasName("PK_State");

            entity.ToTable("Tbl_State");

            entity.Property(e => e.StateId).ValueGeneratedNever();
            entity.Property(e => e.StateCode).HasMaxLength(50);
            entity.Property(e => e.StateName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblTownship>(entity =>
        {
            entity.HasKey(e => e.TownshipId).HasName("PK_Township");

            entity.ToTable("Tbl_Township");

            entity.Property(e => e.TownshipId).ValueGeneratedNever();
            entity.Property(e => e.StateCode).HasMaxLength(50);
            entity.Property(e => e.TownshipCode).HasMaxLength(50);
            entity.Property(e => e.TownshipName).HasMaxLength(50);
        });

        modelBuilder.Entity<TblTransactionHistory>(entity =>
        {
            entity.HasKey(e => e.TransactionHistoryId).HasName("PK_TransactionHistory");

            entity.ToTable("Tbl_TransactionHistory");

            entity.Property(e => e.TransactionHistoryId).HasMaxLength(50);
            entity.Property(e => e.Amount).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.FromAccountNo).HasMaxLength(50);
            entity.Property(e => e.ToAccountNo).HasMaxLength(50);
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblWithdraw>(entity =>
        {
            entity.HasKey(e => e.WithDrawId).HasName("PK_WithDraw");

            entity.ToTable("Tbl_Withdraw");

            entity.Property(e => e.AccountNo).HasMaxLength(50);
            entity.Property(e => e.Amount).HasColumnType("decimal(20, 2)");
            entity.Property(e => e.WithDrawDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
