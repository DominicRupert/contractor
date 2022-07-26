using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contractor.Models
{
    public class Contractor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profession { get; set; }
    }

    public class ContractorJobViewModel : Contractor
    {
        public int JobId { get; set; }
    }
}