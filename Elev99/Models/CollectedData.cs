using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elev99.Models
{
    public class CollectedData : IComparable
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public char Elevator { get; set; }
        public char Shift { get; set; }

        public CollectedData()
        {
        }

        public CollectedData(int id, int floor, char elevator, char shift)
        {
            Id = id;
            Floor = floor;
            Elevator = elevator;
            Shift = shift;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
