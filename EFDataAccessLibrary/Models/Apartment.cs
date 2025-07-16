using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Apartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApartmentNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string TenantName { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime ContractStartDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime ContractEndDate { get; set; }

        [Required]
        public int Deposit { get; set; }

        //Amount
        [Required]
        public int Amount { get; set; }

        public List<ApartmentService> ApartmentServices { get; set; } = new List<ApartmentService>();
        public List<ApartmentCheque> ApartmentCheques { get; set; } = new List<ApartmentCheque>();


        //servicing page

        //cheque check page
    }
}
