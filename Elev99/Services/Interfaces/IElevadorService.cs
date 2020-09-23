using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elev99.Services.Interfaces
{
    interface IElevadorService
    {

        Task<List<int>> andarMenosUtilizadoAsync();

        Task<List<char>> elevadorMaisFrequentadoAsync();

        Task<List<char>> periodoMaiorFluxoElevadorMaisFrequentadoAsync();

        Task<List<char>> elevadorMenosFrequentadoAsync();

        Task<List<char>> periodoMenorFluxoElevadorMenosFrequentadoAsync();
      
        Task<List<char>> periodoMaiorUtilizacaoConjuntoElevadoresAsync();

        Task<float> percentualDeUsoElevadorAAsync();

        Task<float> percentualDeUsoElevadorBAsync();

        Task<float> percentualDeUsoElevadorCAsync();

        Task<float> percentualDeUsoElevadorDAsync();

        Task<float> percentualDeUsoElevadorEAsync();
    }
}
