using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SafariSoul;
using SafariSoul.Models;

namespace SafariSoul.Pages.ZooTransactionEventTicketCRUD
{
    public class EditModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public EditModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ZooTransactionEventTicket ZooTransactionEventTicket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ZooTransactionEventTickets == null)
            {
                return NotFound();
            }

            var zootransactioneventticket =  await _context.ZooTransactionEventTickets.FirstOrDefaultAsync(m => m.EventId == id);
            if (zootransactioneventticket == null)
            {
                return NotFound();
            }
            ZooTransactionEventTicket = zootransactioneventticket;
           ViewData["EventId"] = new SelectList(_context.ZooEvents, "EventId", "EventId");
           ViewData["TransactionId"] = new SelectList(_context.ZooTransactions, "TransactionId", "TransactionId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ZooTransactionEventTicket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZooTransactionEventTicketExists(ZooTransactionEventTicket.EventId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ZooTransactionEventTicketExists(int id)
        {
          return (_context.ZooTransactionEventTickets?.Any(e => e.EventId == id)).GetValueOrDefault();
        }
    }
}
