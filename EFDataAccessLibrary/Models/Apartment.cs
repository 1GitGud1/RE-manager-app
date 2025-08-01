﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    [PrimaryKey(nameof(BuildingNumber), nameof(ApartmentNumber))]
    public class Apartment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BuildingNumber { get; set; }

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

        public bool Ejari { get; set; }

        [Required]
        [MaxLength(50)]
        public int Deposit { get; set; }

        //Amount
        [Required]
        [MaxLength(50)]
        public int Amount { get; set; }

        public List<ApartmentService> ApartmentServices { get; set; } = new List<ApartmentService>();
        public List<ApartmentCheque> ApartmentCheques { get; set; } = new List<ApartmentCheque>();

        public ApartmentPPM? PPM { get; set; }


        //servicing page

        //cheque check page
    }
}
