using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactsManager;
using ContactsManager.Models;

namespace ContactsManager.Controllers
{
    public class ContactPersonController : Controller
    {
        private readonly AppDataContext _context;

        public ContactPersonController(AppDataContext context)
        {
            _context = context;    
        }

        private int CalculateAge(DateTime dayOfBirth)
        {
            return DateTime.Now.Subtract(dayOfBirth).Days / 365;
        }

        // GET: ContactPerson
        public async Task<IActionResult> Index()
        {
            var persons = await _context.Persons.ToListAsync();

            foreach(ContactPerson person in persons)
            {
                person.Age = CalculateAge(person.DayOfBirth);
            }

            return View(persons);
        }

        // GET: ContactPerson/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPerson = await _context.Persons
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contactPerson == null)
            {
                return NotFound();
            }

            return View(contactPerson);
        }

        // GET: ContactPerson/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactPerson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DayOfBirth,Id,Street,HouseNumber,City,PostalCode,PhoneNumber,Email")] ContactPerson contactPerson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactPerson);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contactPerson);
        }

        // GET: ContactPerson/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPerson = await _context.Persons.SingleOrDefaultAsync(m => m.Id == id);
            if (contactPerson == null)
            {
                return NotFound();
            }
            return View(contactPerson);
        }

        // POST: ContactPerson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DayOfBirth,Id,Street,HouseNumber,City,PostalCode,PhoneNumber,Email")] ContactPerson contactPerson)
        {
            if (id != contactPerson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactPerson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactPersonExists(contactPerson.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(contactPerson);
        }

        // GET: ContactPerson/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactPerson = await _context.Persons
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contactPerson == null)
            {
                return NotFound();
            }

            return View(contactPerson);
        }

        // POST: ContactPerson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactPerson = await _context.Persons.SingleOrDefaultAsync(m => m.Id == id);
            _context.Persons.Remove(contactPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContactPersonExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
