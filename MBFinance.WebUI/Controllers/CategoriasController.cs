using MBFinance.Application.Interfaces;
using MBFinance.Domain.Entities;
using MBFinance.Infra.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MBFinance.WebUI.Controllers
{
    public class CategoriasController : Controller
    {

        //Service Injection
        private readonly ICategoriaService _categoriaService;
        private readonly IUnitOfWork _uow;

        public CategoriasController(ICategoriaService categoriaService, IUnitOfWork uow = null)
        {
            _categoriaService = categoriaService;
            _uow = uow;
        }

        // Página Inicial - Lista Todas as categorias
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var items = await _categoriaService.GetAllAsync();
            return View(items);
        }

        // Página Cadastrar
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            await _categoriaService.Create(categoria);

            try
            {
                await _uow.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        //Página Editar
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _categoriaService.GetByIdAsync(id);

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Categoria categoria)
        {
            await _categoriaService.Update(categoria);

            try
            {
                await _uow.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        //Página Remover
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            var entity = await _categoriaService.GetByIdAsync(id);

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> RemovePost(int id)
        {
            await _categoriaService.DeleteAsync(id);

            try
            {
                await _uow.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
