using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul;

namespace SafariSoul.Pages.ZooUserCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly SafariSoul.OfficalZooDbContext _context;

        public DeleteModel(SafariSoul.OfficalZooDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ZooUser ZooUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ZooUsers == null)
            {
                return NotFound();
            }

            var zoouser = await _context.ZooUsers.FirstOrDefaultAsync(m => m.UserId == id);

            if (zoouser == null)
            {
                return NotFound();
            }
            else 
            {
                ZooUser = zoouser;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ZooUsers == null)
            {
                return NotFound();
            }
            var zoouser = await _context.ZooUsers.FindAsync(id);

            if (zoouser != null)
            {
                ZooUser = zoouser;
                _context.ZooUsers.Remove(ZooUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
