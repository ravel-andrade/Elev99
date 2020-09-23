using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elev99.Models.ViewModels
{
    public class ConvertedInfo
    {
        public List<int> andarMenosUtilizado { get; set; }
        public List<char> elevadorMaisFrequentado { get; set; }
        public List<char> elevadorMenosFrequentado { get; set; }
        public float percentualDeUsoElevadorA { get; set; }
        public float percentualDeUsoElevadorB { get; set; }
        public float percentualDeUsoElevadorC { get; set; }
        public float percentualDeUsoElevadorD { get; set; }
        public float percentualDeUsoElevadorE { get; set; }
        public List<char> periodoMaiorFluxoElevadorMaisFrequentado { get; set; }
        public List<char> periodoMaiorUtilizacaoConjuntoElevadores { get; set; }
        public List<char> periodoMenorFluxoElevadorMenosFrequentado { get; set; }
    }
}
