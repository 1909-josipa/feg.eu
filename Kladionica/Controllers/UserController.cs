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
            return View(await _context.Users.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string Sport)
        {
            if (Sport == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Sport == Sport);
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
                return View(_context.Users.Find(id));
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

            var user = await _context.Users.FindAsync(id);
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
        public async Task<IActionResult> Delete(string game)
        {
            if (game == null)
            {
                return NotFound();
            }

            var ticket = await _context.Users
                .FirstOrDefaultAsync(m => m.Game == game);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string game)
        {
            var ticket = await _context.Users.FindAsync(game);
            _context.Ticket.Remove(game);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.UserID == id);
        }
    }
}
