using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Xlab_Task.Models;

namespace Xlab_Task.Data
{
    public partial class SalesDbContext : DbContext
    {
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Invoice_Detail> Invoice_Details { get; set; }

        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice_Detail>(entity =>
            {
                entity.HasKey(e => new { e.Invoice_ID, e.Product_ID })
                    .HasName("PK_Invoice_Details_1");

                entity.Property(e => e.Total_Price).HasComputedColumnSql("([Product_Quantity]*[Product_Price])", true);

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.Invoice_Details)
                    .HasForeignKey(d => d.Invoice_ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Details_Invoice1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
