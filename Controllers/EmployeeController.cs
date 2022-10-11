using NguyenCongLinhBTH2.Data;
using NguyenCongLinhBTH2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace NguyenCongLinhBTH2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _context.Employees.ToListAsync();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee ep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ep);
        }
    }
}