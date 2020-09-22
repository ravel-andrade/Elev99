using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elev99.Models;

namespace Elev99.Data
{
    public class SeedingService
    {
        private Elev99Context _context;

        public SeedingService(Elev99Context context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.CollectedData.Any())
            {
                return;
            }

            CollectedData c1 = new CollectedData(1,11, "A","M" );
            CollectedData c2 = new CollectedData(2,12, "A","M" );
            CollectedData c3 = new CollectedData(3,14, "A","M" );
            CollectedData c4 = new CollectedData(4,0, "A","M" );
            CollectedData c5 = new CollectedData(5,1, "A","M" );
            CollectedData c6 = new CollectedData(6,15, "B","M" );
            CollectedData c7 = new CollectedData(7,13, "B","M" );
            CollectedData c8 = new CollectedData(8,1, "C","M" );
            CollectedData c9 = new CollectedData(9,2, "C","M" );
            CollectedData c10 = new CollectedData(10,4, "C","M" );
            CollectedData c11 = new CollectedData(11,3, "C","M" );
            CollectedData c12 = new CollectedData(12,4, "C","M" );
            CollectedData c13 = new CollectedData(13,5, "D","M" );
            CollectedData c14 = new CollectedData(14,6, "E","M" );
            CollectedData c15 = new CollectedData(15, 7, "A", "M");
            CollectedData c16 = new CollectedData(16, 10, "A", "M");
            CollectedData c17 = new CollectedData(17, 9, "A", "M");
            CollectedData c18 = new CollectedData(18, 15, "B", "V");
            CollectedData c19 = new CollectedData(19, 13, "B", "V");
            CollectedData c20 = new CollectedData(20, 1, "C", "V");
            CollectedData c21 = new CollectedData(21, 2, "C", "V");
            CollectedData c22 = new CollectedData(22, 4, "C", "N");
            CollectedData c23 = new CollectedData(23, 3, "C", "V");

            _context.CollectedData.AddRange(c1, c2, c3, c4, c5, c6, c7,
                                            c8, c9, c10, c11, c12, c13,
                                            c14, c15, c16, c17, c18, c19,
                                            c20, c21, c22, c23);

            _context.SaveChanges();
        }
    }
}
