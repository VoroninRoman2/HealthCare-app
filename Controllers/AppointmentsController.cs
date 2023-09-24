using HealthCare_app.Models;
using HealthCare_app.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare_app.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IRepository<HealthcareProvider> _healthcareProviderRepository;

        public AppointmentsController(IRepository<Appointment> appointmentRepository, IRepository<HealthcareProvider> healthcareProviderRepository)
        {
            _appointmentRepository = appointmentRepository;
            _healthcareProviderRepository = healthcareProviderRepository;
        }

        public async Task<IActionResult> Index(int patientId)
        {
            var appointments = (await _appointmentRepository.GetAllAsync())
                .Where(a => a.PatientId == patientId);
            return View(appointments);
        }
        public async Task<IActionResult> Create(int patientId)
        {
            ViewData["PatientId"] = patientId;
            ViewData["HealthcareProviders"] = await _healthcareProviderRepository.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int patientId, DateTime dateTime, string purpose, int healthcareProviderId, string gMapsHospitalUrl) // Assuming healthcareProviderId has a default value here, you may replace it with a proper value or logic
        {
            var appointment = new Appointment
            {
                PatientId = patientId,
                DateTime = dateTime,
                Purpose = purpose,
                HealthcareProviderId = healthcareProviderId,
                GMapsHospitalUrl = gMapsHospitalUrl
            };

            await _appointmentRepository.AddAsync(appointment);
            await _appointmentRepository.SaveChangesAsync();

            return RedirectToAction(nameof(Index), new { patientId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment == null) return NotFound();

            return View(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            _appointmentRepository.Delete(appointment);
            await _appointmentRepository.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { patientId = appointment.PatientId });
        }
    }
}