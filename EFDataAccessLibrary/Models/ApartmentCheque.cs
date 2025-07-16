using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class ApartmentCheque
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DueDate { get; set; }

        public bool IsCashed { get; set; }

        [Required]
        public int ApartmentNumber { get; set; }
        Apartment Apartment { get; set; }
    }
}
