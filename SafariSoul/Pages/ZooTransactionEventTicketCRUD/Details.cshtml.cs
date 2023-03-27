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
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DetailsModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

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
    }
}
