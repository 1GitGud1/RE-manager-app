using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.Models
{
    [PrimaryKey(nameof(BuildingNumber), nameof(ApartmentNumber))]
    public class ApartmentPPM
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BuildingNumber { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApartmentNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime Q1Date { get; set; }

        public TimeSpan Q1Time { get; set; }

        public bool Q1Done { get; set; }

        [Column(TypeName = "date")]
        public DateTime Q2Date { get; set; }

        public TimeSpan Q2Time { get; set; }

        public bool Q2Done { get; set; }

        [Column(TypeName = "date")]
        public DateTime Q3Date { get; set; }

        public TimeSpan Q3Time { get; set; }

        public bool Q3Done { get; set; }

        [Column(TypeName = "date")]
        public DateTime Q4Date { get; set; }

        public TimeSpan Q4Time { get; set; }

        public bool Q4Done { get; set; }

        public Apartment Apartment { get; set; } = null!;
    }
}
