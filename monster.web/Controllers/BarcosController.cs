using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using monster.web.Data;
using monster.web.Domain.Entities;

namespace monster.web.Controllers
{
    public class BarcosController : Controller
    {
        private readonly AppDbContext _context;

        public BarcosController(AppDbContext context) => _context = context;

        // GET: Barcos
        public async Task<IActionResult> Index() => View(await _context.Barcos.ToListAsync());

        // GET: Barcos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var barco = await _context.Barcos
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (barco == null)
                return NotFound();

            return View(barco);
        }

        // GET: Barcos/Create
        public IActionResult Create() => View();

        // POST: Barcos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Nacion,Nivel,Tipo")] Barco barco)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barco);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barco);
        }

        // GET: Barcos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var barco = await _context.Barcos.FindAsync(id);
            
            if (barco == null)
                return NotFound();
            
            return View(barco);
        }

        // POST: Barcos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Nacion,Nivel,Tipo")] Barco barco)
        {
            if (id != barco.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barco);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarcoExists(barco.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(barco);
        }

        // GET: Barcos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var barco = await _context.Barcos
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (barco == null)
                return NotFound();

            return View(barco);
        }

        // POST: Barcos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var barco = await _context.Barcos.FindAsync(id);
            
            if (barco != null) _context.Barcos.Remove(barco);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarcoExists(int id) => _context.Barcos.Any(e => e.Id == id);
    }
}
