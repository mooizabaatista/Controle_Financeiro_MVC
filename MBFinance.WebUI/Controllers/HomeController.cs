using MBFinance.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using X.PagedList;

namespace MBFinance.WebUI.Controllers
{
    public class HomeController : Controller
    {
        //Service Injection
        private readonly ILancamentoService _service;

        public HomeController(ILancamentoService lancamentoService)
        {
            _service = lancamentoService;
        }

        // Pagina Inicial
        public async Task<IActionResult> Index(int? pagina)
        {
            //Obtendo os lancamentos
            var lancamentos = await _service.GetAllAsync();

            //Caalculando o valor total gasto
            decimal valorTotal = 0;
            foreach (var lancamento in lancamentos)
            {
                valorTotal += lancamento.Valor;
            }

            // Informações para a view
            ViewBag.ValorTotal = valorTotal;
            ViewBag.Titulo = "Página Principal";

            //Paginação
            const int itensPorPagina = 5;
            int numeroPorPagina = (pagina ?? 1);

            return View(lancamentos.ToPagedList(numeroPorPagina, itensPorPagina));
        }
    }
}
