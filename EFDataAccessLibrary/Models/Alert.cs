using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    public class Alert
    {
        //public int Id { get; set; }

        public int BuildingNumber { get; set; }

        public string About { get; set; }

        public string Description { get; set; }

        public DateTime EventDate { get; set; }
    }
}
