using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Elev99.Models;

namespace Elev99.Data
{
    public class Elev99Context : DbContext
    {
        public Elev99Context (DbContextOptions<Elev99Context> options)
            : base(options)
        {
        }

        public DbSet<Elev99.Models.CollectedData> CollectedData { get; set; }
    }
}
