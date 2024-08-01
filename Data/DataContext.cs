using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using chatbot_backend.Models;
using chatbot_backend.Controllers;
using Microsoft.Extensions.Configuration;

namespace chatbot_backend.Data;

public partial class DataContext : DbContext
{
    private readonly IConfiguration _configuration;
    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<DamageReason> DamageReasons { get; set; }
    public virtual DbSet<DraftForm> DraftForms { get; set; }

    public virtual DbSet<LocalizableEntry> LocalizableEntries { get; set; }

    public virtual DbSet<LocalizedEntry> LocalizedEntries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("MyConnexion");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AI");

        modelBuilder.Entity<DamageReason>(entity =>
        {
            entity.Property(e => e.DrId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DrCreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DrLastModifiedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DrTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.DrLocalizableEntry).WithMany(p => p.DamageReasons).HasConstraintName("FK_DamageReasons_LocalizableEntries");
        });

        modelBuilder.Entity<DraftForm>(entity =>
        {
            entity.Property(e => e.DrfId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.DrfCreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DrfLastModifiedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DrfTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<LocalizableEntry>(entity =>
        {
            entity.Property(e => e.LleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LleCreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LleLastModifiedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LleTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();
        });

        modelBuilder.Entity<LocalizedEntry>(entity =>
        {
            entity.Property(e => e.LlcId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LlcCreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LlcLastModifiedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.LlcTimeStamp)
                .IsRowVersion()
                .IsConcurrencyToken();

            entity.HasOne(d => d.LlcLocalizableEntry).WithMany(p => p.LocalizedEntries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LocalizedEntries_LocalizableEntries");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
