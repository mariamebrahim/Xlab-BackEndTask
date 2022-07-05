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

        public virtual DbSet<sp_GetInvoiceByIDResult> GetInvoiceByID { get; set; }

        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.Client_Name).IsUnicode(false);
            });

            modelBuilder.Entity<Invoice_Detail>(entity =>
            {
                entity.HasKey(e => new { e.Invoice_ID, e.Product_ID });

                entity.Property(e => e.Total_Price).HasComputedColumnSql("([Product_Price]*[Product_Quantity])", false);
            });

            OnModelCreatingGeneratedProcedures(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
