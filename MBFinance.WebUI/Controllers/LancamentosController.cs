using MBFinance.Application.Interfaces;
using MBFinance.Domain.Entities;
using MBFinance.Infra.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace MBFinance.WebUI.Controllers
{
    public class LancamentosController : Controller
    {
        //Services Injection
        private readonly ILancamentoService _service;
        private readonly ICategoriaService _categoriaService;
        private readonly IUnitOfWork _uow;

        public LancamentosController(ILancamentoService service, ICategoriaService categoriaService, IUnitOfWork uow)
        {
            _service = service;
            _categoriaService = categoriaService;
            _uow = uow;
        }


        // Página Cadastrar
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categorias = new SelectList(await _categoriaService.GetAllAsync(), "Id", "Nome");

           return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Lancamento lancamento)
        {
            await _service.Create(lancamento);

            try
            {
                await _uow.Commit();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // Página Editar
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categorias = new SelectList(_categoriaService.GetAllAsync().Result, "Id", "Nome");
            var item = await _service.GetByIdAsync(id);

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Lancamento lancamento)
        {
            var lancamentoRecebido = lancamento;
            await _service.Update(lancamentoRecebido);

            try
            {
                await _uow.Commit();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }


        //Página Remover
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            var entity = await _service.GetByIdAsync(id);

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> RemovePost(int id)
        {
            await _service.DeleteAsync(id);

            try
            {
                await _uow.Commit();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
