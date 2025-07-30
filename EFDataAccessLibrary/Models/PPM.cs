using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class PPM
    {
        public int PPMId { get; set; }

        [Required]
        [MaxLength(50)]
        public int BuildingNumber { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public List<PPMtime> PPMtimes { get; set; } = new List<PPMtime>();
    }
}
