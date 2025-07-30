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
        [MaxLength(50)]
        public int Amount { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DueDate { get; set; }

        public bool IsCashed { get; set; }

        [Required]
        public int ApartmentNumber { get; set; }

        [Required]
        public int BuildingNumber { get; set; }

        Apartment Apartment { get; set; }
    }
}
