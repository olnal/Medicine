using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Medicines.Models
{
    public class DrugType
    {
        public enum Category
        {
            Drug,
            Ointmen,
            solution,
            injection,
            other
        }
        [Required]
        public int Id { get; set; }

        [Required]
        public Category Type { get; set; }

    }
}
