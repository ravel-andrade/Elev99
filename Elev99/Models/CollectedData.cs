using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elev99.Models
{
    public class CollectedData
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public string Elevator { get; set; }
        public string Shift { get; set; }
    }
}
