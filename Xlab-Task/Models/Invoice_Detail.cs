using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Xlab_Task.Models
{
    [Keyless]
    public partial class Invoice_Detail
    {
        public int Invoice_ID { get; set; }
        public int Product_ID { get; set; }
        public double? Product_Price { get; set; }
        public int? Product_Quantity { get; set; }
        public double? Total_Price { get; set; }

        [ForeignKey(nameof(Invoice_ID))]
        public virtual Invoice Invoice { get; set; }
    }
}
