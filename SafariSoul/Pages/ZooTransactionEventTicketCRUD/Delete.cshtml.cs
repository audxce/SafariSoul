using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;
using SafariSoul.Models;

namespace SafariSoul.Pages.ZooTransactionEventTicketCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DeleteModel(SafariSoul.OfficalZooDbContext context)
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

            var zootransactioneventticket = await _context.ZooTransactionEventTickets.FirstOrDefaultAsync(m => m.EventId == id);

            if (zootransactioneventticket == null)
            {
                return NotFound();
            }
            else 
            {
                ZooTransactionEventTicket = zootransactioneventticket;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ZooTransactionEventTickets == null)
            {
                return NotFound();
            }
            var zootransactioneventticket = await _context.ZooTransactionEventTickets.FindAsync(id);

            if (zootransactioneventticket != null)
            {
                ZooTransactionEventTicket = zootransactioneventticket;
                _context.ZooTransactionEventTickets.Remove(ZooTransactionEventTicket);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
