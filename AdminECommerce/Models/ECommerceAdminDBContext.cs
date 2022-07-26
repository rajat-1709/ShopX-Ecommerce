﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdminECommerceAPI.Models
{
    public partial class ECommerceAdminDBContext : DbContext
    {
        public ECommerceAdminDBContext()
        {
        }

        public ECommerceAdminDBContext(DbContextOptions<ECommerceAdminDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Contribution> Contributions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ECommerceAdminDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.AdminId).HasColumnName("AdminID");

                entity.Property(e => e.AdminName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMail");

                entity.Property(e => e.LastLoggedIn)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.Property(e => e.SentTime).HasColumnType("datetime");

                entity.HasOne(d => d.MessageFromNavigation)
                    .WithMany(p => p.ChatMessageFromNavigations)
                    .HasForeignKey(d => d.MessageFrom)
                    .HasConstraintName("FK__Chats__MessageFr__49C3F6B7");

                entity.HasOne(d => d.MessageToNavigation)
                    .WithMany(p => p.ChatMessageToNavigations)
                    .HasForeignKey(d => d.MessageTo)
                    .HasConstraintName("FK__Chats__MessageTo__4AB81AF0");
            });

            modelBuilder.Entity<Contribution>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK__Contribu__C1F8DC59F859A5F9");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.ChangedTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ChangesMade).IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.ChangeMadeByNavigation)
                    .WithMany(p => p.Contributions)
                    .HasForeignKey(d => d.ChangeMadeBy)
                    .HasConstraintName("FK__Contribut__Chang__36B12243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
