using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul;
using SafariSoul.Models;

namespace SafariSoul.Pages.ZooTransactionEventTicketCRUD
{
    public class CreateModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public CreateModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EventId"] = new SelectList(_context.ZooEvents, "EventId", "EventId");
        ViewData["TransactionId"] = new SelectList(_context.ZooTransactions, "TransactionId", "TransactionId");
            return Page();
        }

        [BindProperty]
        public ZooTransactionEventTicket ZooTransactionEventTicket { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ZooTransactionEventTickets == null || ZooTransactionEventTicket == null)
            {
                return Page();
            }

            _context.ZooTransactionEventTickets.Add(ZooTransactionEventTicket);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
