using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Xlab_Task.Models
{
    public partial class Invoice_Detail
    {
        [Key]
        public int Invoice_ID { get; set; }
        [Key]
        public int Product_ID { get; set; }
        public int? Product_Quantity { get; set; }
    }
}
