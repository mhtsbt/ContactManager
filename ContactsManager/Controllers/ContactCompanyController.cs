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
    public class ContactCompanyController : Controller
    {
        private readonly AppDataContext _context;

        public ContactCompanyController(AppDataContext context)
        {
            _context = context;    
        }

        // GET: ContactCompany
        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }

        // GET: ContactCompany/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactCompany = await _context.Companies
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contactCompany == null)
            {
                return NotFound();
            }

            return View(contactCompany);
        }

        // GET: ContactCompany/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactCompany/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompanyName,VatNumber,Id,Street,HouseNumber,City,PostalCode,PhoneNumber,Email")] ContactCompany contactCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contactCompany);
        }

        // GET: ContactCompany/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactCompany = await _context.Companies.SingleOrDefaultAsync(m => m.Id == id);
            if (contactCompany == null)
            {
                return NotFound();
            }
            return View(contactCompany);
        }

        // POST: ContactCompany/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyName,VatNumber,Id,Street,HouseNumber,City,PostalCode,PhoneNumber,Email")] ContactCompany contactCompany)
        {
            if (id != contactCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactCompanyExists(contactCompany.Id))
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
            return View(contactCompany);
        }

        // GET: ContactCompany/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactCompany = await _context.Companies
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contactCompany == null)
            {
                return NotFound();
            }

            return View(contactCompany);
        }

        // POST: ContactCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactCompany = await _context.Companies.SingleOrDefaultAsync(m => m.Id == id);
            _context.Companies.Remove(contactCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContactCompanyExists(int id)
        {
            return _context.Companies.Any(e => e.Id == id);
        }
    }
}
