using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Contract
    {
        public int ContractId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Company { get; set; }

        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        //Amount
        [Required]
        [MaxLength(50)]
        public int Amount { get; set; }

        public List<ContractDue> ContractDues { get; set; } = new List<ContractDue>();
    }
}
