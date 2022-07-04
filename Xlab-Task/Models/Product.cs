using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Xlab_Task.Models
{
    public partial class Product
    {
        [Key]
        public int Product_ID { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Product_Name { get; set; }
        public double? Product_Price { get; set; }
    }
}
