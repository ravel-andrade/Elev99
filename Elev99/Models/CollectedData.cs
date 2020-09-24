using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elev99.Models
{
    public class CollectedData : IComparable
    {
        public int Id { get; set; }
        [Required]
        [Range(1,15, ErrorMessage = "Andar aceita apenas valores de 0 à 10")]
        public int Floor { get; set; }
        [StringLength(1, ErrorMessage ="Elevador aceita apenas A, B, C, D OU E")]
        public char Elevator { get; set; }
        [StringLength(1, ErrorMessage = "Turno aceita apenas M, N OU V")]
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
