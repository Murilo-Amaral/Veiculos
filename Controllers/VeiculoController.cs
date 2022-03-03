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

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var veiculo = await _appContext.Veiculo.FindAsync(id);

            if(veiculo == null)
            {
                return BadRequest();
            }
            return View(veiculo);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid? id)
        {
            var veiculo = await _appContext.Veiculo.FindAsync(id);
            _appContext.Veiculo.Remove(veiculo);
            await _appContext.SaveChangesAsync();
            return RedirectToAction("Index");
        } 

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var veiculo = await _appContext.Veiculo.FindAsync(id);
            if (veiculo == null)
            {
                return BadRequest();
            }
            return View(veiculo);
        }

        [HttpGet]
        public async Task<IActionResult>Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var veiculo = await _appContext.Veiculo.FindAsync(id);
            if(veiculo == null)
            {
                return BadRequest();
            }
            return View(veiculo);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, Veiculo veiculo, IList<IFormFile> Img)
        {
            if (id == null)
            {
                return NotFound();
            }
            var oldData = _appContext.Veiculo.AsNoTracking().FirstOrDefault(x => x.Id == id);

            IFormFile Upimg = Img.FirstOrDefault();
            MemoryStream ms = new MemoryStream();
            if(Img.Count > 0)
            {
                Upimg.OpenReadStream().CopyTo(ms);
                veiculo.Foto = ms.ToArray();
            }
            else
            {
                veiculo.Foto = oldData.Foto;
            }
            if (ModelState.IsValid)
            {
                _appContext.Update(veiculo);
                await _appContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(veiculo);
        }
    }
}