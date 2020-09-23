using Elev99.Data;
using Elev99.Models;
using Elev99.Services.Interfaces;
using System.Linq;
using Microsoft.CodeAnalysis.Editing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Elev99.Services
{
    public class CollectedDataService : IElevadorService
    {
        
        private readonly Elev99Context _context;

        public CollectedDataService(Elev99Context context)
        {
            _context = context;
        }

        public List<CollectedData> findAll()
        {
            return _context.CollectedData.ToList();
        }

        public List<int> andarMenosUtilizado()
        {
            List<int> values = new List<int>();
            List<int> floors = new List<int>();
            foreach (CollectedData x in this.findAll())
            {
                values.Add(x.Floor);
            }
            int min = values.Min();
            
            foreach(int x in values)
            {
                if(x == min)
                {
                    floors.Add(x);
                }
            }
            Console.WriteLine(floors);
            return floors;
        }

        public List<char> elevadorMaisFrequentado()
        {
            var nameGroup = this.findAll().GroupBy(x => x.Elevator);
            var maxCount = nameGroup.Max(g => g.Count());
            var mostCommons = nameGroup.Where(x => x.Count() == maxCount).Select(x => x.Key).ToList();
            
            return  mostCommons;
        }

        public List<char> elevadorMenosFrequentado()
        {
            var nameGroup = this.findAll().GroupBy(x => x.Elevator);
            var minCount = nameGroup.Min(g => g.Count());
            var mostCommons = nameGroup.Where(x => x.Count() == minCount).Select(x => x.Key).ToList();

            return mostCommons;
        }

        public float percentualDeUsoElevadorA()
        {
            int totalUses = this.findAll().Count;
            var totalUsesA = this.findAll().GroupBy(x => x.Elevator).Where(x => x.Key == 'A').Count();
            float percent = (totalUsesA * 100) / totalUses;
            return percent;
        }

        public float percentualDeUsoElevadorB()
        {
            int totalUses = this.findAll().Count;
            var totalUsesB = this.findAll().GroupBy(x => x.Elevator).Where(x => x.Key == 'B').Count();
            float percent = (totalUsesB * 100) / totalUses;
            return percent;
        }

        public float percentualDeUsoElevadorC()
        {
            int totalUses = this.findAll().Count;
            var totalUsesC = this.findAll().GroupBy(x => x.Elevator).Where(x => x.Key == 'C').Count();
            float percent = (totalUsesC * 100) / totalUses;
            return percent;
        }

        public float percentualDeUsoElevadorD()
        {
            int totalUses = this.findAll().Count;
            var totalUsesD = this.findAll().GroupBy(x => x.Elevator).Where(x => x.Key == 'D').Count();
            float percent = (totalUsesD * 100) / totalUses;
            return percent;
        }

        public float percentualDeUsoElevadorE()
        {
            int totalUses = this.findAll().Count;
            var totalUsesE = this.findAll().GroupBy(x => x.Elevator).Where(x => x.Key == 'E').Count();
            float percent = (totalUsesE * 100) / totalUses;
            return percent;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            List<char> list = this.elevadorMaisFrequentado();
            var nameGroup = this.findAll().GroupBy(x => (x.Shift, list.Contains(x.Elevator)));
            var maxCount = nameGroup.Max(g => g.Count());
            var mostCommons = nameGroup.Where(x => x.Count() == maxCount).Select(x =>x.Key).ToList();
            List<char> final = new List<char>();
            foreach ((char y, bool x) in mostCommons)
            {
                final.Add(y);
            }
            return final;
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            var nameGroup = this.findAll().GroupBy(x => x.Shift);
            var maxCount = nameGroup.Max(g => g.Count());
            var mostCommons = nameGroup.Where(x => x.Count() == maxCount).Select(x => x.Key).ToList();
            return mostCommons;
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            List<char> list = this.elevadorMenosFrequentado();
            var nameGroup = this.findAll().GroupBy(x => (x.Shift, list.Contains(x.Elevator)));
            var minCount = nameGroup.Min(g => g.Count());
            var mostCommons = nameGroup.Where(x => x.Count() == minCount).Select(x => x.Key).ToList();
            List<char> final = new List<char>();
            foreach ((char y, bool x) in mostCommons)
            {
                final.Add(y);
            }
            return final;
        }

    }
}
