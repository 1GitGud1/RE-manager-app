using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class ApartmentService
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime ServiceDate { get; set; }

        public TimeSpan Time { get; set; }

        public bool Done { get; set; }

        [Required]
        public int ApartmentNumber { get; set; }

        [Required]
        public int BuildingNumber { get; set; }

        Apartment Apartment { get; set; }
    }
}
