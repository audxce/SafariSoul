﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

namespace SafariSoul.Pages.MaintenanceRequestCRUD
{
    public class DetailsModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public DetailsModel(SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

      public MaintenanceRequest MaintenanceRequest { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MaintenanceRequests == null)
            {
                return NotFound();
            }

            var maintenancerequest = await _context.MaintenanceRequests.FirstOrDefaultAsync(m => m.TicketNo == id);
            if (maintenancerequest == null)
            {
                return NotFound();
            }
            else 
            {
                MaintenanceRequest = maintenancerequest;
            }
            return Page();
        }
    }
}
