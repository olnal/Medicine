using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Medicine.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Drug Drug { get; set; }
        
        [Required]
        public int Amount { get; set; }

        
    }
}
