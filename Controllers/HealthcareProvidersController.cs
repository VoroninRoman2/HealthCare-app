using HealthCare_app.Models;
using HealthCare_app.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthCare_app.Controllers
{
    public class HealthcareProvidersController : Controller
    {
        private readonly IRepository<HealthcareProvider> _healthcareProviderRepository;

        public HealthcareProvidersController(IRepository<HealthcareProvider> healthcareProviderRepository)
        {
            _healthcareProviderRepository = healthcareProviderRepository;
        }

        public async Task<IActionResult> Index()
        {
            var healthcareProviders = await _healthcareProviderRepository.GetAllAsync();
            return View(healthcareProviders);
        }
        // ...

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HealthcareProvider provider)
        {
            await _healthcareProviderRepository.AddAsync(provider);
            await _healthcareProviderRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var provider = await _healthcareProviderRepository.GetByIdAsync(id);
            if (provider == null) return NotFound();

            return View(provider);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HealthcareProvider provider)
        {
            _healthcareProviderRepository.Update(provider);
            await _healthcareProviderRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var provider = await _healthcareProviderRepository.GetByIdAsync(id);
            if (provider == null) return NotFound();

            return View(provider);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var provider = await _healthcareProviderRepository.GetByIdAsync(id);
            _healthcareProviderRepository.Delete(provider);
            await _healthcareProviderRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}