using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public record JobImport
    {
        public string Title { get; set; } = string.Empty;
        public Int64 FacilityId { get; set; } = 0;
        public Int64 EmploymentType { get; set; } = 0;
        public DateTime StartDate { get; set; } = DateTime.Now;
        public bool IsNurseJob { get; set; } = false;
    }
}
