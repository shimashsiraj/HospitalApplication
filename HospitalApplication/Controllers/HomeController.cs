using System.Diagnostics;
using HospitalApplication.Models;
using HospitalApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HospitalApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var today = DateTime.Now;
            var tomorrow = today.AddDays(1);

            var upcomingApppointments = await _context.Appointments
                .Include(a=>a.Patient)
                .Include(a=>a.Doctor)
                .Where(a=> a.AppointmentDate >=today && a.AppointmentDate < tomorrow)
                .OrderBy(a=>a.AppointmentDate)
                .ToListAsync();

            var totalToday = upcomingApppointments.Count;

            var pendingCount = await _context.Appointments
                .Where(a=> a.Status == "Pending")
                .CountAsync();

            var model = new HomeViewModel
            {
                UpcomingAppointments = upcomingApppointments,
                TotalAppointmentsToday = totalToday,
                PendingAppointments = pendingCount
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
