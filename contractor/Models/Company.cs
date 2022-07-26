using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace contractor.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
        
        public class CompanyJobViewModel : Company
        {
        public int AvailableJobs { get; set; }

        }
        
}