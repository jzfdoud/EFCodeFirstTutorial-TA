using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCodeFirstTutorial_TA.Models
{
    public class Customer
    {
        public int Id { get; set; } // EF will look for PK by name, if not obvious- have to put '[key]'
        [StringLength(10), Required]
        public string Code { get; set; } //must be unique
        [StringLength(50), Required]
        public string Name { get; set; }
        public bool IsNational { get; set; } //bool sets as false by default
        public decimal Sales { get; set; }
        public DateTime Created { get; set; }




        public Customer() { }
    }
}
