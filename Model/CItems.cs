using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Market.Model
{
    public class CItems
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(3)]
        public string ItemName { get; set; }
        [Required]
        [Range(5,1000, ErrorMessage = "price must be between 5 and 1000 length")]
        public decimal ItemPrice { get; set; }
        public Groups_Class Groups { get; set; }
        public string ImagePath { get; set; }

    }
}
