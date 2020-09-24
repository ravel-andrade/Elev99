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
        [Required(ErrorMessage = "o campo 'andar' é obrigatório")]
        [Range(1,15, ErrorMessage = "Andar aceita apenas valores de 0 à 10")]
        public int Floor { get; set; }
        [Required(ErrorMessage = "o campo 'elevador' é obrigatório")]
        
        public char Elevator { get; set; }
        [Required(ErrorMessage = "o campo 'turno' é obrigatório")]
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
