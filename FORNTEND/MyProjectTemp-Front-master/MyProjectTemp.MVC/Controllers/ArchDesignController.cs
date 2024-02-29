using Microsoft.AspNetCore.Mvc;
using MyProjectTemp.MVC.Entities;
using MyProjectTemp.MVC.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProjectTemp.MVC.Controllers
{
    public class ArchDesignController : Controller
    {
        private readonly ApiService _apiService;

        public ArchDesignController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var designs = await _apiService.GetAsync<List<ArchDesign>>("ArchDesign/GetAll");
            return View(designs);
        }

        public async Task<IActionResult> Details(long id)
        {
            var design = await _apiService.GetAsync<ArchDesign>($"ArchDesign/GetById/{id}");
            return View(design);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArchDesign archDesign)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PostAsync<ArchDesign, ArchDesign>("ArchDesign/Add", archDesign);
                return RedirectToAction(nameof(Index));
            }
            return View(archDesign);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var design = await _apiService.GetAsync<ArchDesign>($"ArchDesign/GetById/{id}");
            return View(design);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, ArchDesign archDesign)
        {
            if (ModelState.IsValid)
            {
                await _apiService.PutAsync<ArchDesign, ArchDesign>($"ArchDesign/Update", archDesign);
                return RedirectToAction(nameof(Index));
            }
            return View(archDesign);
        }

        public async Task<IActionResult> Delete(long id)
        {
            var design = await _apiService.GetAsync<ArchDesign>($"ArchDesign/GetById/{id}");
            return View(design);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            await _apiService.DeleteAsync($"ArchDesign/Delete/{id}");
            return RedirectToAction(nameof(Index));
        }
    }
}
