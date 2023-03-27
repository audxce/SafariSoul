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
    public class IndexModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public IndexModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        public IList<ZooTransactionEventTicket> ZooTransactionEventTicket { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ZooTransactionEventTickets != null)
            {
                ZooTransactionEventTicket = await _context.ZooTransactionEventTickets
                .Include(z => z.Event)
                .Include(z => z.Transaction).ToListAsync();
            }
        }
    }
}
