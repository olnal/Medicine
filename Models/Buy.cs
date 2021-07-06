using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medicine.Models
{
    public class Buy
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public Drug Drug { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
