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
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace Elev99.Services
{
    public class CollectedDataService : IElevadorService
    {
        
        private readonly Elev99Context _context;

        public CollectedDataService(Elev99Context context)
        {
            _context = context;
        }

        public async Task<List<CollectedData>> findAllAsync()
        {
            return await _context.CollectedData.ToListAsync();
        }

        public async Task<List<int>> andarMenosUtilizadoAsync()
        {
            var content = await this.findAllAsync();

            List<int> values = new List<int>();
            List<int> floors = new List<int>();
            List<int> floorsZero = new List<int>();

            foreach (CollectedData x in content)
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
            for (int i = 0; i < 15; i++)
            {
                if (!values.Contains(i))
                {
                    floorsZero.Add(i);
                }
            }

            bool isEmpty = !floorsZero.Any();
            if (isEmpty)
            {
                return floors;
            }
            else
            {
                return floorsZero;
            }
            
        }

        public async Task<List<char>> elevadorMaisFrequentadoAsync()
        {
            
            var content = await this.findAllAsync();
            var nameGroup = content.GroupBy(x => x.Elevator);
            var maxCount = nameGroup.Max(g => g.Count());
            var mostCommons = nameGroup.Where(x => x.Count() == maxCount).Select(x => x.Key).ToList();
            
            return  mostCommons;
        }

        public async Task<List<char>> elevadorMenosFrequentadoAsync()
        {
            
            var cont = await this.findAllAsync();
            var nameGroup = cont.GroupBy(x => x.Elevator);
            var minCount = nameGroup.Min(g => g.Count());
            var mostCommons = nameGroup.Where(x => x.Count() == minCount).Select(x => x.Key).ToList();
            
            return mostCommons;
        }

        public async Task<float> percentualDeUsoElevadorAAsync()
        {
            char charValue = 'A';
            var content = await this.findAllAsync();
            float totalUses = content.Count;
            var totalUsesA = content.Where(x => x.Elevator.Equals(charValue)).Count();
            float percent = (totalUsesA * 100) / totalUses;
            return percent;
        }

        public async Task<float> percentualDeUsoElevadorBAsync()
        {
            char charValue = 'B';
            var content = await this.findAllAsync();
            float totalUses = content.Count;
            var totalUsesA = content.Where(x => x.Elevator.Equals(charValue)).Count();
            float percent = (totalUsesA * 100) / totalUses;
            return percent;
        }

        public async Task<float> percentualDeUsoElevadorCAsync()
        {
            char charValue = 'C';
            var content = await this.findAllAsync();
            float totalUses = content.Count;
            var totalUsesA = content.Where(x => x.Elevator.Equals(charValue)).Count();
            float percent = (totalUsesA * 100) / totalUses;
            return percent;
        }

        public async Task<float> percentualDeUsoElevadorDAsync()
        {
            char charValue = 'D';
            var content = await this.findAllAsync();
            float totalUses = content.Count;
            var totalUsesA = content.Where(x => x.Elevator.Equals(charValue)).Count();
            float percent = (totalUsesA * 100) / totalUses;
            return percent;
        }

  

        public async Task<float> percentualDeUsoElevadorEAsync()
        {
            char charValue = 'E';
            var content = await this.findAllAsync();
            float totalUses = content.Count;
            var totalUsesA = content.Where(x => x.Elevator.Equals(charValue)).Count();
            float percent = (totalUsesA * 100) / totalUses;
            return percent;
        }
        


        public async Task<List<char>> periodoMaiorUtilizacaoConjuntoElevadoresAsync()
        {
            var content = await this.findAllAsync();
            var nameGroup = content.GroupBy(x => x.Shift);
            var maxCount = nameGroup.Max(g => g.Count());
            var mostCommons = nameGroup.Where(x => x.Count() == maxCount).Select(x => x.Key).ToList();
            return mostCommons;
        }

        public async Task<List<char>> periodoMaiorFluxoElevadorMaisFrequentadoAsync()
        {
            var content = await this.findAllAsync();
            List<char> list = await this.elevadorMaisFrequentadoAsync();
            List<char> listFinal = new List<char>();
            List<int> listMax = new List<int>();

            foreach (char z in list)
            {
                var auxGroup = content.Where(y => y.Elevator.Equals(z));
                var nameGroup = auxGroup.GroupBy(x => x.Shift);
                var maxCount = nameGroup.Max(g => g.Count());
                listMax.Add(maxCount);
                var mostCommons = nameGroup.Where(x => x.Count() == maxCount).Select(x => x.Key).ToList();
                listFinal = mostCommons;
            }

            

            return listFinal;
        }

        public async Task<List<char>> periodoMenorFluxoElevadorMenosFrequentadoAsync()
        {
            var content = await this.findAllAsync();
            List<char> list = await this.elevadorMenosFrequentadoAsync();
            List<char> listFinal = new List<char>();
            List<int> listMax = new List<int>();
            List<char> listAux = new List<char>();

            foreach (char z in list)
            {
                var auxGroup = content.Where(y => y.Elevator.Equals(z));
                var nameGroup = auxGroup.GroupBy(x => x.Shift);
                var minCount = nameGroup.Min(g => g.Count());
                listMax.Add(minCount);
                var mostCommons = nameGroup.Where(x => x.Count() == minCount).Select(x => x.Key).ToList();
                listAux = mostCommons;
                
            }

            if (!listAux.Contains('M'))
            {
                listFinal.Add('M');
            }
            if (!listAux.Contains('V'))
            {
                listFinal.Add('V');
            }
            if (!listAux.Contains('N'))
            {
                listFinal.Add('N');
            }

            if (!listFinal.Any())
            {
                return listAux;
            }
            else
            {
                return listFinal;
            }
            
        }

        
    }
}
