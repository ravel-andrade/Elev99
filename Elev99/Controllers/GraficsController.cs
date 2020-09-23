using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elev99.Data;
using Elev99.Services;
using Microsoft.AspNetCore.Mvc;
using Elev99.Models.ViewModels;

namespace Elev99.Controllers
{
    public class GraficsController : Controller
    {

        private readonly CollectedDataService _collectedDataService;
        private readonly Elev99Context _context;

        public GraficsController(CollectedDataService collectedDataService)
        {
            _collectedDataService = collectedDataService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ConvertedInfo()
            {
                andarMenosUtilizado = await _collectedDataService.andarMenosUtilizadoAsync(),
                elevadorMaisFrequentado = await _collectedDataService.elevadorMaisFrequentadoAsync(),
                elevadorMenosFrequentado = await _collectedDataService.elevadorMenosFrequentadoAsync(),
                percentualDeUsoElevadorA = await _collectedDataService.percentualDeUsoElevadorAAsync(),
                percentualDeUsoElevadorB = await _collectedDataService.percentualDeUsoElevadorBAsync(),
                percentualDeUsoElevadorC = await _collectedDataService.percentualDeUsoElevadorCAsync(),
                percentualDeUsoElevadorD = await _collectedDataService.percentualDeUsoElevadorDAsync(),
                percentualDeUsoElevadorE = await _collectedDataService.percentualDeUsoElevadorEAsync(),

                periodoMaiorFluxoElevadorMaisFrequentado = await
                _collectedDataService.periodoMaiorFluxoElevadorMaisFrequentadoAsync(),

                periodoMaiorUtilizacaoConjuntoElevadores = await
                _collectedDataService.periodoMaiorUtilizacaoConjuntoElevadoresAsync(),

                periodoMenorFluxoElevadorMenosFrequentado = await
                _collectedDataService.periodoMenorFluxoElevadorMenosFrequentadoAsync()

            };
            return View(viewModel);
        }
    }
}
