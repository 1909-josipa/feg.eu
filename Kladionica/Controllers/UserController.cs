using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kladionica.Models;

namespace Kladionica.Controllers
{
    public class UserController : Controller
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tickets.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string selectedOutcome)
        {
            if (selectedOutcome == null)
            {
                return NotFound();
            }

            var user = await _context.Tickets
                .FirstOrDefaultAsync(m => m.SelectedOutcome == selectedOutcome);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult AddorEdit(int id=0)
        {
            if (id == 0)
                return View(new Game());
            else
                return View(_context.Tickets.Find(id));
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SelectedOutcome,Payment,Cost,Stake,TotalCoefficient,WinningTicket,Gain")] Ticket ticket)
        {
            if (ModelState.IsValid)
            { 
                _context.Add(ticket);                  
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Tickets.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string selectedOutcome, [Bind("SelectedOutcome,Payment,Cost,Stake,TotalCoefficient,WinningTicket,Gain")] Ticket ticket)
        {
            if (selectedOutcome != ticket.SelectedOutcome)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(ticket);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string selectedOutcome)
        {
            if (selectedOutcome == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .FirstOrDefaultAsync(m => m.SelectedOutcome == selectedOutcome);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string selectedOutcome)
        {
            var ticket = await _context.Tickets.FindAsync(selectedOutcome);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string selectedOutcome)
        {
            return _context.Tickets.Any(e => e.SelectedOutcome == selectedOutcome);
        }
    }
}
