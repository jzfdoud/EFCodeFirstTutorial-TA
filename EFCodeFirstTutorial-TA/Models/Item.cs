using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCodeFirstTutorial_TA.Models
{
    public class Item
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(9, 2)")]
        public decimal Price { get; set; }



        public Item() { }
    }
}
