using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [MaxLength(50)]
        public int Deposit { get; set; }

        //Amount
        [Required]
        [MaxLength(50)]
        public int Amount { get; set; }

        public List<ContractDue> ContractDues { get; set; } = new List<ContractDue>();
    }
}
