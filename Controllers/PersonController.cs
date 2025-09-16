using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;   
using UserForm.Data;
using UserForm.Models;

namespace UserForm.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Person
        public async Task<IActionResult> Index()
        {
            var people = await _context.Persons
                                       .AsNoTracking()
                                       .ToListAsync();
            return View(people);
        }

        // GET: /Person/Create
        public IActionResult Create()
        {
            return View(new Persons());
        }

        // POST: /Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Persons person)
        {
            if (!ModelState.IsValid)
                return View(person);

            _context.Add(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: /Person/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
                return NotFound();

            return View(person);
        }

        // POST: /Person/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Persons person)
        {
            if (id != person.UserId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Persons.Any(e => e.UserId == person.UserId))
                        return NotFound();
                    else
                        throw;
                }
            }
            return View(person);
        }

        // POST: /Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
