using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.Models
{
    public class Drug
    {       
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DrugType Type { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
