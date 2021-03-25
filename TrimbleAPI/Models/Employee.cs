using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrimbleAPI.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TeamLeaderId { get; set; }
        public string Role { get; set; }
    }
}
