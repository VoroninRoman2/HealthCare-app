using HealthCare_app.Models;
using HealthCare_app.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthCare_app.Controllers
{
    public class PatientsController : Controller
    {
        private readonly IRepository<Patient> _patientRepository;

        public PatientsController(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IActionResult> Index()
        {
            var patients = await _patientRepository.GetAllAsync();
            return View(patients);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            await _patientRepository.AddAsync(patient);
            await _patientRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null) return NotFound();

            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Patient patient)
        {
            _patientRepository.Update(patient);
            await _patientRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null) return NotFound();

            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _patientRepository.GetByIdAsync(id);
            _patientRepository.Delete(patient);
            await _patientRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Appointments(int id)
        {
            // Implement your logic to fetch and return appointments for the patient.
            // Placeholder:
            return Content($"Showing appointments for patient with id = {id}");
        }

    }
}