using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SafariSoul.Models;

namespace SafariSoul.Pages.Login
{
    public class SignupModel : PageModel
    {
        private readonly SafariSoul.Models.ZooDbContext _context;

        public SignupModel (SafariSoul.Models.ZooDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
            ViewData["MembershipLevel"] = new SelectList(_context.Memberships, "MembershipLevel", "MembershipLevel");
            return Page();
        }

        [BindProperty]
        public ZooUserCustomerViewModel ZooUserCustomer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.ZooUsers == null || ZooUserCustomer.ZooUser == null || _context.Customers == null || ZooUserCustomer.Customer == null)
            {
                ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "FullName");
                ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FullName");
                ViewData["MembershipLevel"] = new SelectList(_context.Memberships, "MembershipLevel", "MembershipLevel");
                return Page();
            }

            _context.Customers.Add(ZooUserCustomer.Customer);
            await _context.SaveChangesAsync(); // Save the Customer first to generate the CustomerId

            // Set the ZooUser.CustomerId equal to the saved Customer.CustomerId
            ZooUserCustomer.ZooUser.CustomerId = ZooUserCustomer.Customer.CustomerId;
            _context.ZooUsers.Add(ZooUserCustomer.ZooUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("~/DefaultPages/Home");
        }

    }
}
