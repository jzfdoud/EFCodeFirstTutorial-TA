﻿using EFCodeFirstTutorial_TA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCodeFirstTutorial_TA.Migrations
{
    public class Order
    {

        public int Id { get; set; }
        [StringLength(50), Required]
        public string Description { get; set; }
        [StringLength(10), Required]
        public string Status { get; set; } = "NEW";
        [Column(TypeName= "decimal(9, 2)")]
        public decimal Total { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }



        public Order() { }
    }
}
