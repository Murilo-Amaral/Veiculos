using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veiculos.Models;

namespace Veiculos.Controllers
{
    public class VeiculoController : Controller
    {
        public readonly Veiculos.Data.AppContext _appContext;

        public VeiculoController(Veiculos.Data.AppContext appContext)
        {
            _appContext = appContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tdsVeiculos = await _appContext.Veiculo.ToListAsync();
            return View(tdsVeiculos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Veiculo veiculo, IList<IFormFile> Img)
        {
            //Tratando Imagens
            IFormFile img = Img.FirstOrDefault();
            MemoryStream ms = new MemoryStream();
            if(Img.Count > 0)
            {
                img.OpenReadStream().CopyTo(ms);
                veiculo.Foto = ms.ToArray();
            }
            _appContext.Veiculo.Add(veiculo);
            await _appContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
