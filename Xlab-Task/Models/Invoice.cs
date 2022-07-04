using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Xlab_Task.Models
{
    [Table("Invoice")]
    public partial class Invoice
    {
        public Invoice()
        {
            Invoice_Details = new HashSet<Invoice_Detail>();
        }

        [Key]
        public int Invoice_ID { get; set; }
        public int Client_ID { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Invoice_Date { get; set; }

        [InverseProperty(nameof(Invoice_Detail.Invoice))]
        public virtual ICollection<Invoice_Detail> Invoice_Details { get; set; }
    }
}
